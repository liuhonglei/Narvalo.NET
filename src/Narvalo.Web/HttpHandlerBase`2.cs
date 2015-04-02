﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Web;

    using Narvalo.Web.Properties;

    public abstract partial class HttpHandlerBase<TQuery, TBinder> : HttpHandlerBase
        where TBinder : IHttpQueryBinder<TQuery>, new()
    {
        protected abstract void ProcessRequestCore(HttpContext context, TQuery query);

        protected sealed override void ProcessRequestCore(HttpContext context)
        {
            // REVIEW: Parameter validation.
            var binder = new TBinder();

            binder.Bind(context.Request)
                .Invoke(
                    action: _ => ProcessRequestCore(context, _),
                    caseNone: () => ProcessBindingFailure_(context, binder));
        }

        protected virtual void OnBindingFailure(HttpContext context, HttpQueryBinderException exception)
        {
            Require.NotNull(context, "context");
            Require.NotNull(exception, "exception");

            var response = context.Response;

            response.SetStatusCode(HttpStatusCode.BadRequest);
            response.Write(exception.Message);
        }

        private void ProcessBindingFailure_(HttpContext context, TBinder binder)
        {
            Contract.Requires(context != null);

            var errors = binder.BindingErrors;
            HttpQueryBinderException exception;

            var errorsCount = errors.Count();

            if (errorsCount > 1)
            {
                exception = new HttpQueryBinderException(
                    Strings_Web.HttpHandlerBase_BindingFailure,
                    new AggregateException(errors));
            }
            else if (errorsCount == 1)
            {
                exception = errors.First().AssumeNotNull();
            }
            else
            {
                exception = new HttpQueryBinderException(Strings_Web.HttpHandlerBase_UnknownBindingFailure);
            }

            OnBindingFailure(context, exception);
        }
    }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

    [ContractClass(typeof(HttpHandlerBaseContract<,>))]
    public abstract partial class HttpHandlerBase<TQuery, TBinder> { }

    [ContractClassFor(typeof(HttpHandlerBase<,>))]
    internal abstract class HttpHandlerBaseContract<TQuery, TBinder> : HttpHandlerBase<TQuery, TBinder>
        where TBinder : IHttpQueryBinder<TQuery>, new()
    {
        protected override void ProcessRequestCore(HttpContext context, TQuery query)
        {
            Contract.Requires(context != null);
            Contract.Requires(query != null);
        }
    }

#endif
}
