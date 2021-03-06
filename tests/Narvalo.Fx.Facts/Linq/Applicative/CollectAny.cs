﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Linq.Applicative {
    using System;
    using System.Collections.Generic;

    using Narvalo.Applicative;

    using Assert = Narvalo.AssertExtended;

    // CollectAny for Either.
    public partial class EnumerableFacts {
        [t("CollectAny() guards (Either).")]
        public static void CollectAny0a() {
            IEnumerable<Either<int, int>> nil = null;

            Assert.Throws<ArgumentNullException>("source", () => nil.CollectAny());
        }

        [t("CollectAny() uses deferred execution (Either).")]
        public static void CollectAny1a() {
            IEnumerable<Either<int, int>> source = new ThrowingEnumerable<Either<int, int>>();

            var q = Assert.DoesNotThrow(() => source.CollectAny());
            Assert.ThrowsOnNext(q);
        }
    }

    // CollectAny for Fallible.
    public partial class EnumerableFacts {
        [t("CollectAny() guards (Fallible).")]
        public static void CollectAny0b() {
            IEnumerable<Fallible<int>> nil = null;

            Assert.Throws<ArgumentNullException>("source", () => nil.CollectAny());
        }

        [t("CollectAny() uses deferred execution (Fallible).")]
        public static void CollectAny1b() {
            IEnumerable<Fallible<int>> source = new ThrowingEnumerable<Fallible<int>>();

            var q = Assert.DoesNotThrow(() => source.CollectAny());
            Assert.ThrowsOnNext(q);
        }
    }

    // CollectAny for Maybe.
    public partial class EnumerableFacts {
        [t("CollectAny() guards (Maybe).")]
        public static void CollectAny0c() {
            IEnumerable<Maybe<int>> nil = null;

            Assert.Throws<ArgumentNullException>("source", () => nil.CollectAny());
        }

        [t("CollectAny() uses deferred execution (Maybe).")]
        public static void CollectAny1c() {
            IEnumerable<Maybe<int>> source = new ThrowingEnumerable<Maybe<int>>();

            var q = Assert.DoesNotThrow(() => source.CollectAny());
            Assert.ThrowsOnNext(q);
        }
    }

    // CollectAny for Outcome.
    public partial class EnumerableFacts {
        [t("CollectAny() guards (Outcome).")]
        public static void CollectAny0d() {
            IEnumerable<Outcome<int>> nil = null;

            Assert.Throws<ArgumentNullException>("source", () => nil.CollectAny());
        }

        [t("CollectAny() uses deferred execution (Outcome).")]
        public static void CollectAny1d() {
            IEnumerable<Outcome<int>> source = new ThrowingEnumerable<Outcome<int>>();

            var q = Assert.DoesNotThrow(() => source.CollectAny());
            Assert.ThrowsOnNext(q);
        }
    }

    // CollectAny for Result.
    public partial class EnumerableFacts {
        [t("CollectAny() guards (Result).")]
        public static void CollectAny0e() {
            IEnumerable<Result<int, int>> nil = null;

            Assert.Throws<ArgumentNullException>("source", () => nil.CollectAny());
        }

        [t("CollectAny() uses deferred execution (Result).")]
        public static void CollectAny1e() {
            IEnumerable<Result<int, int>> source = new ThrowingEnumerable<Result<int, int>>();

            var q = Assert.DoesNotThrow(() => source.CollectAny());
            Assert.ThrowsOnNext(q);
        }
    }
}
