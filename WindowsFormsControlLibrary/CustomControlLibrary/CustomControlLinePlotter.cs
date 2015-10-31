using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlLinePlotter : Control {
        #region Constants
        private const Single TheVerticalMinimumValue = -400;
        private const Single TheVerticalMaximumValue = 500;
        private const Int32 TheVerticalLength = 400;

        private const Single TheHorizontalMinimumValue = -700;
        private const Single TheHorizontalMaximumValue = 1000;
        private const Int32 TheHorizontalLength = 900;
        #endregion

        #region Members
        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Line Plot", Color.Black, true),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false)
        };

        private GuageDef TheVerticalGuage = new GuageDef(0, TheVerticalMinimumValue, TheVerticalMaximumValue);

        private const Int32 VX40 = 40;
        private const Int32 VY25 = 25;
        private const Int32 VX5 = 5;

        private LinearVerticalBandDef TheLinearVerticalBand = new LinearVerticalBandDef(new Point(VX40, VY25), TheVerticalLength);
        private LinearVerticalScaleLineMinorDef TheLinearVerticalScaleLineMinor = new LinearVerticalScaleLineMinorDef(false, Color.LightGray, new Point(VX40, VY25), TheVerticalLength);
        private LinearVerticalScaleLineIntermediateDef TheLinearVerticalScaleLinesIntermediate = new LinearVerticalScaleLineIntermediateDef(true, Color.LightGray, new Point(VX40, VY25), TheVerticalLength);
        private LinearVerticalScaleLineMajorDef TheLinearVerticalScaleLinesMajor = new LinearVerticalScaleLineMajorDef(true, Color.Gray, new Point(VX40, VY25), TheVerticalLength);
        private LinearVerticalScaleNumberDef TheLinearVerticalScaleNumber = new LinearVerticalScaleNumberDef(new Point(VX5, VY25), TheVerticalLength, LinearVerticalOriantationTypeEnum.Left);

        private GuageDef TheHorizontalGuage = new GuageDef(0, TheHorizontalMinimumValue, TheHorizontalMaximumValue);

        private const Int32 HY440 = TheVerticalLength + 40;
        private const Int32 HY425 = TheVerticalLength + 25;
        private const Int32 HX40 = 40;

        private LinearHorizontalBandDef TheLinearHorizontalBand = new LinearHorizontalBandDef(new Point(HX40, HY425), TheHorizontalLength);
        private LinearHorizontalScaleLineMinorDef TheLinearHorizontalScaleLinesMinor = new LinearHorizontalScaleLineMinorDef(false, Color.LightGray, new Point(HX40, HY425), TheHorizontalLength);
        private LinearHorizontalScaleLineIntermediateDef TheLinearHorizontalScaleLinesIntermediate = new LinearHorizontalScaleLineIntermediateDef(true, Color.LightGray, new Point(HX40, HY425), TheHorizontalLength);
        private LinearHorizontalScaleLineMajorDef TheLinearHorizontalScaleLinesMajor = new LinearHorizontalScaleLineMajorDef(true, Color.Gray, new Point(HX40, HY425), TheHorizontalLength);
        private LinearHorizontalScaleNumberDef TheLinearHorizontalScaleNumber = new LinearHorizontalScaleNumberDef(new Point(HX40, HY440), TheHorizontalLength, LinearHorizontalOriantationTypeEnum.Bottom);

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

        #region Public Properties
        #region Captions
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Line Plotter [Caption 1]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 1]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 1]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 1]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 2]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 2]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 2]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 2]"),
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
        System.ComponentModel.Category("Line Plotter [Caption3 ]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 3]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 3]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 3]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 4]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 4]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 4]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 4]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 5]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 5]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 5]"),
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
        System.ComponentModel.Category("Line Plotter [Caption 5]"),
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

        #region Constructors
        public CustomControlLinePlotter() {
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

        #region Protected Overrides
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

                graphics.RenderVerticalScaleLines(
                                                       ClientRectangle,
                                                       TheLinearVerticalScaleLineMinor.Enabled, TheLinearVerticalScaleLineMinor.Start, TheLinearVerticalScaleLineMinor.Length, TheLinearVerticalScaleLineMinor.TickLength, TheLinearVerticalScaleLineMinor.TickWidth, TheLinearVerticalScaleLineMinor.ForeColor, TheLinearVerticalScaleLineMinor.NumOfTicks,
                                                       TheLinearVerticalScaleLinesIntermediate.Enabled, TheLinearVerticalScaleLinesIntermediate.Start, TheLinearVerticalScaleLinesIntermediate.Length, TheLinearVerticalScaleLinesIntermediate.TickLength, TheLinearVerticalScaleLinesIntermediate.TickWidth, TheLinearVerticalScaleLinesIntermediate.ForeColor,
                                                       TheLinearVerticalScaleLinesMajor.Enabled, TheLinearVerticalScaleLinesMajor.Start, TheLinearVerticalScaleLinesMajor.Length, TheLinearVerticalScaleLinesMajor.TickLength, TheLinearVerticalScaleLinesMajor.TickWidth, TheLinearVerticalScaleLinesMajor.ForeColor, TheLinearVerticalScaleLinesMajor.StepValue,
                                                       TheVerticalGuage.MinimumValue, TheVerticalGuage.MaximumValue,
                                                       TheLinearVerticalScaleNumber.Orientation
                );

                graphics.RenderVerticalGridLines(
                                                       ClientRectangle,
                                                       TheLinearVerticalScaleLineMinor.Enabled, TheLinearVerticalScaleLineMinor.Start, TheLinearVerticalScaleLineMinor.Length, TheLinearHorizontalScaleLinesMinor.Length, TheLinearVerticalScaleLineMinor.TickWidth, TheLinearVerticalScaleLineMinor.ForeColor, TheLinearVerticalScaleLineMinor.NumOfTicks,
                                                       TheLinearVerticalScaleLinesIntermediate.Enabled, TheLinearVerticalScaleLinesIntermediate.Start, TheLinearVerticalScaleLinesIntermediate.Length, TheLinearHorizontalScaleLinesIntermediate.Length, TheLinearVerticalScaleLinesIntermediate.TickWidth, TheLinearVerticalScaleLinesIntermediate.ForeColor,
                                                       TheLinearVerticalScaleLinesMajor.Enabled, TheLinearVerticalScaleLinesMajor.Start, TheLinearVerticalScaleLinesMajor.Length, TheLinearHorizontalScaleLinesMajor.Length, TheLinearVerticalScaleLinesMajor.TickWidth, TheLinearVerticalScaleLinesMajor.ForeColor, TheLinearVerticalScaleLinesMajor.StepValue,
                                                       TheVerticalGuage.MinimumValue, TheVerticalGuage.MaximumValue
                );

                graphics.RenderVerticalBand(ClientRectangle, TheLinearVerticalBand.Start, TheLinearVerticalBand.Length, TheLinearVerticalBand.Width, TheLinearVerticalBand.ForeColor);

                graphics.RenderVerticalScaleNumbers(
                                                        ClientRectangle,
                                                        Font,
                                                        TheLinearVerticalScaleNumber.ForeColor,
                                                        TheFontBound,
                                                        TheLinearVerticalScaleNumber.Format,
                                                        TheVerticalGuage.MinimumValue,
                                                        TheVerticalGuage.MaximumValue,
                                                        TheLinearVerticalScaleLinesMajor.StepValue,
                                                        TheLinearVerticalScaleNumber.Start,
                                                        TheLinearVerticalScaleNumber.Length
                );


                graphics.RenderHorizontalScaleLines(
                                                        ClientRectangle,
                                                        TheLinearHorizontalScaleLinesMinor.Enabled, TheLinearHorizontalScaleLinesMinor.Start, TheLinearHorizontalScaleLinesMinor.Length, TheLinearHorizontalScaleLinesMinor.TickLength, TheLinearHorizontalScaleLinesMinor.TickWidth, TheLinearHorizontalScaleLinesMinor.ForeColor, TheLinearHorizontalScaleLinesMinor.NumOfTicks,
                                                        TheLinearHorizontalScaleLinesIntermediate.Enabled, TheLinearHorizontalScaleLinesIntermediate.Start, TheLinearHorizontalScaleLinesIntermediate.Length, TheLinearHorizontalScaleLinesIntermediate.TickLength, TheLinearHorizontalScaleLinesIntermediate.TickWidth, TheLinearHorizontalScaleLinesIntermediate.ForeColor,
                                                        TheLinearHorizontalScaleLinesMajor.Enabled, TheLinearHorizontalScaleLinesMajor.Start, TheLinearHorizontalScaleLinesMajor.Length, TheLinearHorizontalScaleLinesMajor.TickLength, TheLinearHorizontalScaleLinesMajor.TickWidth, TheLinearHorizontalScaleLinesMajor.ForeColor, TheLinearHorizontalScaleLinesMajor.StepValue,
                                                        TheHorizontalGuage.MinimumValue, TheHorizontalGuage.MaximumValue,
                                                        TheLinearHorizontalScaleNumber.Orientation
                );

                graphics.RenderHorizontalGridLines(
                                                        ClientRectangle,
                                                        TheLinearHorizontalScaleLinesMinor.Enabled, TheLinearHorizontalScaleLinesMinor.Start, TheLinearHorizontalScaleLinesMinor.Length, TheLinearVerticalScaleLineMinor.Length, TheLinearHorizontalScaleLinesMinor.TickWidth, TheLinearHorizontalScaleLinesMinor.ForeColor, TheLinearHorizontalScaleLinesMinor.NumOfTicks,
                                                        TheLinearHorizontalScaleLinesIntermediate.Enabled, TheLinearHorizontalScaleLinesIntermediate.Start, TheLinearHorizontalScaleLinesIntermediate.Length, TheLinearVerticalScaleLinesIntermediate.Length, TheLinearHorizontalScaleLinesIntermediate.TickWidth, TheLinearHorizontalScaleLinesIntermediate.ForeColor,
                                                        TheLinearHorizontalScaleLinesMajor.Enabled, TheLinearHorizontalScaleLinesMajor.Start, TheLinearHorizontalScaleLinesMajor.Length, TheLinearVerticalScaleLinesMajor.Length, TheLinearHorizontalScaleLinesMajor.TickWidth, TheLinearHorizontalScaleLinesMajor.ForeColor, TheLinearHorizontalScaleLinesMajor.StepValue,
                                                        TheHorizontalGuage.MinimumValue, TheHorizontalGuage.MaximumValue
                );

                graphics.RenderHorizontalBand(ClientRectangle, TheLinearHorizontalBand.Start, TheLinearHorizontalBand.Length, TheLinearHorizontalBand.Width, TheLinearHorizontalBand.ForeColor);

                graphics.RenderHorizontalScaleNumbers(
                                                         ClientRectangle,
                                                         Font,
                                                         TheLinearHorizontalScaleNumber.ForeColor,
                                                         TheFontBound,
                                                         TheLinearHorizontalScaleNumber.Format,
                                                         TheHorizontalGuage.MinimumValue,
                                                         TheHorizontalGuage.MaximumValue,
                                                         TheLinearHorizontalScaleLinesMajor.StepValue,
                                                         TheLinearHorizontalScaleNumber.Start,
                                                         TheLinearHorizontalScaleNumber.Length
                );

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion
    }
}
