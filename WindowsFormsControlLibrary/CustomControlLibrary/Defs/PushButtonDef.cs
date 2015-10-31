using System;

namespace WindowsFormsControlLibrary {
    internal class PushButtonDef {
        private Boolean ThePressedValue = false;
        public PushButtonDef(Boolean Pressed) {
            this.Pressed = Pressed;
        }
        public Boolean Pressed {
            get { return ThePressedValue; }
            set { ThePressedValue = value; }
        }
    }
}
