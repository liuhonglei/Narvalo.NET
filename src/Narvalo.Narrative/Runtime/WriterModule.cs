﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative.Runtime
{
    using Autofac;
    using Narvalo.Narrative.Configuration;

    public sealed class WriterModule : Module
    {
        public bool DryRun { get; set; }

        public string OutputDirectory { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => new PathProvider(OutputDirectory)).As<IPathProvider>();

            if (DryRun) {
                builder.RegisterType<NoopWriter>().As<IOutputWriter>().InstancePerLifetimeScope();
            }
            else {
                builder.RegisterType<OutputWriter>().As<IOutputWriter>().InstancePerLifetimeScope();
            }
        }
    }
}
