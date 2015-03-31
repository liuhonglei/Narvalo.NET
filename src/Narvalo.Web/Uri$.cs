﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System;
    using System.Diagnostics.Contracts;

    using Narvalo.Web.Properties;

    public static class UriExtensions
    {
        // Also known as protocol-less URL.
        // <seealso cref="!:http://tools.ietf.org/html/rfc3986#section-4.2"/>
        public static string ToProtocolRelativeString(this Uri @this)
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<string>() != null);

            if (!@this.IsAbsoluteUri)
            {
                return @this.ToString();
            }

            var scheme = @this.Scheme;

            if (scheme == Uri.UriSchemeHttp)
            {
                return @this.ToString().Replace("http:", String.Empty);
            }
            else if (scheme == Uri.UriSchemeHttps)
            {
                return @this.ToString().Replace("https:", String.Empty);
            }
            else
            {
                throw new NotSupportedException(
                    Format.Resource(Strings_Web.UriExtensions_ProtocolRelativeUnsupportedScheme_Format, scheme));
            }
        }
    }
}
