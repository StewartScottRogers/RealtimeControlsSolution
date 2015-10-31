using System;
using System.ComponentModel;
using System.Globalization;

namespace WindowsFormsControlLibrary {
    internal class NeedleTypeEnumConverter : EnumConverter {
        public NeedleTypeEnumConverter()
            : base(typeof(NeedleTypeEnum)) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType) {
            return ((NeedleTypeEnum)value).ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            return ((String)value).ToEnum<NeedleTypeEnum>();
        }
    }
    public enum NeedleTypeEnum : int {
        Beveled = 0,
        Flat = 1,
    }
}
