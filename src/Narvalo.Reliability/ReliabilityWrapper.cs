﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Reliability
{
    using System;

    public class ReliabilityWrapper
    {
        private readonly ISentinel _guard;

        public ReliabilityWrapper(ISentinel guard)
        {
            Require.NotNull(guard, "guard");

            _guard = guard;
        }

        public Action Wrap(Action action)
        {
            return () => _guard.Execute(action);
        }

        public Action<T> Wrap<T>(Action<T> action)
        {
            return (arg) => _guard.Execute(() => action(arg));
        }

        public Action<T1, T2> Wrap<T1, T2>(Action<T1, T2> action)
        {
            return (arg1, arg2) => _guard.Execute(() => action(arg1, arg2));
        }

        public Action<T1, T2, T3> Wrap<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return (arg1, arg2, arg3) => _guard.Execute(() => action(arg1, arg2, arg3));
        }

        public Action<T1, T2, T3, T4> Wrap<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            return (arg1, arg2, arg3, arg4) => _guard.Execute(() => action(arg1, arg2, arg3, arg4));
        }

        public Func<TResult> Wrap<TResult>(Func<TResult> func)
        {
            return () =>
            {
                var retval = default(TResult);
                _guard.Execute(() => { retval = func(); });
                return retval;
            };
        }

        public Func<T, TResult> Wrap<T, TResult>(Func<T, TResult> func)
        {
            return (arg) =>
            {
                var retval = default(TResult);
                _guard.Execute(() => { retval = func(arg); });
                return retval;
            };
        }

        public Func<T1, T2, TResult> Wrap<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            return (arg1, arg2) =>
            {
                var retval = default(TResult);
                _guard.Execute(() => { retval = func(arg1, arg2); });
                return retval;
            };
        }

        public Func<T1, T2, T3, TResult> Wrap<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
        {
            return (arg1, arg2, arg3) =>
            {
                var retval = default(TResult);
                _guard.Execute(() => { retval = func(arg1, arg2, arg3); });
                return retval;
            };
        }

        public Func<T1, T2, T3, T4, TResult> Wrap<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func)
        {
            return (arg1, arg2, arg3, arg4) =>
            {
                var retval = default(TResult);
                _guard.Execute(() => { retval = func(arg1, arg2, arg3, arg4); });
                return retval;
            };
        }
    }
}
