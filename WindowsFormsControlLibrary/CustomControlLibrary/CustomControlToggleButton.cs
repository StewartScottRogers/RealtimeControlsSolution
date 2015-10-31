using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlToggleButton : Control {
        #region Private Enums
        private enum SelectionTypes { SelectionOne, SelectionTwo };
        #endregion

        #region Public Events
        [Browsable(true)]
        [Category("Toggle Button Selection one")]
        [Description("The click.")]
        public event ToggleButtonSelectionOneClickedEventHandler OnClickedSelectionOne;
        public delegate void ToggleButtonSelectionOneClickedEventHandler(object Sender, ToggleButtonClickedEventArgs ToggleButtonClickedEventArgs);
        private void RaiseToggleButtonSelectionOneClickedEvent() { if (OnClickedSelectionOne == null) return; var eventArgs = new ToggleButtonClickedEventArgs(); OnClickedSelectionOne(this, eventArgs); }

        [Browsable(true)]
        [Category("Toggle Button Selection one")]
        [Description("The click.")]
        public event ToggleButtonSelectionTwoClickedEventHandler OnClickedSelectionTwo;
        public delegate void ToggleButtonSelectionTwoClickedEventHandler(object Sender, ToggleButtonClickedEventArgs ToggleButtonClickedEventArgs);
        private void RaiseToggleButtonSelectionTwoClickedEvent() { if (OnClickedSelectionTwo == null) return; var eventArgs = new ToggleButtonClickedEventArgs(); OnClickedSelectionTwo(this, eventArgs); }
        #endregion

        #region Members
        private SelectionTypes TheSelectionType = SelectionTypes.SelectionOne;
        private bool IsFocused = false;
        private ExcutionDuration TheExcutionDuration = new ExcutionDuration();

        private ToggleButtonDef TheToggleButton = new ToggleButtonDef(false);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(10, 10), "Push Button One", Color.Black, true),
            new CaptionDef(new Point(10, 10), "Push Button Two", Color.Black, false),
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
        public CustomControlToggleButton() {
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
        #region Captions
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Toggle Button [Caption 1]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 1]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 1]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 1]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 2]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 2]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 2]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 2]"),
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
        System.ComponentModel.Category("Toggle Button [Caption3 ]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 3]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 3]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 3]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 4]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 4]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 4]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 4]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 5]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 5]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 5]"),
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
        System.ComponentModel.Category("Toggle Button [Caption 5]"),
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
            Invalidate();
        }
        protected override void OnLeave(EventArgs e) {
            this.IsFocused = false;
            TheToggleButton.Pressed = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            TheToggleButton.Pressed = true;
            this.Refresh();
            base.OnMouseDown(e);
            TheExcutionDuration.Start();
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

                var rectangle = ClientRectangle.Deflate(1);

                var depthRaised = (Single)3;
                var depthDepressed = (Single)4;

                if (TheToggleButton.Pressed) {
                    if (IsFocused)
                        graphics.RenderFocusedDepressedRectangleButton(rectangle, BackColor, depthDepressed);
                    else
                        graphics.RenderNonFocusedDepressedRectangleButton(rectangle, BackColor, depthDepressed);
                } else {
                    if (IsFocused)
                        graphics.RenderFocusedRaisedRectangleButton(rectangle, BackColor, depthRaised);
                    else
                        graphics.RenderNonFocusedRaisedRectangleButton(rectangle, BackColor, depthRaised);
                }

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion

        #region Private Event Handlers
        protected override void OnClick(EventArgs e) {
            Invalidate();
            if (TheSelectionType == SelectionTypes.SelectionOne) {
                Caption1Visible = false;
                Caption2Visible = true;

                RaiseToggleButtonSelectionTwoClickedEvent();
                TheSelectionType = SelectionTypes.SelectionTwo;
            } else {
                Caption2Visible = false;
                Caption1Visible = true;

                RaiseToggleButtonSelectionOneClickedEvent();
                TheSelectionType = SelectionTypes.SelectionOne;
            }
            while (TheExcutionDuration.ElapsedMilliseconds() <= 300)
                System.Threading.Thread.Sleep(100);

            TheToggleButton.Pressed = false;
            Invalidate();
        }
        #endregion

        #region Private Classes
        public class ExcutionDuration {
            private DateTime TheDateTime = DateTime.Now;
            public void Start() { TheDateTime = DateTime.Now; }
            public double ElapsedMilliseconds() { return DateTime.Now.Subtract(TheDateTime).TotalMilliseconds; }

        }
        #endregion
    }

    public class ToggleButtonClickedEventArgs {
        internal ToggleButtonClickedEventArgs() {

        }
    }
}
