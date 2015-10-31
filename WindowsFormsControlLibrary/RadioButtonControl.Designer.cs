namespace WindowsFormsControlLibrary {

    partial class RadioButtonControl {
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
            this.customControlRadialButton1 = new WindowsFormsControlLibrary.CustomControlRadioButton();
            this.SuspendLayout();
            // 
            // customControlRadialButton1
            // 
            this.customControlRadialButton1.Checked = true;
            this.customControlRadialButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlRadialButton1.Location = new System.Drawing.Point(0, 0);
            this.customControlRadialButton1.Name = "customControlRadialButton1";
            this.customControlRadialButton1.Size = new System.Drawing.Size(131, 59);
            this.customControlRadialButton1.TabIndex = 0;
            this.customControlRadialButton1.Text = "customControlRadialButton1";
            // 
            // RadioButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlRadialButton1);
            this.Name = "RadioButtonControl";
            this.Size = new System.Drawing.Size(131, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlRadioButton customControlRadialButton1;









    }
}
