﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Narvalo.Linq;
    using Narvalo.Properties;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [DebuggerTypeProxy(typeof(Outcome<>.DebugView))]
    public partial struct Outcome<T>
        : IEquatable<Outcome<T>>, Internal.IResult<T, string>, Internal.Iterable<T>
    {
        private readonly string _error;
        private readonly T _value;

        private Outcome(T value)
        {
            _error = String.Empty;
            _value = value;
            IsError = false;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "isSuccess", Justification = "[Intentionally] Only added to disambiguate the two ctors when T = string.")]
        private Outcome(string error, bool isSuccess)
        {
            Debug.Assert(error != null);

            _error = error;
            _value = default(T);
            IsError = true;
        }

        public void Deconstruct(out bool succeed, out T value, out string error)
        {
            succeed = IsSuccess;
            value = _value;
            error = _error;
        }

        /// <summary>
        /// Gets a value indicating whether the object is the result of an unsuccessful computation.
        /// </summary>
        /// <value>true if the outcome was unsuccessful; otherwise false.</value>
        public bool IsError { get; }

        /// <summary>
        /// Gets a value indicating whether the object is the result of a successful computation.
        /// </summary>
        /// <value>true if the outcome was successful; otherwise false.</value>
        public bool IsSuccess => !IsError;

        /// <summary>
        /// Obtains the enclosed value if any.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsSuccess"/> is true.</remarks>
        internal T Value { get { Debug.Assert(IsSuccess); return _value; } }

        /// <summary>
        /// Obtains the captured exception state.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsError"/> is true.</remarks>
        internal string Error { get { Debug.Assert(IsError); return _error; } }

        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[Intentionally] Debugger-only code.")]
        private string DebuggerDisplay => IsError ? "Error" : "Success";

        /// <summary>
        /// Obtains the enclosed value if any; otherwise the default value of the type T.
        /// </summary>
        public T ValueOrDefault() => _value;

        public Maybe<T> ValueOrNone() => IsError ? Maybe<T>.None : Maybe.Of(Value);

        /// <summary>
        /// Returns the enclosed value if any; otherwise <paramref name="other"/>.
        /// </summary>
        /// <param name="other">A default value to be used if if there is no underlying value.</param>
        public T ValueOrElse(T other) => IsError ? other : Value;

        public T ValueOrElse(Func<T> valueFactory)
        {
            Require.NotNull(valueFactory, nameof(valueFactory));

            return IsError ? valueFactory() : Value;
        }

        public T ValueOrThrow() => IsError ? throw new InvalidOperationException(Error) : Value;

        public T ValueOrThrow(Func<string, Exception> exceptionFactory)
        {
            Require.NotNull(exceptionFactory, nameof(exceptionFactory));

            if (IsError) { throw exceptionFactory(Error); }
            return Value;
        }

        public override string ToString()
            => IsError ? "Error(" + Error + ")" : "Success(" + Value?.ToString() + ")";

        /// <summary>
        /// Represents a debugger type proxy for <see cref="Outcome{T}"/>.
        /// </summary>
        /// <remarks>Ensure that <see cref="Outcome{T}.Value"/> and <see cref="Outcome{T}.Error"/>
        /// do not throw in the debugger for DEBUG builds.</remarks>
        [ExcludeFromCodeCoverage]
        private sealed class DebugView
        {
            private readonly Outcome<T> _inner;

            public DebugView(Outcome<T> inner) => _inner = inner;

            public bool IsSuccess => _inner.IsSuccess;

            public T Value => _inner._value;

            public string Error => _inner._error;
        }
    }

    // Conversions operators.
    public partial struct Outcome<T>
    {
        public T ToValue()
        {
            if (IsError) { throw new InvalidCastException(Strings.InvalidConversionToValue); }
            return Value;
        }

        public Maybe<T> ToMaybe() => ValueOrNone();

        public Result<T, string> ToResult()
            => IsError ? Result<T, string>.FromError(Error) : Result<T, string>.Of(Value);

        public static explicit operator T(Outcome<T> value) => value.ToValue();

        public static explicit operator Outcome<T>(T value) => η(value);
    }

    // Core Monad methods.
    public partial struct Outcome<T>
    {
        public Outcome<TResult> Bind<TResult>(Func<T, Outcome<TResult>> binder)
        {
            Require.NotNull(binder, nameof(binder));

            return IsError ? Outcome<TResult>.FromError(Error) : binder(Value);
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Outcome<T> η(T value) => new Outcome<T>(value);

        // NB: This method is normally internal, but Outcome<T>.FromError() is more readable
        // than Outcome.FromError<T>() - no type inference.
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "[Intentionally] A static method in a static class won't help.")]
        public static Outcome<T> FromError(string error)
        {
            Require.NotNullOrEmpty(error, nameof(error));

            return new Outcome<T>(error, false);
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Outcome<T> μ(Outcome<Outcome<T>> square)
            => square.IsError ? FromError(square.Error) : square.Value;
    }

    // Query Expression Pattern.
    public partial struct Outcome<T>
    {
        // Outcome<T> is not a MonadOr but we can still construct a Where() operator.
        // It is weird that it works (filter is not a predicate) but it does.
        public Outcome<T> Where(Func<T, Outcome> filter)
        {
            Require.NotNull(filter, nameof(filter));

            return Bind(val => filter(val).ReplaceBy(val));
        }
    }

    // Implements the Internal.IEither<T, string> interface.
    public partial struct Outcome<T>
    {
        public bool Contains(T value)
        {
            if (IsError) { return false; }
            return EqualityComparer<T>.Default.Equals(Value, value);
        }

        public bool Contains(T value, IEqualityComparer<T> comparer)
        {
            if (IsError) { return false; }
            return (comparer ?? EqualityComparer<T>.Default).Equals(Value, value);
        }

        public TResult Match<TResult>(Func<T, TResult> caseSuccess, Func<string, TResult> caseError)
        {
            Require.NotNull(caseSuccess, nameof(caseSuccess));
            Require.NotNull(caseError, nameof(caseError));

            return IsError ? caseError(Error) : caseSuccess(Value);
        }

        public void Do(Action<T> onSuccess, Action<string> onError)
        {
            Require.NotNull(onSuccess, nameof(onSuccess));
            Require.NotNull(onError, nameof(onError));

            if (IsError) { onError(Error); } else { onSuccess(Value); }
        }

        public bool OnSuccess(Action<T> action)
        {
            Require.NotNull(action, nameof(action));

            if (IsSuccess) { action(Value); return true; }
            return false;
        }

        public bool OnError(Action<string> action)
        {
            Require.NotNull(action, nameof(action));

            if (IsError) { action(Error); return true; }
            return false;
        }

        #region Publicly hidden methods.

        [ExcludeFromCodeCoverage]
        bool Internal.ISecondaryContainer<string>.Contains(string value)
            => throw new NotSupportedException();

        [ExcludeFromCodeCoverage]
        bool Internal.ISecondaryContainer<string>.Contains(string value, IEqualityComparer<string> comparer)
            => throw new NotSupportedException();

        // Alias for OnSuccess().
        [ExcludeFromCodeCoverage]
        bool Internal.IContainer<T>.Do(Action<T> action) => OnSuccess(action);

        // Alias for OnError().
        [ExcludeFromCodeCoverage]
        bool Internal.ISecondaryContainer<string>.Do(Action<string> action)
            => OnError(action);

        #endregion
    }

    // Implements the Internal.Iterable<T> interface.
    public partial struct Outcome<T>
    {
        public IEnumerable<T> ToEnumerable() => IsError ? Enumerable.Empty<T>() : Sequence.Return(Value);

        public IEnumerator<T> GetEnumerator() => ToEnumerable().GetEnumerator();
    }

    // Implements the IEquatable<Outcome<T>> interface.
    public partial struct Outcome<T>
    {
        public static bool operator ==(Outcome<T> left, Outcome<T> right) => left.Equals(right);

        public static bool operator !=(Outcome<T> left, Outcome<T> right) => !left.Equals(right);

        public bool Equals(Outcome<T> other)
        {
            if (IsError) { return other.IsError && Error == other.Error; }
            return other.IsSuccess && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public bool Equals(Outcome<T> other, IEqualityComparer<T> comparer)
        {
            if (IsError) { return other.IsError && Error == other.Error;  }
            return other.IsSuccess
                && (comparer ?? EqualityComparer<T>.Default).Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
            => (obj is Outcome<T>) && Equals((Outcome<T>)obj);

        public bool Equals(object other, IEqualityComparer<T> comparer)
            => (other is Outcome<T>) && Equals((Outcome<T>)other, comparer);

        public override int GetHashCode()
            // NB: _error is never null.
            => HashCodeHelpers.Combine(_value?.GetHashCode() ?? 0, _error.GetHashCode());

        public int GetHashCode(IEqualityComparer<T> comparer)
        {
            // NB: _error is never null.
            return HashCodeHelpers.Combine(
                (comparer ?? EqualityComparer<T>.Default).GetHashCode(_value),
                _error.GetHashCode());
        }
    }
}
