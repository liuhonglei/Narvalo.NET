﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Mvp.Properties;

    public partial class /*Default*/MessageCoordinator : IMessageCoordinator
    {
        private readonly bool _closeable;
        private readonly Object _lock = new Object();

        private bool _closed = false;

        public MessageCoordinator() : this(closeable: true) { }

        protected MessageCoordinator(bool closeable)
        {
            _closeable = closeable;
        }

        public static MessageCoordinator BlackHole => BlackHole_.Instance;

        public void Close()
        {
            if (!_closeable || _closed) { return; }

            lock (_lock)
            {
                if (_closed) { return; }

                _closed = true;
            }
        }

        public void Publish<T>(T message)
        {
            ThrowIfClosed();

            PublishCore(message);
        }

        public void Subscribe<T>(Action<T> onNext)
        {
            ThrowIfClosed();

            SubscribeCore(onNext);
        }

        protected virtual void PublishCore<T>(T message)
        {
            Trace.TraceWarning("[MessageCoordinator] All messages published to this bus are dropped.");
        }

        protected virtual void SubscribeCore<T>(Action<T> onNext)
        {
            Trace.TraceWarning(
                "[MessageCoordinator] Even if subscription is allowed, no messages will ever be received.");
        }

        private void ThrowIfClosed()
        {
            if (_closed)
            {
                throw new InvalidOperationException(Strings.MessageCoordinator_Closed);
            }
        }

        private sealed class BlackHole_ : MessageCoordinator
        {
            // NB: Since we choose a singleton, we disable the ability to close this message bus.
            private BlackHole_() : base(closeable: false) { }

            public static BlackHole_ Instance => Singleton_.Instance;

            protected override void PublishCore<T>(T message) { }

            protected override void SubscribeCore<T>(Action<T> onNext) { }

            [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "[Ignore] Implementation of lazy initialized singleton.")]
            private sealed class Singleton_
            {
                internal static readonly BlackHole_ Instance = new BlackHole_();

                [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "[Ignore] Implementation of lazy initialized singleton.")]
                static Singleton_() { }
            }
        }
    }
}
