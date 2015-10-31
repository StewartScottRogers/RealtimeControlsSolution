using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary {
    public delegate void ControlValueChangedEventHandler(Single Value);
    internal static class ControlValueChangedEventExtentions {
        public static void RaiseEvent(this  ControlValueChangedEventHandler ControlValueChanged, Single DialValue) { if (ControlValueChanged == null) return; ControlValueChanged(DialValue); }
    }
}
