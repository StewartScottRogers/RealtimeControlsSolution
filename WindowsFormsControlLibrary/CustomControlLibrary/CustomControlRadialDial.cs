using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlRadialDial : Control {
        #region Public Events
        [Browsable(true)]
        [Category("Dial")]
        [Description("The Dial value changed.")]
        public event DialValueChangedEventHandler OnValueChanged;
        public delegate void DialValueChangedEventHandler(object Sender, DialValueChangedEventArgs DialValueChangedEventArgs);
        private void RaiseValueChangedEvent(Single DialValue) { if (OnValueChanged == null) return; var eventArgs = new DialValueChangedEventArgs(DialValue); OnValueChanged(this, eventArgs); }
        #endregion

        #region Constants
        private const Single TheMinimumValue = -400;
        private const Single TheMaximumValue = 500;
        #endregion

        #region Members
        private bool IsFocused = false;
        private DialDef TheDial = new DialDef(0, TheMinimumValue, TheMaximumValue);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Dial", Color.Black, true),
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
        public CustomControlRadialDial() {
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
        #region Dial
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Dial"),
        System.ComponentModel.Description("The value.")]
        public Single DialValue {
            get {
                return TheDial.Value;
            }
            set {
                if (TheDial.Value != value) {
                    TheDial.Value = value;
                    if (this.DesignMode)
                        IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Dial"),
        System.ComponentModel.Description("The minimum value.")]
        public Single DialMinimumValue {
            get {
                return TheDial.MinimumValue;
            }
            set {
                if (TheDial.MinimumValue != value) {
                    TheDial.MinimumValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Dial"),
        System.ComponentModel.Description("The maximum value.")]
        public Single DialMaximumValue {
            get {
                return TheDial.MaximumValue;
            }
            set {
                if (TheDial.MaximumValue != value) {
                    TheDial.MaximumValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Captions
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Dial [Caption 1]"),
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
        System.ComponentModel.Category("Dial [Caption 1]"),
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
        System.ComponentModel.Category("Dial [Caption 1]"),
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
        System.ComponentModel.Category("Dial [Caption 1]"),
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
        System.ComponentModel.Category("Dial [Caption 2]"),
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
        System.ComponentModel.Category("Dial [Caption 2]"),
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
        System.ComponentModel.Category("Dial [Caption 2]"),
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
        System.ComponentModel.Category("Dial [Caption 2]"),
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
        System.ComponentModel.Category("Dial [Caption3 ]"),
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
        System.ComponentModel.Category("Dial [Caption 3]"),
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
        System.ComponentModel.Category("Dial [Caption 3]"),
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
        System.ComponentModel.Category("Dial [Caption 3]"),
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
        System.ComponentModel.Category("Dial [Caption 4]"),
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
        System.ComponentModel.Category("Dial [Caption 4]"),
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
        System.ComponentModel.Category("Dial [Caption 4]"),
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
        System.ComponentModel.Category("Dial [Caption 4]"),
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
        System.ComponentModel.Category("Dial [Caption 5]"),
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
        System.ComponentModel.Category("Dial [Caption 5]"),
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
        System.ComponentModel.Category("Dial [Caption 5]"),
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
        System.ComponentModel.Category("Dial [Caption 5]"),
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
        protected override bool IsInputKey(Keys key) {
            switch (key) {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                    return true;
            }
            return base.IsInputKey(key);
        }

        private bool isDialRotating = false;
        private Point originalTouchPoint;
        protected override void OnMouseDown(MouseEventArgs e) {
            originalTouchPoint = new Point(e.X, e.Y);
            if (new Point(e.X, e.Y).IsWithin(ClientRectangle))
                this.isDialRotating = true;
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            if (!this.isDialRotating)
                return;

            var newTouchPoint = new Point(e.X, e.Y);
            var result = DialChangeValue(newTouchPoint, originalTouchPoint);
            if (0 == result)
                return;
            TheDial.Value += result;
            Invalidate();
            RaiseValueChangedEvent(TheDial.Value);
            originalTouchPoint = newTouchPoint;
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            this.isDialRotating = false;
            var newTouchPoint = new Point(e.X, e.Y);
            if (newTouchPoint.IsWithin(ClientRectangle)) {
                var result = DialChangeValue(newTouchPoint, originalTouchPoint);
                if (0 == result)
                    return;
                TheDial.Value += result;
                Invalidate();
                RaiseValueChangedEvent(TheDial.Value);
                originalTouchPoint = newTouchPoint;
            }
        }
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

                var rectangle = ClientRectangle.Deflate(2);
                if (IsFocused)
                    graphics.RenderFocusedRaisedDimple(rectangle, BackColor);
                else
                    graphics.RenderNonFocusedRaisedDimple(rectangle, BackColor);

                RenderThumbDisk(graphics, rectangle, TheDial.Value, BackColor);

                graphics.RenderCaptions(rectangle, Font, TheCaptions);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion

        #region Private Methods
        private static void RenderThumbDisk(Graphics Graphics, Rectangle ClientRectangle, Single Value, Color BackGroundColor, Int32 DiskRadius = 30) {
            var position = ThumbPosition(ClientRectangle, Value, DiskRadius);
            var rectangle = ThumbRectangle(position, DiskRadius);

            Graphics.RenderDepressedDisk(rectangle, BackGroundColor);
        }
        private static Point ThumbPosition(Rectangle Rectangle, Single Value, Int32 DiskRadius) {
            double degree = ((360 * Value / 360) + 135) * Math.PI / 180;

            var point = new Point(0, 0);
            point.X = (int)(Math.Cos(degree) * (Rectangle.Width / 2 - DiskRadius) + Rectangle.X + Rectangle.Width / 2);
            point.Y = (int)(Math.Sin(degree) * (Rectangle.Width / 2 - DiskRadius) + Rectangle.Y + Rectangle.Height / 2);

            return point;
        }
        private static Rectangle ThumbRectangle(Point Position, Int32 Radius) {
            return new Rectangle(Position.X - (Int32)(Radius / 2), Position.Y - (Int32)(Radius / 2), Radius, Radius);
        }
        private Single DialChangeValue(Point NewTouchPoint, Point OriginalTouchPoint) {
            var newValue = DialCurrentValue(NewTouchPoint);
            var originalValue = DialCurrentValue(OriginalTouchPoint);
            var result = newValue - originalValue;
            if (Math.Abs(result) > 180)
                if (result > 0)
                    return 1;
                else
                    return -1;

            System.Diagnostics.Debug.WriteLine("DialChangeValue: " + result);
            return result;
        }
        private Single DialCurrentValue(Point NewTouchPoint) {
            try {
                var centerPoint = new Point(ClientRectangle.X + ClientRectangle.Width / 2, ClientRectangle.Y + ClientRectangle.Height / 2);
                if (NewTouchPoint.X <= centerPoint.X) {
                    var degree = (double)(centerPoint.Y - NewTouchPoint.Y) / (double)(centerPoint.X - NewTouchPoint.X);
                    degree = Math.Atan(degree) * (180 / Math.PI) + 45;
                    return (int)(degree);
                } else {
                    var degree = 225 + (Math.Atan((double)(NewTouchPoint.Y - centerPoint.Y) / (double)(NewTouchPoint.X - centerPoint.X))) * (180 / Math.PI);
                    return (int)(degree);
                }
            } finally {


            }
        }
        #endregion
    }
    public class DialValueChangedEventArgs {
        internal DialValueChangedEventArgs(Single DialValue) {
            this.DialValue = DialValue;
        }
        public Single DialValue { get; private set; }
    }
}
