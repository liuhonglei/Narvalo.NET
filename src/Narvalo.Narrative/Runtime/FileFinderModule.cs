﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Autofac;
    using Autofac.Core;
    using Narvalo.IO;

    public sealed class FileFinderModule : Module
    {
        static readonly List<string> DirectoriesToIgnore_ = new List<string> { "bin", "obj", "_Aliens" };

        static readonly Func<DirectoryInfo, bool> DirectoryFilter
            = _ => !DirectoriesToIgnore_.Any(s => _.Name.Equals(s, StringComparison.OrdinalIgnoreCase));
        static readonly Func<FileInfo, bool> FileFilter
            = _ => !_.Name.EndsWith("Designer.cs", StringComparison.OrdinalIgnoreCase);

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => new FileFinder(DirectoryFilter, FileFilter))
                .AsSelf()
                .OnActivating(RegisterOnDirectoryStart_);

            builder.Register(_ => new ConcurrentFileFinder(DirectoryFilter, FileFilter))
                .AsSelf()
                .OnActivating(RegisterOnDirectoryStart_);
        }

        void RegisterOnDirectoryStart_(IActivatingEventArgs<ConcurrentFileFinder> handler)
        {
            var writer = handler.Context.Resolve<IOutputWriter>();

            handler.Instance.DirectoryStart += OnDirectoryStartThunk_(writer);
        }

        void RegisterOnDirectoryStart_(IActivatingEventArgs<FileFinder> handler)
        {
            var writer = handler.Context.Resolve<IOutputWriter>();

            handler.Instance.DirectoryStart += OnDirectoryStartThunk_(writer);
        }

        EventHandler<RelativeDirectoryEventArgs> OnDirectoryStartThunk_(IOutputWriter writer)
        {
            return (sender, e) => writer.CreateDirectory(e.RelativeDirectory);
        }
    }
}
