﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;

    public partial struct Subcurrency : IEquatable<Subcurrency>
    {
        public Subcurrency(Currency parent, decimal epsilon, string code)
        {
            Parent = parent;
            Epsilon = epsilon;
            Code = code;
        }

        public string Code { get; }

        public decimal Epsilon { get; }

        public Currency Parent { get; }

        public decimal Factor => 1 / Epsilon;
    }

    // Interface IEquatable<SubCurrency>.
    public partial struct Subcurrency
    {
        public static bool operator ==(Subcurrency left, Subcurrency right) => left.Equals(right);

        public static bool operator !=(Subcurrency left, Subcurrency right) => !left.Equals(right);

        /// <inheritdoc cref="IEquatable{T}.Equals" />
        public bool Equals(Subcurrency other)
            => Parent == other.Parent
            && Code == other.Code
            && Epsilon == other.Epsilon;

        /// <inheritdoc cref="Object.Equals(Object)" />
        public override bool Equals(object obj)
        {
            if (!(obj is Subcurrency)) { return false; }

            return Equals((Subcurrency)obj);
        }

        /// <inheritdoc cref="Object.GetHashCode" />
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = 31 * hash + Parent.GetHashCode();
                hash = 31 * hash + Code.GetHashCode();
                hash = 31 * hash + Epsilon.GetHashCode();
                return hash;
            }
        }
    }
}
