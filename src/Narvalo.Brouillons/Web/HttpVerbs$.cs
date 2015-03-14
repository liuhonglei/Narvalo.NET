﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class HttpVerbsExtensions
    {
        public static IList<string> ToLiteralList(this HttpVerbs verbs)
        {
            List<string> list = new List<string>();

            AddVerb_(verbs, HttpVerbs.Get, list, "GET");
            AddVerb_(verbs, HttpVerbs.Post, list, "POST");
            AddVerb_(verbs, HttpVerbs.Put, list, "PUT");
            AddVerb_(verbs, HttpVerbs.Delete, list, "DELETE");
            AddVerb_(verbs, HttpVerbs.Head, list, "HEAD");

            return list;
        }

        private static void AddVerb_(
              HttpVerbs verbs,
              HttpVerbs match,
              List<string> list,
              string entryText)
        {
            if (verbs.HasFlag(match))
            {
                list.Add(entryText);
            }
        }
    }
}