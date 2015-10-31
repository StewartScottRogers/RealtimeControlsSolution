using System;

namespace WindowsFormsControlLibrary {
    internal class GuageDef {
        private Single TheValue = 0;
        public GuageDef(Single Value, Single MinimumValue, Single MaximumValue) {
            this.Value = Value;
            this.MinimumValue = MinimumValue;
            this.MaximumValue = MaximumValue;
        }
        public Single Value {
            get { return TheValue; }
            set {
                if (value < MinimumValue)
                    TheValue = MinimumValue;
                else if (value > MaximumValue)
                    TheValue = MaximumValue;
                else
                    TheValue = value;
            }
        }
        public Single MinimumValue { get; set; }
        public Single MaximumValue { get; set; }
    }
}
