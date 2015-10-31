namespace WindowsFormsApplication {
    partial class MainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pushButtonControl1 = new WindowsFormsControlLibrary.PushButtonControl();
            this.radialButtonControl3 = new WindowsFormsControlLibrary.RadioButtonControl();
            this.radialButtonControl2 = new WindowsFormsControlLibrary.RadioButtonControl();
            this.radialButtonControl1 = new WindowsFormsControlLibrary.RadioButtonControl();
            this.radialDialControl1 = new WindowsFormsControlLibrary.RadialDialControl();
            this.linePlotter1 = new WindowsFormsControlLibrary.LinePlotterControl();
            this.horizontalGuageControl1 = new WindowsFormsControlLibrary.HorizontalGuageControl();
            this.verticalGuageControl1 = new WindowsFormsControlLibrary.VerticalGuageControl();
            this.arcGuageControl1 = new WindowsFormsControlLibrary.RadialGuageControl();
            this.circularSignalControl1 = new WindowsFormsControlLibrary.CircularSignalControl();
            this.circularSignalControl2 = new WindowsFormsControlLibrary.CircularSignalControl();
            this.circularSignalControl3 = new WindowsFormsControlLibrary.CircularSignalControl();
            this.toggleButtonControl1 = new WindowsFormsControlLibrary.ToggleButtonControl();
            this.SuspendLayout();
            // 
            // pushButtonControl1
            // 
            this.pushButtonControl1.Caption = "Push Button";
            this.pushButtonControl1.Location = new System.Drawing.Point(902, 39);
            this.pushButtonControl1.Name = "pushButtonControl1";
            this.pushButtonControl1.Size = new System.Drawing.Size(131, 59);
            this.pushButtonControl1.TabIndex = 27;
            this.pushButtonControl1.OnClicked += new WindowsFormsControlLibrary.PushButtonControl.PushButtonClickedEventHandler(this.pushButtonControl1_OnClicked);
            // 
            // radialButtonControl3
            // 
            this.radialButtonControl3.Caption = "Radio Button";
            this.radialButtonControl3.Checked = true;
            this.radialButtonControl3.Location = new System.Drawing.Point(12, 589);
            this.radialButtonControl3.Name = "radialButtonControl3";
            this.radialButtonControl3.Size = new System.Drawing.Size(137, 59);
            this.radialButtonControl3.TabIndex = 26;
            // 
            // radialButtonControl2
            // 
            this.radialButtonControl2.Caption = "Radio Button";
            this.radialButtonControl2.Checked = false;
            this.radialButtonControl2.Location = new System.Drawing.Point(12, 524);
            this.radialButtonControl2.Name = "radialButtonControl2";
            this.radialButtonControl2.Size = new System.Drawing.Size(137, 59);
            this.radialButtonControl2.TabIndex = 25;
            // 
            // radialButtonControl1
            // 
            this.radialButtonControl1.Caption = "Radio Button";
            this.radialButtonControl1.Checked = true;
            this.radialButtonControl1.Location = new System.Drawing.Point(12, 459);
            this.radialButtonControl1.Name = "radialButtonControl1";
            this.radialButtonControl1.Size = new System.Drawing.Size(137, 59);
            this.radialButtonControl1.TabIndex = 24;
            // 
            // radialDialControl1
            // 
            this.radialDialControl1.Caption = "Dial";
            this.radialDialControl1.DialMaximumValue = 500F;
            this.radialDialControl1.DialMinimumValue = -400F;
            this.radialDialControl1.DialValue = 0F;
            this.radialDialControl1.Location = new System.Drawing.Point(580, 39);
            this.radialDialControl1.Name = "radialDialControl1";
            this.radialDialControl1.Size = new System.Drawing.Size(206, 191);
            this.radialDialControl1.TabIndex = 23;
            this.radialDialControl1.DialValueChanged += new WindowsFormsControlLibrary.ControlValueChangedEventHandler(this.radialDialControl1_DialValueChanged);
            // 
            // linePlotter1
            // 
            this.linePlotter1.Caption = "Line Plot";
            this.linePlotter1.Location = new System.Drawing.Point(453, 236);
            this.linePlotter1.Name = "linePlotter1";
            this.linePlotter1.Size = new System.Drawing.Size(1053, 479);
            this.linePlotter1.TabIndex = 21;
            // 
            // horizontalGuageControl1
            // 
            this.horizontalGuageControl1.Caption = "Horizontal Guage";
            this.horizontalGuageControl1.GuageValue = 0F;
            this.horizontalGuageControl1.Location = new System.Drawing.Point(109, 1);
            this.horizontalGuageControl1.Name = "horizontalGuageControl1";
            this.horizontalGuageControl1.Size = new System.Drawing.Size(452, 95);
            this.horizontalGuageControl1.TabIndex = 19;
            // 
            // verticalGuageControl1
            // 
            this.verticalGuageControl1.Caption = "Vertical Guage";
            this.verticalGuageControl1.GuageValue = 0F;
            this.verticalGuageControl1.Location = new System.Drawing.Point(0, 1);
            this.verticalGuageControl1.Name = "verticalGuageControl1";
            this.verticalGuageControl1.Size = new System.Drawing.Size(114, 432);
            this.verticalGuageControl1.TabIndex = 18;
            // 
            // arcGuageControl1
            // 
            this.arcGuageControl1.Caption = "Arc Guage";
            this.arcGuageControl1.GuageValue = 0F;
            this.arcGuageControl1.Location = new System.Drawing.Point(164, 138);
            this.arcGuageControl1.Name = "arcGuageControl1";
            this.arcGuageControl1.Size = new System.Drawing.Size(221, 207);
            this.arcGuageControl1.TabIndex = 20;
            // 
            // circularSignalControl1
            // 
            this.circularSignalControl1.Caption = "Circular Signal";
            this.circularSignalControl1.Location = new System.Drawing.Point(224, 459);
            this.circularSignalControl1.Name = "circularSignalControl1";
            this.circularSignalControl1.Signaled = false;
            this.circularSignalControl1.Size = new System.Drawing.Size(132, 31);
            this.circularSignalControl1.TabIndex = 28;
            // 
            // circularSignalControl2
            // 
            this.circularSignalControl2.Caption = "Circular Signal";
            this.circularSignalControl2.Location = new System.Drawing.Point(224, 524);
            this.circularSignalControl2.Name = "circularSignalControl2";
            this.circularSignalControl2.Signaled = false;
            this.circularSignalControl2.Size = new System.Drawing.Size(132, 31);
            this.circularSignalControl2.TabIndex = 29;
            // 
            // circularSignalControl3
            // 
            this.circularSignalControl3.Caption = "Circular Signal";
            this.circularSignalControl3.Location = new System.Drawing.Point(224, 589);
            this.circularSignalControl3.Name = "circularSignalControl3";
            this.circularSignalControl3.Signaled = false;
            this.circularSignalControl3.Size = new System.Drawing.Size(132, 31);
            this.circularSignalControl3.TabIndex = 30;
            // 
            // toggleButtonControl1
            // 
            this.toggleButtonControl1.CaptionSelectionOne = "Toggle Button One";
            this.toggleButtonControl1.CaptionSelectionTwo = "Toggle Button Two";
            this.toggleButtonControl1.Location = new System.Drawing.Point(902, 118);
            this.toggleButtonControl1.Name = "toggleButtonControl1";
            this.toggleButtonControl1.Size = new System.Drawing.Size(131, 59);
            this.toggleButtonControl1.TabIndex = 31;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 741);
            this.Controls.Add(this.toggleButtonControl1);
            this.Controls.Add(this.circularSignalControl3);
            this.Controls.Add(this.circularSignalControl2);
            this.Controls.Add(this.circularSignalControl1);
            this.Controls.Add(this.pushButtonControl1);
            this.Controls.Add(this.radialButtonControl3);
            this.Controls.Add(this.radialButtonControl2);
            this.Controls.Add(this.radialButtonControl1);
            this.Controls.Add(this.radialDialControl1);
            this.Controls.Add(this.linePlotter1);
            this.Controls.Add(this.horizontalGuageControl1);
            this.Controls.Add(this.verticalGuageControl1);
            this.Controls.Add(this.arcGuageControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsControlLibrary.VerticalGuageControl verticalGuageControl1;
        private WindowsFormsControlLibrary.HorizontalGuageControl horizontalGuageControl1;
        private WindowsFormsControlLibrary.RadialGuageControl arcGuageControl1;
        private WindowsFormsControlLibrary.LinePlotterControl linePlotter1;
        private WindowsFormsControlLibrary.RadialDialControl radialDialControl1;
        private WindowsFormsControlLibrary.RadioButtonControl radialButtonControl1;
        private WindowsFormsControlLibrary.RadioButtonControl radialButtonControl2;
        private WindowsFormsControlLibrary.RadioButtonControl radialButtonControl3;
        private WindowsFormsControlLibrary.PushButtonControl pushButtonControl1;
        private WindowsFormsControlLibrary.CircularSignalControl circularSignalControl1;
        private WindowsFormsControlLibrary.CircularSignalControl circularSignalControl2;
        private WindowsFormsControlLibrary.CircularSignalControl circularSignalControl3;
        private WindowsFormsControlLibrary.ToggleButtonControl toggleButtonControl1;








    }
}

