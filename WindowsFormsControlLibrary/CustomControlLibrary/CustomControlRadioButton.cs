using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlRadioButton : Control {
        #region Public Events
        [Browsable(true)]
        [Category("Radio Button")]
        [Description("The checked changed.")]
        public event RadioButtonCheckedChangedEventHandler OnCheckedChanged;
        public delegate void RadioButtonCheckedChangedEventHandler(object Sender, RadioButtonCheckedChangedEventArgs ButtonValueChangedEventArgs);
        private void RaiseRadioButtonCheckedChangedEvent(Boolean Checked) { if (OnCheckedChanged == null) return; var eventArgs = new RadioButtonCheckedChangedEventArgs(Checked); OnCheckedChanged(this, eventArgs); }
        #endregion

        #region Members
        private bool IsFocused = false;
        private RadioButtonDef TheRadioButton = new RadioButtonDef(false);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Radio Button", Color.Black, true),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false)
        };

        private FontBound.BoundDef TheFontBound = new FontBound.BoundDef();
        #endregion

        #region Hidden, Overridden Inherited
        public new Boolean AllowDrop { get { return false; } set { } }
        public new Boolean AutoSize { get { return false; } set { } }
        public new Boolean ForeColor { get { return false; } set { } }
        public new Boolean ImeMode { get { return false; } set { } }
        public override System.Drawing.Color BackColor {
            get { return base.BackColor; }
            set {
                base.BackColor = value;
                IsBackgroundDrawing = true;
                Refresh();
            }
        }
        public override System.Drawing.Font Font {
            get { return base.Font; }
            set {
                base.Font = value;
                IsBackgroundDrawing = true;
                Refresh();
            }
        }
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout {
            get { return base.BackgroundImageLayout; }
            set {
                base.BackgroundImageLayout = value;
                IsBackgroundDrawing = true;
                Refresh();
            }
        }
        #endregion

        #region Constructors
        public CustomControlRadioButton() {
            InitializeComponent();
            this.SetStyle(
                            ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.OptimizedDoubleBuffer |
                            ControlStyles.DoubleBuffer |
                            ControlStyles.ResizeRedraw |
                            ControlStyles.Selectable,
                            true
                         );

            TheFontBound = FontBound.Find(Font);
        }
        #endregion

        #region Public Properties
        #region Radio Button
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button"),
        System.ComponentModel.Description("The Checked value.")]
        public Boolean Checked {
            get {
                return TheRadioButton.Checked;
            }
            set {
                if (TheRadioButton.Checked != value) {
                    TheRadioButton.Checked = value;
                    if (this.DesignMode)
                        IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Captions
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 1]"),
        System.ComponentModel.Description("The color of the caption text.")]
        private Color Caption1Color {
            get {
                return TheCaptions[0].ForeColor;
            }
            set {
                if (TheCaptions[0].ForeColor != value) {
                    TheCaptions[0].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 1]"),
        System.ComponentModel.Description("The text of the caption.")]
        public String Caption1Text {
            get {
                return TheCaptions[0].Text;
            }
            set {
                if (TheCaptions[0].Text != value) {
                    TheCaptions[0].Text = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 1]"),
        System.ComponentModel.Description("The position of the caption.")]
        public Point Caption1Position {
            get {
                return TheCaptions[0].Position;
            }
            set {
                if (TheCaptions[0].Position != value) {
                    TheCaptions[0].Position = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 1]"),
        System.ComponentModel.Description("The visibility of the caption.")]
        public Boolean Caption1Visible {
            get {
                return TheCaptions[0].Visible;
            }
            set {
                if (TheCaptions[0].Visible != value) {
                    TheCaptions[0].Visible = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 2]"),
        System.ComponentModel.Description("The color of the caption text.")]
        private Color Caption2Color {
            get {
                return TheCaptions[1].ForeColor;
            }
            set {
                if (TheCaptions[1].ForeColor != value) {
                    TheCaptions[1].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 2]"),
        System.ComponentModel.Description("The text of the caption.")]
        public String Caption2Text {
            get {
                return TheCaptions[1].Text;
            }
            set {
                if (TheCaptions[1].Text != value) {
                    TheCaptions[1].Text = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 2]"),
        System.ComponentModel.Description("The position of the caption.")]
        public Point Caption2Position {
            get {
                return TheCaptions[1].Position;
            }
            set {
                if (TheCaptions[1].Position != value) {
                    TheCaptions[1].Position = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 2]"),
        System.ComponentModel.Description("The visibility of the caption.")]
        public Boolean Caption2Visible {
            get {
                return TheCaptions[1].Visible;
            }
            set {
                if (TheCaptions[1].Visible != value) {
                    TheCaptions[1].Visible = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption3 ]"),
        System.ComponentModel.Description("The color of the caption text.")]
        private Color Caption3Color {
            get {
                return TheCaptions[2].ForeColor;
            }
            set {
                if (TheCaptions[2].ForeColor != value) {
                    TheCaptions[2].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 3]"),
        System.ComponentModel.Description("The text of the caption.")]
        public String Caption3Text {
            get {
                return TheCaptions[2].Text;
            }
            set {
                if (TheCaptions[2].Text != value) {
                    TheCaptions[2].Text = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 3]"),
        System.ComponentModel.Description("The position of the caption.")]
        public Point Caption3Position {
            get {
                return TheCaptions[2].Position;
            }
            set {
                if (TheCaptions[2].Position != value) {
                    TheCaptions[2].Position = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 3]"),
        System.ComponentModel.Description("The visibility of the caption.")]
        public Boolean Caption3Visible {
            get {
                return TheCaptions[2].Visible;
            }
            set {
                if (TheCaptions[2].Visible != value) {
                    TheCaptions[2].Visible = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 4]"),
        System.ComponentModel.Description("The color of the caption text.")]
        private Color Caption4Color {
            get {
                return TheCaptions[3].ForeColor;
            }
            set {
                if (TheCaptions[3].ForeColor != value) {
                    TheCaptions[3].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 4]"),
        System.ComponentModel.Description("The text of the caption.")]
        public String Caption4Text {
            get {
                return TheCaptions[3].Text;
            }
            set {
                if (TheCaptions[3].Text != value) {
                    TheCaptions[3].Text = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 4]"),
        System.ComponentModel.Description("The position of the caption.")]
        public Point Caption4Position {
            get {
                return TheCaptions[3].Position;
            }
            set {
                if (TheCaptions[3].Position != value) {
                    TheCaptions[3].Position = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 4]"),
        System.ComponentModel.Description("The visibility of the caption.")]
        public Boolean Caption4Visible {
            get {
                return TheCaptions[3].Visible;
            }
            set {
                if (TheCaptions[3].Visible != value) {
                    TheCaptions[3].Visible = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 5]"),
        System.ComponentModel.Description("The color of the caption text.")]
        private Color Caption5Color {
            get {
                return TheCaptions[4].ForeColor;
            }
            set {
                if (TheCaptions[4].ForeColor != value) {
                    TheCaptions[4].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 5]"),
        System.ComponentModel.Description("The text of the caption.")]
        public String Caption5Text {
            get {
                return TheCaptions[4].Text;
            }
            set {
                if (TheCaptions[4].Text != value) {
                    TheCaptions[4].Text = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 5]"),
        System.ComponentModel.Description("The position of the caption.")]
        public Point Caption5Position {
            get {
                return TheCaptions[4].Position;
            }
            set {
                if (TheCaptions[4].Position != value) {
                    TheCaptions[4].Position = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button [Caption 5]"),
        System.ComponentModel.Description("The visibility of the caption.")]
        public Boolean Caption5Visible {
            get {
                return TheCaptions[4].Visible;
            }
            set {
                if (TheCaptions[4].Visible != value) {
                    TheCaptions[4].Visible = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion
        #endregion

        #region Protected Overrides
        protected override void OnEnter(EventArgs e) {
            this.IsFocused = true;
            this.Refresh();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e) {
            this.IsFocused = false;
            this.Refresh();
            base.OnLeave(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent) { }
        protected override void OnResize(EventArgs e) {
            IsBackgroundDrawing = true;
            Refresh();
        }

        private Boolean IsBackgroundDrawing = true;
        protected override void OnPaint(PaintEventArgs PaintEventArgs) {
            base.OnPaint(PaintEventArgs);

            if ((Width < 10) || (Height < 10))
                return;

            if (!IsBackgroundDrawing)
                return;

            using (var bitmap = new Bitmap(Width, Height, PaintEventArgs.Graphics))
            using (var graphics = Graphics.FromImage(bitmap)) {
                graphics.RenderBackgroundImage(ClientRectangle, BackColor, Width, Height, BackgroundImageLayout, BackgroundImage);

                var rectangle = new Rectangle(
                                                Math.Abs(ClientRectangle.X + ClientRectangle.Width - ClientRectangle.Height),
                                                ClientRectangle.Y,
                                                ClientRectangle.Height,
                                                ClientRectangle.Height
                                             ).Deflate(1);
                
                var depthRaised = (Single)3;
                var depthDepressed = (Single)4;

                if (TheRadioButton.Checked) {
                    if (IsFocused)
                        graphics.RenderFocusedDepressedCircularButton(rectangle, BackColor, depthDepressed);
                    else
                        graphics.RenderNonFocusedDepressedCircularButton(rectangle, BackColor, depthDepressed);
                } else {
                    if (IsFocused)
                        graphics.RenderFocusedRaisedCircularButton(rectangle, BackColor, depthRaised);
                    else
                        graphics.RenderNonFocusedRaisedCircularButton(rectangle, BackColor, depthRaised);
                }

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion

        #region Private Event Handlers
        protected override void OnClick(EventArgs e) {
            if (TheRadioButton.Checked)
                TheRadioButton.Checked = false;
            else
                TheRadioButton.Checked = true;

            RaiseRadioButtonCheckedChangedEvent(TheRadioButton.Checked);
            Invalidate();
        }
        #endregion
    }
    public class RadioButtonCheckedChangedEventArgs {
        internal RadioButtonCheckedChangedEventArgs(Boolean Checked) {
            this.Checked = Checked;
        }
        public Boolean Checked { get; private set; }
    }
}
