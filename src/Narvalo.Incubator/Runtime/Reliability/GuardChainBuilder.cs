﻿namespace Narvalo.Runtime.Reliability
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class GuardChainBuilder
    {
        bool _closed = false;
        IList<IGuard> _guards = new List<IGuard>();

        public GuardChainBuilder(IGuard guard)
        {
            Require.NotNull(guard, "guard");

            Add(guard);
        }

        public IReadOnlyCollection<IGuard> Guards
        {
            get { return new ReadOnlyCollection<IGuard>(_guards); }
        }

        public void Add(IGuard guard)
        {
            ThrowIfClosed();

            Require.NotNull(guard, "guard");

            //if (!guard.IsChainable()) {
            //    throw new Failure.Argument("guard");
            //}

            _guards.Add(guard);
        }

        public void Add(IEnumerable<IGuard> guards)
        {
            ThrowIfClosed();

            Require.NotNull(guards, "guards");

            foreach (var proxy in guards) {
                Add(proxy);
            }
        }

        public GuardChain Build()
        {
            //IList<IGuard> guards = new List<IGuard>(_guards); 
            return new GuardChain(_guards);
        }

        public GuardChain Build(IGuard guard)
        {
            Close(guard);
            return Build();
        }

        public void Close(IGuard guard)
        {
            ThrowIfClosed();

            Require.NotNull(guard, "guard");

            _guards.Add(guard);
            _closed = true;
        }

        void ThrowIfClosed()
        {
            if (_closed) {
                throw new InvalidOperationException("XXX");
            }
        }
    }
}
