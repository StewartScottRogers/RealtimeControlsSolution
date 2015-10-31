using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        private void radialDialControl1_DialValueChanged(float Value) {
            arcGuageControl1.GuageValue = Value;
            verticalGuageControl1.GuageValue = Value;
            horizontalGuageControl1.GuageValue = Value;
        }
        private void pushButtonControl1_OnClicked(object Sender) {
            this.radialButtonControl1.Checked = false;
            this.radialButtonControl2.Checked = false;
            this.radialButtonControl3.Checked = false;
        }
    }
}
