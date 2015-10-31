using System;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormsControlLibrary {
    public static class EnumerationExtention {
        public static TEnum ToEnum<TEnum>(this string value) {
            var enumType = typeof(TEnum);
            if (enumType == typeof(Enum))
                throw new ArgumentException("typeof(TEnum) == Enum", "TEnum");
            if (!(enumType.IsEnum))
                throw new ArgumentException(String.Format("typeof({0}).IsEnum == false", enumType), "TEnum");
            try {
                return (TEnum)Enum.Parse(enumType, value, true);
            } catch {
                foreach (TEnum tEnum in Enumerable<TEnum>.Enumerations())
                    return tEnum;
                throw new ArgumentException("For typeof(TEnum) the value '" + value + "' was not found.", "TEnum");
            }
        }

        public static TEnum ToEnum<TEnum>(this Int32 value) {
            var enumType = typeof(TEnum);
            if (enumType == typeof(Enum))
                throw new ArgumentException("typeof(TEnum) == Enum", "TEnum");
            if (!(enumType.IsEnum))
                throw new ArgumentException(String.Format("typeof({0}).IsEnum == false", enumType), "TEnum");
            try {
                return (TEnum)Enum.ToObject(enumType, value);
            } catch {
                foreach (TEnum tEnum in Enumerable<TEnum>.Enumerations())
                    return tEnum;
                throw new ArgumentException("For typeof(TEnum) the value '" + value + "' was not found.", "TEnum");
            }
        }

        public class Enumerable<TEnum> : IEnumerable<TEnum> {
            public static IEnumerable<TEnum> Enumerations() {
                foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)))
                    yield return tEnum;
            }

            public IEnumerator<TEnum> GetEnumerator() { return (IEnumerator<TEnum>)Enumerable<TEnum>.Enumerations(); }
            IEnumerator IEnumerable.GetEnumerator() { return (IEnumerator<TEnum>)Enumerable<TEnum>.Enumerations(); }
        }
    }


}
