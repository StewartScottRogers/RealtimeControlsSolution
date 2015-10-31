namespace WindowsFormsControlLibrary {

    partial class ToggleButtonControl {
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
            this.customControlToggleButton1 = new WindowsFormsControlLibrary.CustomControlToggleButton();
            this.SuspendLayout();
            // 
            // customControlToggleButton1
            // 
            this.customControlToggleButton1.Caption1Position = new System.Drawing.Point(10, 10);
            this.customControlToggleButton1.Caption1Text = "Toggle Button";
            this.customControlToggleButton1.Caption1Visible = true;
            this.customControlToggleButton1.Caption2Position = new System.Drawing.Point(10, 10);
            this.customControlToggleButton1.Caption2Text = "";
            this.customControlToggleButton1.Caption2Visible = false;
            this.customControlToggleButton1.Caption3Position = new System.Drawing.Point(10, 10);
            this.customControlToggleButton1.Caption3Text = "";
            this.customControlToggleButton1.Caption3Visible = false;
            this.customControlToggleButton1.Caption4Position = new System.Drawing.Point(10, 10);
            this.customControlToggleButton1.Caption4Text = "";
            this.customControlToggleButton1.Caption4Visible = false;
            this.customControlToggleButton1.Caption5Position = new System.Drawing.Point(10, 10);
            this.customControlToggleButton1.Caption5Text = "";
            this.customControlToggleButton1.Caption5Visible = false;
            this.customControlToggleButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlToggleButton1.Location = new System.Drawing.Point(0, 0);
            this.customControlToggleButton1.Name = "customControlToggleButton1";
            this.customControlToggleButton1.Size = new System.Drawing.Size(131, 59);
            this.customControlToggleButton1.TabIndex = 0;
            this.customControlToggleButton1.Text = "customControlToggleButton1";
            this.customControlToggleButton1.OnClickedSelectionOne += new WindowsFormsControlLibrary.CustomControlToggleButton.ToggleButtonSelectionOneClickedEventHandler(this.customControlToggleButton1_OnClickedSelectionOne);
            // 
            // ToggleButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlToggleButton1);
            this.Name = "ToggleButtonControl";
            this.Size = new System.Drawing.Size(131, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlToggleButton customControlToggleButton1;











    }
}
