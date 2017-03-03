﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    [DebuggerStepThrough]
    public static partial class Check
    {
        /// <remarks>
        /// To be used instead of
        /// <code>Debug.Assert(testCondition);</code>
        /// </remarks>
        [Conditional("DEBUG")]
        public static void True(bool testCondition) => Debug.Assert(testCondition);

        [Conditional("DEBUG")]
        public static void False(bool testCondition) => Debug.Assert(!testCondition);

        [DebuggerHidden]
        public static ControlFlowException Unreachable() => new ControlFlowException();

        /// <summary>
        /// Asserts that a point of execution is unreachable.
        /// </summary>
        /// <example>
        /// <code>
        /// switch (myEnum)
        /// {
        ///     case MyEnum.DefinedValue:
        ///         return "DefinedValue";
        ///     default:
        ///         throw Check.Unreachable("Found a missing case in a switch.");
        /// }
        /// </code>
        /// </example>
        /// <param name="rationale">The error message to use if the point of execution is reached.</param>
        /// <returns>A new instance of the <see cref="ControlFlowException"/> class with the specified error message.</returns>
        [DebuggerHidden]
        public static ControlFlowException Unreachable(string rationale)
            => new ControlFlowException(rationale);

        /// <summary>
        /// Asserts that a point of execution is unreachable.
        /// </summary>
        /// <example>
        /// <code>
        /// switch (myEnum)
        /// {
        ///     case MyEnum.DefinedValue:
        ///         return "DefinedValue";
        ///     default:
        ///         throw Check.Unreachable(new MyException("Found a missing case in a switch."));
        /// }
        /// </code>
        /// </example>
        /// <typeparam name="TException">The type of <paramref name="exception"/>.</typeparam>
        /// <param name="exception">The exception the caller wish to throw back from here.</param>
        /// <returns>The untouched input <paramref name="exception"/>.</returns>
        [DebuggerHidden]
        public static TException Unreachable<TException>(TException exception)
            where TException : Exception
            => exception;
    }

    // Validation helpers.
    public static partial class Check
    {
        /// <summary>
        /// Returns a value indicating whether the specified value only consists of white-space
        /// characters.
        /// </summary>
        /// <remarks>This method returns false if <paramref name="value"/>
        /// is null or empty.</remarks>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the input only consists of white-space characters;
        /// otherwise false.</returns>
        [Pure]
        public static bool IsWhiteSpace(string value)
        {
            if (value == null || value.Length == 0) { return false; }

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a value indicating whether the specified value is empty or only consists
        /// of white-space characters.
        /// </summary>
        /// <remarks>This method returns false if <paramref name="value"/>
        /// is null.</remarks>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the specified value is empty or only consists of
        /// white-space characters; otherwise false.</returns>
        [Pure]
        public static bool IsEmptyOrWhiteSpace(string value)
        {
            if (value == null) { return false; }

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a value indicating whether the specified <paramref name="type"/> is a flags enumeration.
        /// </summary>
        /// <param name="type">The type to test.</param>
        /// <returns>true if the specified <paramref name="type"/> is a flags enumeration;
        /// otherwise false.</returns>
        [Pure]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "[Intentionally] The rule does not apply here.")]
        public static bool IsFlagsEnum(Type type)
        {
            if (type == null) { return false; }

            TypeInfo typeInfo = type.GetTypeInfo();

            return typeInfo != null
                && typeInfo.IsEnum
                && typeInfo.GetCustomAttribute<FlagsAttribute>(inherit: false) != null;
        }
    }
}
