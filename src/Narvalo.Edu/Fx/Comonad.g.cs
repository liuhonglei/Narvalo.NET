﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Edu.Fx {
	// Comonadic methods.
    public static partial class Comonad
    {
        // [Haskell] extract
        public static T Extract<T>(Comonad<T> monad)
        {
            return Comonad<T>.ε(monad);
        }

        // [Haskell] duplicate
        public static Comonad<Comonad<T>> Duplicate<T>(Comonad<T> monad)
        {
            return Comonad<T>.δ(monad);
        }
    }
}
