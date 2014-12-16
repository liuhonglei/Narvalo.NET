// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Collections",
    Justification = "[REVIEW] Complements the namespace from Narvalo.Core.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo",
    Justification = "[REVIEW] Complements the namespace from Narvalo.Core.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.FileFinder+<Find>d__0.#System.IDisposable.Dispose()",
    Justification = "[GeneratedCode] REVIEW: False positive.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.ConcurrentFileFinder+<Find>d__0.#System.IDisposable.Dispose()",
    Justification = "[GeneratedCode] REVIEW: False positive.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Narvalo.Strings_Common",
    Justification = "[REVIEW] False positive.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Narvalo.Strings_Common.#Culture",
    Justification = "[REVIEW] False positive.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Narvalo.Strings_Common.#Culture",
    Justification = "[REVIEW] False positive.")]
