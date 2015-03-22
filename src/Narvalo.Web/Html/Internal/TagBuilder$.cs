﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Html.Internal
{
    using System.Web;
    using System.Web.Mvc;

    using Narvalo.Internal;

    /// <summary>
    /// Provides extension methods for <see cref="TagBuilder"/>.
    /// </summary>
    internal static class TagBuilderExtensions
    {
        public static IHtmlString ToHtmlString(this TagBuilder @this)
        {
            Promise.NotNull(@this);

            return @this.ToHtmlString(TagRenderMode.Normal);
        }

        public static IHtmlString ToHtmlString(this TagBuilder @this, TagRenderMode renderMode)
        {
            Promise.NotNull(@this);

            return new HtmlString(@this.ToString(renderMode));
        }
    }
}