﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Web.Core
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using Narvalo.Mvp;
    using Narvalo.Mvp.Web.Internal;

    public sealed class PageHost
    {
        private static readonly string s_PageHostKey = typeof(PageHost).FullName;

        private readonly HttpPresenterBinder _presenterBinder;

        public PageHost(Page page, HttpContext context)
        {
            Require.NotNull(page, "page");

            var hosts = FindHosts_(page);

            _presenterBinder = HttpPresenterBinderFactory.Create(hosts, context);

            _presenterBinder.PresenterCreated += (sender, e) =>
            {
                var presenter = e.Presenter as Internal.IHttpPresenter;
                if (presenter != null)
                {
                    presenter.AsyncManager = new PageAsyncTaskManager(page);
                }
            };

            // On page's initialization, bind the presenter.
            page.InitComplete += (sender, e) => _presenterBinder.PerformBinding();

            // Ensures that any attempt to use the message bus fails after pre-rendering completes.
            page.PreRenderComplete += (sender, e) => _presenterBinder.MessageCoordinator.Close();

            // On unloading the page, release the binder.
            page.Unload += (sender, e) => _presenterBinder.Release();
        }

        public static PageHost Register(Page page, HttpContext context)
        {
            Require.NotNull(page, "page");

            var pageContext = page.Items;

            if (pageContext.Contains(s_PageHostKey))
            {
                return (PageHost)pageContext[s_PageHostKey];
            }
            else
            {
                var host = new PageHost(page, context);
                pageContext[s_PageHostKey] = host;
                return host;
            }
        }

        public void RegisterView(IView view)
        {
            _presenterBinder.RegisterView(view);
        }

        private static IEnumerable<Control> FindHosts_(Page page)
        {
            yield return page;

            var masterHost = page.Master;

            while (masterHost != null)
            {
                yield return masterHost;

                masterHost = masterHost.Master;
            }
        }
    }
}
