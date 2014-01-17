﻿namespace Narvalo.Web.Html
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web;
    using System.Web.Mvc;

    public static partial class HtmlHelperExtensions
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this", Justification = "On utilise une méthode d'extension afin d'améliorer son accessibilité.")]
        public static IHtmlString LoremIpsum(this HtmlHelper @this)
        {
            string ipsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            return new HtmlString(ipsum);
        }
    }
}
