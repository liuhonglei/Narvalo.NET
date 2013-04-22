﻿namespace Narvalo.Fx.Theory
{
    using System;

    // WARNING: il s'agit d'une implémentation par défaut, pour démonstration.
    public partial class Monad<T>
    {
        readonly T _value;

        Monad(T value)
        {
            _value = value;
        }

        public Monad<X> Bind<X>(Kunc<T, X> kun)
        {
#if MONAD_VIA_MAP_MULTIPLY
            return Monad<X>.μ(Map(kun.AsFunc()));
#else
            // throw new NotImplementedException();
            return kun(_value);
#endif
        }

        // Opération fonctorielle sur les morphismes.
        public Monad<X> Map<X>(Func<T, X> fun)
        {
#if MONAD_VIA_MAP_MULTIPLY
            // throw new NotImplementedException();
            return Monad<X>.η(fun(_value));
#else
            return Bind(_ => Monad<X>.η(fun(_)));
#endif
        }

        // Transformation naturelle "Unité".
        internal static Monad<T> η(T value)
        {
            // throw new NotImplementedException();
            return new Monad<T>(value);
        }

        // Transformation naturelle "Multiplication".
        internal static Monad<T> μ(Monad<Monad<T>> square)
        {
#if MONAD_VIA_MAP_MULTIPLY
            // throw new NotImplementedException();
            return square._value;
#else
            return square.Bind(_ => _);
#endif
        }
    }
}
