﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics.Contracts;
    using System.Web.Configuration;

    using Narvalo.Fx;
    using Narvalo.Internal;

    public static class NarvaloWebConfigurationManager
    {
        private static readonly Lazy<Maybe<AssetSection>> s_AssetSection
            = new Lazy<Maybe<AssetSection>>(InitializeAssetSection_);

        private static readonly Lazy<OptimizationSection> s_OptimizationSection
            = new Lazy<OptimizationSection>(InitializeOptimizationSection_);

        public static Maybe<AssetSection> AssetSection
        {
            get
            {
                Contract.Ensures(Contract.Result<Maybe<AssetSection>>() != null);

                return s_AssetSection.Value;
            }
        }

        public static OptimizationSection OptimizationSection
        {
            get
            {
                Contract.Ensures(Contract.Result<OptimizationSection>() != null);

                return s_OptimizationSection.Value.AssumeNotNull();
            }
        }

        public static NarvaloWebSectionGroup GetSectionGroup()
        {
            return GetSectionGroup("/");
        }

        public static NarvaloWebSectionGroup GetSectionGroup(string virtualPath)
        {
            return WebConfigurationManager.OpenWebConfiguration(virtualPath)
                .AssumeNotNull()
                .GetSectionGroup(NarvaloWebSectionGroup.GroupName) as NarvaloWebSectionGroup;
        }

        public static NarvaloWebSectionGroup GetSectionGroup(Configuration config)
        {
            Require.NotNull(config, "config");

            return config.SectionGroups[NarvaloWebSectionGroup.GroupName] as NarvaloWebSectionGroup;
        }

        private static Maybe<AssetSection> InitializeAssetSection_()
        {
            Contract.Ensures(Contract.Result<Maybe<AssetSection>>() != null);

            return WebSectionManager.MayGetSection<AssetSection>(Narvalo.Web.Configuration.AssetSection.SectionName);
        }

        private static OptimizationSection InitializeOptimizationSection_()
        {
            Contract.Ensures(Contract.Result<OptimizationSection>() != null);

            return WebSectionManager.GetSection<OptimizationSection>(OptimizationSection.SectionName);
        }
    }
}
