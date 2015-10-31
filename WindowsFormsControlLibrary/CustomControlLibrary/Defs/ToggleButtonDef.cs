using System;

namespace WindowsFormsControlLibrary {
    internal class ToggleButtonDef {
        private Boolean ThePressedValue = false;
        public ToggleButtonDef(Boolean Pressed) {
            this.Pressed = Pressed;
        }
        public Boolean Pressed {
            get { return ThePressedValue; }
            set { ThePressedValue = value; }
        }
    }
}
