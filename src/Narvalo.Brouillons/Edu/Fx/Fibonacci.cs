﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Edu.Fx
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Fx;

    // WARNING: These sequences are infinite!
    public static class Fibonacci
    {
        private static IEnumerable<int> CreateViaIterator()
        {
            int i = 1;
            int j = 1;

            while (true)
            {
                int retval = i + j;
                i = j;
                j = retval;

                yield return retval;
            }
        }

        private static Func<int, int> CreateViaYCombinator()
        {
            return Recursion.Fix<int, int>(iter => i => i > 1 ? iter(i - 1) + iter(i - 2) : i);
        }

        private static IEnumerable<int> CreateViaAnamorphism()
        {
            return Narvalo.Fx.Sequence.Generate<Tuple<int, int>, int>(
                iterator: _ => Tuple.Create(_.Item2, _.Item1 + _.Item2),
                seed: Tuple.Create(1, 1),
                resultSelector: _ => _.Item1);
        }

        ////static IEnumerable<int> CreateViaAnamorphismAlternate()
        ////{
        ////    return Sequence.Create(
        ////        _ => Iteration.MayCreate(_.Item1, Tuple.Create(_.Item2, _.Item1 + _.Item2)),
        ////        Tuple.Create(1, 1));
        ////}
    }
}
