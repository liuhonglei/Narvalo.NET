﻿namespace Narvalo.Web
{
    using System;
    using System.Web;
    using Narvalo.Diagnostics;

    public static class HttpResponseCachingExtensions
    {
        public static void NoCache(this HttpResponse response)
        {
            Requires.NotNull(response);

            response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        public static void PubliclyCacheFor(this HttpResponse response, int days, int hours, int minutes)
        {
            Requires.NotNull(response);

            response.PubliclyCacheFor(new TimeSpan(days, hours, minutes, 0));
        }

        public static void PubliclyCacheFor(this HttpResponse response, TimeSpan duration)
        {
            Requires.NotNull(response);

            response.Cache.SetCacheability(HttpCacheability.Public);
            response.CacheFor_(duration);
        }

        public static void PrivatelyCacheFor(this HttpResponse response, int days, int hours, int minutes)
        {
            Requires.NotNull(response);

            response.PrivatelyCacheFor(new TimeSpan(days, hours, minutes, 0));
        }

        public static void PrivatelyCacheFor(this HttpResponse response, TimeSpan duration)
        {
            Requires.NotNull(response);

            response.Cache.SetCacheability(HttpCacheability.Private);
            response.CacheFor_(duration);
        }

        public static void CacheFor(this HttpResponse response, bool publicly, HttpVersions versions, TimeSpan duration)
        {
            Requires.NotNull(response);

            response.Cache.SetCacheability(publicly ? HttpCacheability.Public : HttpCacheability.Private);

            // En-tête HTTP 1.0
            if ((versions & HttpVersions.Http_1_0) == HttpVersions.Http_1_0) {
                response.Cache.SetExpires(DateTime.Now.Add(duration));
            }
            // En-tête HTTP 1.1
            if ((versions & HttpVersions.Http_1_1) == HttpVersions.Http_1_1) {
                response.Cache.SetMaxAge(duration);
                response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
            }
        }

        static void CacheFor_(this HttpResponse response, TimeSpan duration)
        {
            // En-tête HTTP 1.0
            response.Cache.SetExpires(DateTime.Now.Add(duration));
            // En-tête HTTP 1.1
            response.Cache.SetMaxAge(duration);
            response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        }
    }
}
