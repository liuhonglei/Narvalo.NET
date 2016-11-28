﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Resolvers
{
    using System;
    using System.Collections.Generic;
#if CONTRACTS_FULL // Contract Class and Object Invariants.
    using System.Diagnostics.Contracts;
#endif

    public sealed class CachedPresenterBindingAttributesResolver
        : IPresenterBindingAttributesResolver
    {
        private readonly TypeKeyedResolverCache<IEnumerable<PresenterBindingAttribute>> _cache
           = new TypeKeyedResolverCache<IEnumerable<PresenterBindingAttribute>>();

        private readonly IPresenterBindingAttributesResolver _inner;

        public CachedPresenterBindingAttributesResolver(IPresenterBindingAttributesResolver inner)
        {
            Require.NotNull(inner, nameof(inner));

            _inner = inner;
        }

        public IEnumerable<PresenterBindingAttribute> Resolve(Type viewType)
        {
            return _cache.GetOrAdd(viewType, _inner.Resolve);
        }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(_inner != null);
        }

#endif
    }
}
