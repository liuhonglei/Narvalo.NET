﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    static class Monad
    {
        static readonly Monad<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly Monad<Unit> Zero_ = Monad<Unit>.Zero;

        public static Monad<Unit> Unit { get { return Unit_; } }

        // Only for MonadPlus
        public static Monad<Unit> Zero { get { return Zero_; } }

        public static Monad<T> Return<T>(T value)
        {
            return Monad<T>.η(value);
        }

        public static Monad<T> Join<T>(Monad<Monad<T>> square)
        {
            return Monad<T>.μ(square);
        }
    }
}
