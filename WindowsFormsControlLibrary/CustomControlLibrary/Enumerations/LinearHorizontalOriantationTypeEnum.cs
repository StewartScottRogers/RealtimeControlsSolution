using System;
using System.ComponentModel;
using System.Globalization;

namespace WindowsFormsControlLibrary {
    internal class LinearHorizontalOriantationTypeEnumConverter : EnumConverter {
        public LinearHorizontalOriantationTypeEnumConverter()
            : base(typeof(LinearHorizontalOriantationTypeEnum)) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType) {
            return ((LinearHorizontalOriantationTypeEnum)value).ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            return ((String)value).ToEnum<NeedleTypeEnum>();
        }
    }

    public enum LinearHorizontalOriantationTypeEnum : int {
        Bottom = 0,
        Top = 1,
    }
}
