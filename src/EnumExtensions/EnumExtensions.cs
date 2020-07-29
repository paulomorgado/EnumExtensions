using System;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace PauloMorgado.Extensions
{
    public static partial class EnumExtensions
    {
        public static bool HasFlag<TEnum>(this TEnum self, TEnum flag)
            where TEnum : System.Enum
        {
            switch (Unsafe.SizeOf<TEnum>())
            {
                case 1:
                    var byte1 = Unsafe.As<TEnum, byte>(ref self);
                    var byte2 = Unsafe.As<TEnum, byte>(ref flag);
                    return (byte1 & byte2) == byte2;
                case 2:
                    var ushort1 = Unsafe.As<TEnum, ushort>(ref self);
                    var ushort2 = Unsafe.As<TEnum, ushort>(ref flag);
                    return (ushort1 & ushort2) == ushort2;
                case 4:
                    var uint1 = Unsafe.As<TEnum, uint>(ref self);
                    var uint2 = Unsafe.As<TEnum, uint>(ref flag);
                    return (uint1 & uint2) == uint2;
                case 8:
                    var ulong1 = Unsafe.As<TEnum, ulong>(ref self);
                    var ulong2 = Unsafe.As<TEnum, ulong>(ref flag);
                    return (ulong1 & ulong2) == ulong2;
                default:
                    throw new InvalidOperationException($"This operation cannot be performed on type {typeof(TEnum).FullName}");
            }
        }

        public static bool IsDefined<TEnum>(this TEnum value)
            where TEnum : System.Enum
            => Helper<TEnum>.Values.Contains(value);

        public static ImmutableHashSet<TEnum> GetValues<TEnum>()
            where TEnum : System.Enum
            => Helper<TEnum>.Values;

        public static ImmutableHashSet<string> GetNames<TEnum>()
            where TEnum : System.Enum
            => Helper<TEnum>.Names;

        public static string GetName<TEnum>(this TEnum value)
            where TEnum : System.Enum
        {
            _ = Helper<TEnum>.ValueNames.TryGetValue(value, out var name);
            return name;
        }
    }
}
