using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PauloMorgado.Extensions
{
    public static partial class EnumExtensions
    {
        private static class Helper<TEnum>
            where TEnum : System.Enum
        {
            public static readonly ImmutableHashSet<TEnum> Values
                = ImmutableHashSet.Create((TEnum[])Enum.GetValues(typeof(TEnum)));

            public static readonly ImmutableHashSet<string> Names
                = ImmutableHashSet.Create(StringComparer.Ordinal, Enum.GetNames(typeof(TEnum)));

            public static readonly ImmutableDictionary<TEnum, string> ValueNames
                = ImmutableDictionary.CreateRange(Values.Select(v => new KeyValuePair<TEnum, string>(v, Enum.GetName(typeof(TEnum), v))));
        }
    }
}
