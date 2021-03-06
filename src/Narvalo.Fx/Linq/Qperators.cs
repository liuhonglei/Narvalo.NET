﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Linq
{
    /// <summary>
    /// Provides a set of extension methods for querying
    /// objects that implement <see cref="System.Collections.Generic.IEnumerable{T}"/>.
    /// </summary>
    /// <remarks>
    /// New LINQ operators:
    /// - Projecting: SelectAny (deferred)
    /// - Filtering: WhereAny (deferred)
    /// - Set: Append (deferred), Prepend (deferred)
    /// - Element: FirstOrNone, LastOrNone, SingleOrNone, ElementAtOrNone
    /// - Aggregation: Fold, Reduce
    /// - Quantifiers: IsEmpty, None
    /// - Generation: EmptyIfNull
    /// - Others: Flatten
    /// </remarks>
    public static partial class Qperators { }
}
