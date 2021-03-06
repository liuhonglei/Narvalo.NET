﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Reflection;

    using Narvalo.Properties;

    public static class ConvertTo
    {
        public static TEnum? Enum<TEnum>(object value) where TEnum : struct
        {
            var type = typeof(TEnum);

            if (type.GetTypeInfo().GetCustomAttribute<FlagsAttribute>(inherit: false) != null)
            {
                // Does not work consistently for Flags enums:
                // http://msdn.microsoft.com/en-us/library/system.enum.isdefined.aspx
                throw new NotSupportedException(Strings.NotSupported_TypeIsNotFlagsEnum);
            }

            if (System.Enum.IsDefined(type, value))
            {
                return (TEnum)System.Enum.ToObject(type, value);
            }
            else
            {
                return null;
            }
        }
    }
}
