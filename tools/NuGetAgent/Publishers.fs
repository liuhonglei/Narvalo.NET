﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace NuGetAgent

open System
open System.Collections.Generic
open System.Linq

open NuGet

[<RequireQualifiedAccess>]
module Publishers =

    /// Read-Only package repository, copied from NuGet.Common
    type ReadOnlyPackageRepository(packages:IEnumerable<IPackage>) =
        inherit PackageRepositoryBase()

        override this.Source = null
        override this.SupportsPrereleasePackages = true
        override this.GetPackages() = packages.AsQueryable()

    /// Publisher interface.
    type IPublisher =
        /// Publish a package.
        abstract member PublishPackage: package:IPackage -> unit

    /// Publisher to our own private NuGet server.
    type PublisherToMyGet(apiKeysContainer:ApiKeysContainer, ?purge) =
        // API Key for the MyGet server.
        let apiKey = apiKeysContainer.MyGetApiKey
        // MyGet server.
        let server = new PackageServer(Constants.MyGetServerSource, Constants.UserAgent)
        // MyGet repository.
        let repository = PackageRepositoryFactory.Default.CreateRepository(Constants.MyGetRepositorySource)

        interface IPublisher with
            member this.PublishPackage(package:IPackage) =
                let obsoletePackages, newerPackages =
                    repository.FindPackagesById package.Id
                    |> List.ofSeq
                    |> List.partition(fun p -> p.Version < package.Version)

                match purge with
                | None
                | Some(true) ->
                    // Delete obsolete packages.
                    obsoletePackages
                    |> List.iter(fun p -> this.DeletePackage(p.Id, p.Version.ToString()))
                | Some(false) -> ()

                // Publish the package.
                if newerPackages.Any()
                // TODO: Display a differente message detailing the two possible cases:
                // - package already published
                // - a more recent version already published
                then printfn "Skipping... a more recent version already exists."
                else this.PushPackage(package)

        /// Delete a package from the remote server.
        member private this.DeletePackage(id, version) =
            printfn "Deleting version %s" version

            server.DeletePackage(apiKey, id, version)

        /// Push a package to the remote server.
        member private this.PushPackage(package:IPackage) =
            printfn "Publishing package..."

            // NB: The timeout is in milliseconds.
            server.PushPackage(apiKey, package, package.GetStream().Length, timeout=60000, disableBuffering=true)

    /// Publisher to the official NuGet server.
    type PublisherToNuGet(apiKeysContainer:ApiKeysContainer) =
        // API Key for the NuGet server.
        let apiKey = apiKeysContainer.NuGetApiKey
        // NuGet server.
        let server = new PackageServer(Constants.NuGetServerSource, Constants.UserAgent)
        // NuGet repository.
        let repository = PackageRepositoryFactory.Default.CreateRepository(Constants.NuGetRepositorySource)

        interface IPublisher with
            member this.PublishPackage(package:IPackage) =
                let remotePackage = repository.FindPackage(package.Id, package.Version)

                if remotePackage <> null
                then printfn "Skipping... the package already exists on the server."
                else this.PushPackage(package)

        /// Push a package to the remote server.
        member private this.PushPackage(package:IPackage) =
            printfn "Pushing package..."

            // NB: The timeout is in milliseconds.
            server.PushPackage(apiKey, package, package.GetStream().Length, timeout=60000, disableBuffering=true)

    /// Find the latest packages located in a directory and sort them by dependency order.
    let findLatestPackages path filter =
        let repository = new LocalPackageRepository(path, enableCaching=false)

        // Find packages and apply filter.
        let packages = repository.GetPackages() |> Seq.filter(filter)

        // Collapse the list of packages, keeping only the latest version.
        let uniqPackages = packages.AsCollapsed()

        // Sort the packages by the dependency order.
        let sorter = new PackageSorter(targetFramework=null)
        sorter.GetPackagesByDependencyOrder(new ReadOnlyPackageRepository(uniqPackages))

    /// Publish packages using the supplied publisher.
    let publishPackages (publisher:IPublisher) packages =
        if Seq.isEmpty packages
        then printfn "No packages found for publication."
        else
            packages
            |> Seq.iter(fun (p:IPackage) ->
                printfn "> Processing package %s v%O" p.Id p.Version
                publisher.PublishPackage p)

    /// Discriminated union of publishers.
    [<NoComparison>]
    type Processor =
        | Retail of bool * IPublisher
        | Edge   of IPublisher
    with
        /// Factory method to create a processor.
        /// If retail is true, we shall process retail packages.
        /// If retail is false, we shall process edge packages.
        /// If official is true, we shall push packages to the official NuGet server.
        /// If official is false, we shall push packages to our own private NuGet server.
        /// If official is None, we automatically pick up the correct NuGet server.
        static member Create(retail, ?official) =
            let settings = loadNuGetSettings
            let container = new ApiKeysContainer(settings)

            // WARNING: Now that we use myget.org, we no longer purge obsolete packages.
            if retail then
                // For retail packages, the default behaviour is to publish them
                // to the official NuGet server.
                match official with
                | None
                | Some(true)  -> Retail(true, new PublisherToNuGet(container))
                | Some(false) -> Retail(false, new PublisherToMyGet(container, false))
            else
                // For edge packages, we only allow publication to our own private NuGet server.
                match official with
                | None
                | Some(false) -> Edge(new PublisherToMyGet(container, false))
                | Some(true)  -> failwith "You CAN NOT publish edge packages to the official NuGet server."

        /// Publish packages from a directory.
        member this.PublishPackagesFrom path =
            match this with

            | Retail(official, inner) ->
                printfn <| if official then "Publishing retail packages to the official NuGet server."
                           else "Publishing retail packages to MyGet."

                findLatestPackages path (
                    // Legacy behaviour:
                    // fun p -> not(p.Id.EndsWith(Constants.EdgePackageSuffix, StringComparison.Ordinal)))
                    fun p ->
                        p.Version.ToString().IndexOf(Constants.EdgePackageVersionTag, StringComparison.Ordinal) = -1)
                |> (publishPackages <| inner)

            | Edge(inner) ->
                printfn "Publishing edge packages to MyGet."

                findLatestPackages path (
                    // Legacy behaviour:
                    // fun p -> p.Id.EndsWith(Constants.EdgePackageSuffix, StringComparison.Ordinal))
                    fun p ->
                        not(p.IsReleaseVersion())
                        && p.Version.ToString().IndexOf(Constants.EdgePackageVersionTag, StringComparison.Ordinal) > 0)
                |> (publishPackages <| inner)

