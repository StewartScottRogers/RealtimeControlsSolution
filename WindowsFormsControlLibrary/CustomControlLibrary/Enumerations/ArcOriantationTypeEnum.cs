using System;
using System.ComponentModel;
using System.Globalization;

namespace WindowsFormsControlLibrary {
    internal class ArcOriantationTypeEnumConverter : EnumConverter {
        public ArcOriantationTypeEnumConverter()
            : base(typeof(ArcOriantationTypeEnum)) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType) {
            return ((ArcOriantationTypeEnum)value).ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            return ((String)value).ToEnum<NeedleTypeEnum>();
        }
    }

    public enum ArcOriantationTypeEnum : int {
        Horizontal = 0,
        Wrapped = 1,
    }
}
