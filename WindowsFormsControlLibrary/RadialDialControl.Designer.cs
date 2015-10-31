namespace WindowsFormsControlLibrary {
   
    partial class RadialDialControl {
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
            this.components = new System.ComponentModel.Container();
            this.timerEvent = new System.Windows.Forms.Timer(this.components);
            this.customControlRadialDial1 = new WindowsFormsControlLibrary.CustomControlRadialDial();
            this.SuspendLayout();
            // 
            // timerEvent
            // 
            this.timerEvent.Interval = 75;
            this.timerEvent.Tick += new System.EventHandler(this.timerEvent_Tick);
            // 
            // customControlRadialDial1
            // 
            this.customControlRadialDial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlRadialDial1.Location = new System.Drawing.Point(0, 0);
            this.customControlRadialDial1.Name = "customControlRadialDial1";
            this.customControlRadialDial1.Size = new System.Drawing.Size(165, 147);
            this.customControlRadialDial1.TabIndex = 0;
            this.customControlRadialDial1.Text = "customControlRadialDial1";
            this.customControlRadialDial1.OnValueChanged += new WindowsFormsControlLibrary.CustomControlRadialDial.DialValueChangedEventHandler(this.customControlRadialDial1_OnValueChanged);
            // 
            // RadialDialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlRadialDial1);
            this.Name = "RadialDialControl";
            this.Size = new System.Drawing.Size(165, 147);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlRadialDial customControlRadialDial1;
        private System.Windows.Forms.Timer timerEvent;








    }
}
