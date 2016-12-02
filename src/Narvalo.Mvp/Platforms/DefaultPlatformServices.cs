﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Platforms
{
    using System;
#if CONTRACTS_FULL // Contract Class and Object Invariants.
    using System.Diagnostics.Contracts;
#endif

    using Narvalo.Mvp.PresenterBinding;

    using static System.Diagnostics.Contracts.Contract;

    public class DefaultPlatformServices : IPlatformServices
    {
        private Func<ICompositeViewFactory> _compositeViewFactoryThunk
           = () =>
           {
               Ensures(Result<ICompositeViewFactory>() != null);

               return new CompositeViewFactory();
           };

        private Func<IMessageCoordinatorFactory> _messageCoordinatorFactoryThunk
           = () =>
           {
               Ensures(Result<IMessageCoordinatorFactory>() != null);

               return new MessageCoordinatorFactory();
           };

        private Func<IPresenterDiscoveryStrategy> _presenterDiscoveryStrategyThunk
           = () =>
           {
               Ensures(Result<IPresenterDiscoveryStrategy>() != null);

               return new AttributedPresenterDiscoveryStrategy();
           };

        private Func<IPresenterFactory> _presenterFactoryThunk
           = () =>
           {
               Ensures(Result<IPresenterFactory>() != null);

               return new PresenterFactory();
           };

        private ICompositeViewFactory _compositeViewFactory;
        private IMessageCoordinatorFactory _messageCoordinatorFactory;
        private IPresenterDiscoveryStrategy _presenterDiscoveryStrategy;
        private IPresenterFactory _presenterFactory;

        public ICompositeViewFactory CompositeViewFactory
        {
            get
            {
                if (_compositeViewFactory == null)
                {
                    _compositeViewFactory = _compositeViewFactoryThunk();
                }

                return _compositeViewFactory;
            }
        }

        public IMessageCoordinatorFactory MessageCoordinatorFactory
        {
            get
            {
                if (_messageCoordinatorFactory == null)
                {
                    _messageCoordinatorFactory = _messageCoordinatorFactoryThunk();
                }

                return _messageCoordinatorFactory;
            }
        }

        public IPresenterDiscoveryStrategy PresenterDiscoveryStrategy
        {
            get
            {
                if (_presenterDiscoveryStrategy == null)
                {
                    _presenterDiscoveryStrategy = _presenterDiscoveryStrategyThunk();
                }

                return _presenterDiscoveryStrategy;
            }
        }

        public IPresenterFactory PresenterFactory
        {
            get
            {
                if (_presenterFactory == null)
                {
                    _presenterFactory = _presenterFactoryThunk();
                }

                return _presenterFactory;
            }
        }

        protected void SetMessageCoordinatorFactory(Func<IMessageCoordinatorFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _messageCoordinatorFactoryThunk = thunk;
        }

        protected void SetCompositeViewFactory(Func<ICompositeViewFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _compositeViewFactoryThunk = thunk;
        }

        protected void SetPresenterDiscoveryStrategy(Func<IPresenterDiscoveryStrategy> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _presenterDiscoveryStrategyThunk = thunk;
        }

        protected void SetPresenterFactory(Func<IPresenterFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _presenterFactoryThunk = thunk;
        }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Invariant(_compositeViewFactoryThunk != null);
            Invariant(_messageCoordinatorFactoryThunk != null);
            Invariant(_presenterDiscoveryStrategyThunk != null);
            Invariant(_presenterFactoryThunk != null);
        }

#endif
    }
}
