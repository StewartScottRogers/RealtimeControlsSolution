namespace WindowsFormsControlLibrary {
    partial class LinePlotterControl {
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
            this.customControlLinePlotter1 = new WindowsFormsControlLibrary.CustomControlLinePlotter();
            this.SuspendLayout();
            // 
            // customControlLinePlotter1
            // 
            this.customControlLinePlotter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControlLinePlotter1.Location = new System.Drawing.Point(0, 0);
            this.customControlLinePlotter1.Name = "customControlLinePlotter1";
            this.customControlLinePlotter1.Size = new System.Drawing.Size(976, 479);
            this.customControlLinePlotter1.TabIndex = 0;
            this.customControlLinePlotter1.Text = "customControlLinePlotter1";
            // 
            // LinePlotterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControlLinePlotter1);
            this.Name = "LinePlotterControl";
            this.Size = new System.Drawing.Size(976, 479);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlLinePlotter customControlLinePlotter1;







    }
}
