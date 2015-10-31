namespace WindowsFormsControlLibrary {

    partial class PushButtonControl {
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
            this.customControlPushButton1 = new WindowsFormsControlLibrary.CustomControlPushButton();
            this.SuspendLayout();
            // 
            // customControlPushButton1
            // 
            this.customControlPushButton1.Caption1Position = new System.Drawing.Point(10, 10);
            this.customControlPushButton1.Caption1Text = "Push Button";
            this.customControlPushButton1.Caption2Position = new System.Drawing.Point(10, 10);
            this.customControlPushButton1.Caption2Text = "";
            this.customControlPushButton1.Caption3Position = new System.Drawing.Point(10, 10);
            this.customControlPushButton1.Caption3Text = "";
            this.customControlPushButton1.Caption4Position = new System.Drawing.Point(10, 10);
            this.customControlPushButton1.Caption4Text = "";
            this.customControlPushButton1.Caption5Position = new System.Drawing.Point(10, 10);
            this.customControlPushButton1.Caption5Text = "";
            this.customControlPushButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlPushButton1.Location = new System.Drawing.Point(0, 0);
            this.customControlPushButton1.Name = "customControlPushButton1";
            this.customControlPushButton1.Size = new System.Drawing.Size(131, 59);
            this.customControlPushButton1.TabIndex = 0;
            this.customControlPushButton1.Text = "customControlPushButton1";
            this.customControlPushButton1.OnClicked += new WindowsFormsControlLibrary.CustomControlPushButton.PushButtonClickedEventHandler(this.customControlPushButton1_OnClicked);
            // 
            // PushButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlPushButton1);
            this.Name = "PushButtonControl";
            this.Size = new System.Drawing.Size(131, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlPushButton customControlPushButton1;











    }
}
