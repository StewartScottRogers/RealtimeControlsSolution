namespace WindowsFormsControlLibrary {

    partial class CircularSignalControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.customControlCircularSignal1 = new WindowsFormsControlLibrary.CustomControlCircularSignal();
            this.SuspendLayout();
            // 
            // customControlCircularSignal1
            // 
            this.customControlCircularSignal1.Caption1Position = new System.Drawing.Point(4, 3);
            this.customControlCircularSignal1.Caption1Text = "Circular Signal";
            this.customControlCircularSignal1.Caption2Position = new System.Drawing.Point(10, 10);
            this.customControlCircularSignal1.Caption2Text = "";
            this.customControlCircularSignal1.Caption3Position = new System.Drawing.Point(10, 10);
            this.customControlCircularSignal1.Caption3Text = "";
            this.customControlCircularSignal1.Caption4Position = new System.Drawing.Point(10, 10);
            this.customControlCircularSignal1.Caption4Text = "";
            this.customControlCircularSignal1.Caption5Position = new System.Drawing.Point(10, 10);
            this.customControlCircularSignal1.Caption5Text = "";
            this.customControlCircularSignal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlCircularSignal1.Location = new System.Drawing.Point(0, 0);
            this.customControlCircularSignal1.Name = "customControlCircularSignal1";
            this.customControlCircularSignal1.Signaled = false;
            this.customControlCircularSignal1.Size = new System.Drawing.Size(132, 31);
            this.customControlCircularSignal1.TabIndex = 0;
            this.customControlCircularSignal1.Text = "customControlCircularSignal1";
            // 
            // CircularSignalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlCircularSignal1);
            this.Name = "CircularSignalControl";
            this.Size = new System.Drawing.Size(132, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlCircularSignal customControlCircularSignal1;


    }
}
