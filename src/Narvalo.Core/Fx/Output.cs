﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System.Diagnostics.Contracts;
    using System.Runtime.ExceptionServices;

    public static partial class Output
    {
        public static Output<T> Failure<T>(ExceptionDispatchInfo exceptionInfo)
        {
            Contract.Requires(exceptionInfo != null);

            return Output<T>.η(exceptionInfo);
        }
    }
}
