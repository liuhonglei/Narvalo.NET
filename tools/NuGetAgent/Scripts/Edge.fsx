﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

#load @"load-project.fsx"

printfn "Publishing packages to our own private NuGet server."
    
let facade = new MyGetFacade(ApiKeysContainer.Load) :> INuGetFacade
let packages = facade.GetPackagesToBePublished <| __SOURCE_DIRECTORY__ + @"\..\..\..\work\packages"

for package in packages do facade.PublishPackage package