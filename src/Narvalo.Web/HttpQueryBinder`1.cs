﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using Narvalo.Applicative;
    using Narvalo.Linq;

    public abstract partial class HttpQueryBinder<TQuery> : IHttpQueryBinder<TQuery>
    {
        private readonly List<HttpQueryBinderException> _errors = new List<HttpQueryBinderException>();

        protected HttpQueryBinder() { }

        public IEnumerable<HttpQueryBinderException> BindingErrors => _errors;

        public Maybe<TQuery> Bind(HttpRequest request)
        {
            Require.NotNull(request, nameof(request));

            return from q in BindCore(request) where Validate(q) select q;
        }

        protected abstract Maybe<TQuery> BindCore(HttpRequest request);

        protected bool Validate(TQuery query)
            => (from prop in TypeDescriptor.GetProperties(query).Cast<PropertyDescriptor>()
                from attr in prop.Attributes.OfType<ValidationAttribute>()
                where !attr.IsValid(prop.GetValue(query))
                select attr).IsEmpty();

        protected void AddError(HttpQueryBinderException exception) => _errors.Add(exception);
    }
}

