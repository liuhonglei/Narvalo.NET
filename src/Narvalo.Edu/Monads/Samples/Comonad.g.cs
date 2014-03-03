﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Creation Time: 03/03/2014 08:24:02
// Runtime Version: 4.0.30319.34011
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Edu.Monads.Samples {
    // Comonad methods.
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
