using System;

namespace WindowsFormsControlLibrary {
    internal class CircularSignalDef {
        private Boolean TheSignaledValue = false;
        public CircularSignalDef(Boolean Checked) {
            this.Signaled = Checked;
        }
        public Boolean Signaled {
            get { return TheSignaledValue; }
            set { TheSignaledValue = value; }
        }
    }
}
