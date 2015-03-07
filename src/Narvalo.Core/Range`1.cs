﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    public partial struct Range<T> : IEquatable<Range<T>>
        where T : struct, IEquatable<T>, IComparable<T>
    {
        private readonly T _lowerEnd;
        private readonly T _upperEnd;

#if !NO_CCCHECK_SUPPRESSIONS
        [SuppressMessage("Microsoft.Contracts", "RequiresAtCall-!(lowerEnd.CompareTo(upperEnd) > 0)",
            Justification = "[CodeContracts] CCCheck does not seem to be able to prove a Require in conjunction with IComparable<T>.")]
#endif
        public Range(T lowerEnd, T upperEnd)
        {
            // REVIEW: Strict range? Do we allow for equality?
            if (lowerEnd.CompareTo(upperEnd) > 0)
            {
                throw new ArgumentOutOfRangeException("upperEnd", upperEnd, Strings_Core.Range_LowerEndNotLesserThanUpperEnd);
            }

            Contract.EndContractBlock();

            _lowerEnd = lowerEnd;
            _upperEnd = upperEnd;
        }

        public T LowerEnd { get { return _lowerEnd; } }

        public T UpperEnd { get { return _upperEnd; } }

        /// <summary>
        /// Returns <c>true</c> if the value is included in the range. 
        /// </summary>
        /// <remarks>Range borders are included in the comparison.</remarks>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public bool Includes(T value)
        {
            return value.CompareTo(LowerEnd) >= 0
                && value.CompareTo(UpperEnd) <= 0;
        }

        /// <summary>
        /// Returns <c>true</c> if the value is included in the range. 
        /// </summary>
        /// <remarks>Range borders are included in the comparison.</remarks>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool Includes(Range<T> range)
        {
            return range.LowerEnd.CompareTo(LowerEnd) >= 0
                && range.UpperEnd.CompareTo(UpperEnd) <= 0;
        }

        /// <summary />
        public override string ToString()
        {
            return String.Format(
                CultureInfo.InvariantCulture,
                "LowerEnd={0};UpperEnd={1}",
                LowerEnd.ToString(),
                UpperEnd.ToString());
        }
    }

    public partial struct Range<T>
    {
        /// <summary />
        public static bool operator ==(Range<T> left, Range<T> right)
        {
            return left.Equals(right);
        }

        /// <summary />
        public static bool operator !=(Range<T> left, Range<T> right)
        {
            return !left.Equals(right);
        }

        /// <summary />
        public bool Equals(Range<T> other)
        {
            return LowerEnd.Equals(other.LowerEnd)
                && UpperEnd.Equals(other.UpperEnd);
        }

        /// <summary />
        public override bool Equals(object obj)
        {
            if (!(obj is Range<T>))
            {
                return false;
            }

            return Equals((Range<T>)obj);
        }

        /// <summary />
        public override int GetHashCode()
        {
            return LowerEnd.GetHashCode() ^ UpperEnd.GetHashCode();
        }
    }
}