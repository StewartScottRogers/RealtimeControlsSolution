using System;

namespace WindowsFormsControlLibrary {
    internal class RadioButtonDef {
        private Boolean TheCheckedValue = false;
        public RadioButtonDef(Boolean Checked) {
            this.Checked = Checked;
        }
        public Boolean Checked {
            get { return TheCheckedValue; }
            set { TheCheckedValue = value; }
        }
    }
}
