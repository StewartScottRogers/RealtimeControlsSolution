using System;
using System.ComponentModel;
using System.Globalization;

namespace WindowsFormsControlLibrary {
    internal class LinearVerticalOriantationTypeEnumConverter : EnumConverter {
        public LinearVerticalOriantationTypeEnumConverter()
            : base(typeof(LinearVerticalOriantationTypeEnum)) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType) {
            return ((LinearVerticalOriantationTypeEnum)value).ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            return ((String)value).ToEnum<NeedleTypeEnum>();
        }
    }

    public enum LinearVerticalOriantationTypeEnum : int {
        Right = 0,
        Left = 1,
    }
}
