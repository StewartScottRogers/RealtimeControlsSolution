using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlVerticalGauge : Control {
        #region Constants
        private const Single TheMinimumValue = -400;
        private const Single TheMaximumValue = 500;
        private const Int32 TheLength = 400;
        #endregion

        #region Members
        private GuageDef TheGuage = new GuageDef(0, TheMinimumValue, TheMaximumValue);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Vertical Guage", Color.Black, true),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false)
        };

        private LinearVerticalRangeDef[] TheLinearVerticalRanges = new LinearVerticalRangeDef[] { 
            new LinearVerticalRangeDef(true, TheMinimumValue, 200, 4, Color.GreenYellow),
            new LinearVerticalRangeDef(true, 200, 300, 5, Color.Yellow),
            new LinearVerticalRangeDef(true, 300, TheMaximumValue, 6, Color.Red),
            new LinearVerticalRangeDef(false, 0, 0, 0, Color.FromKnownColor(KnownColor.Control)),
            new LinearVerticalRangeDef(false, 0, 0, 0,  Color.FromKnownColor(KnownColor.Control))        
        };

        private LinearVerticalBandDef TheLinearVerticalBand = new LinearVerticalBandDef(new Point(35, 25), TheLength);
        private LinearVerticalScaleLineMinorDef TheLinearVerticalScaleLineMinor = new LinearVerticalScaleLineMinorDef(true, Color.LightGray, new Point(35, 25), TheLength);
        private LinearVerticalScaleLineIntermediateDef TheLinearVerticalScaleLinesIntermediate = new LinearVerticalScaleLineIntermediateDef(true, Color.Gray, new Point(35, 25), TheLength);
        private LinearVerticalScaleLineMajorDef TheLinearVerticalScaleLinesMajor = new LinearVerticalScaleLineMajorDef(true, Color.Black, new Point(35, 25), TheLength);
        private LinearVerticalScaleNumberDef TheLinearVerticalScaleNumber = new LinearVerticalScaleNumberDef(new Point(5, 25), TheLength, LinearVerticalOriantationTypeEnum.Right);
        private LinearVerticalNeedleDef TheLinearVerticalNeedle = new LinearVerticalNeedleDef(new Point(35, 25), TheLength);

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
        public CustomControlVerticalGauge() {
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
        #region Guage
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge"),
        System.ComponentModel.Description("The value.")]
        public Single GuageValue {
            get {
                return TheGuage.Value;
            }
            set {
                if (TheGuage.Value != value) {
                    TheGuage.Value = Math.Min(Math.Max(value, TheGuage.MinimumValue), TheGuage.MaximumValue);
                    if (this.DesignMode)
                        IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge"),
        System.ComponentModel.Description("The minimum value to show on the scale by the needle.")]
        public Single GuageMinimumValue {
            get {
                return TheGuage.MinimumValue;
            }
            set {
                if ((TheGuage.MinimumValue != value)
                && (value < TheGuage.MaximumValue)) {
                    TheGuage.MinimumValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge"),
        System.ComponentModel.Description("The maximum value to show on the scale by the needle.")]
        public Single GuageMaximumValue {
            get {
                return TheGuage.MaximumValue;
            }
            set {
                if ((TheGuage.MaximumValue != value)
                && (value > TheGuage.MinimumValue)) {
                    TheGuage.MaximumValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Captions
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Caption 1]"),
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
        System.ComponentModel.Category("Gauge [Caption 1]"),
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
        System.ComponentModel.Category("Gauge [Caption 1]"),
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
        System.ComponentModel.Category("Gauge [Caption 1]"),
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
        System.ComponentModel.Category("Gauge [Caption 2]"),
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
        System.ComponentModel.Category("Gauge [Caption 2]"),
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
        System.ComponentModel.Category("Gauge [Caption 2]"),
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
        System.ComponentModel.Category("Gauge [Caption 2]"),
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
        System.ComponentModel.Category("Gauge [Caption3 ]"),
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
        System.ComponentModel.Category("Gauge [Caption 3]"),
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
        System.ComponentModel.Category("Gauge [Caption 3]"),
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
        System.ComponentModel.Category("Gauge [Caption 3]"),
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
        System.ComponentModel.Category("Gauge [Caption 4]"),
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
        System.ComponentModel.Category("Gauge [Caption 4]"),
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
        System.ComponentModel.Category("Gauge [Caption 4]"),
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
        System.ComponentModel.Category("Gauge [Caption 4]"),
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
        System.ComponentModel.Category("Gauge [Caption 5]"),
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
        System.ComponentModel.Category("Gauge [Caption 5]"),
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
        System.ComponentModel.Category("Gauge [Caption 5]"),
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
        System.ComponentModel.Category("Gauge [Caption 5]"),
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

        #region Band
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Band]"),
        System.ComponentModel.Description("The color of the band.")]
        public Color VerticalBandForeColor {
            get {
                return TheLinearVerticalBand.ForeColor;
            }
            set {
                if (TheLinearVerticalBand.ForeColor != value) {
                    TheLinearVerticalBand.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Band]"),
        System.ComponentModel.Description("The start point of the band.")]
        public Point VerticalBandStart {
            get {
                return TheLinearVerticalBand.Start;
            }
            set {
                if (TheLinearVerticalBand.Start != value) {
                    TheLinearVerticalBand.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Band]"),
        System.ComponentModel.Description("The Length of the band.")]
        public Int32 VerticalBandLength {
            get {
                return TheLinearVerticalBand.Length;
            }
            set {
                if (TheLinearVerticalBand.Length != value) {
                    TheLinearVerticalBand.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Band]"),
        System.ComponentModel.Description("The width of the band.")]
        public Int32 VerticalBandWidth {
            get {
                return TheLinearVerticalBand.Width;
            }
            set {
                if (TheLinearVerticalBand.Width != value) {
                    TheLinearVerticalBand.Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Intermediate
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("Intermediate scale lines enabled or disabled.")]
        public Boolean VerticalScaleLinesIntermediateEnabled {
            get {
                return TheLinearVerticalScaleLinesIntermediate.Enabled;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.Enabled != value) {
                    TheLinearVerticalScaleLinesIntermediate.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Color VerticalScaleLinesIntermediateTickForeColor {
            get {
                return TheLinearVerticalScaleLinesIntermediate.ForeColor;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.ForeColor != value) {
                    TheLinearVerticalScaleLinesIntermediate.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The start of the intermediate scale lines.")]
        public Point VerticalScaleLinesIntermediateStart {
            get {
                return TheLinearVerticalScaleLinesIntermediate.Start;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.Start != value) {
                    TheLinearVerticalScaleLinesIntermediate.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single VerticalScaleLinesIntermediateLength {
            get {
                return TheLinearVerticalScaleLinesIntermediate.Length;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.Length != value) {
                    TheLinearVerticalScaleLinesIntermediate.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The length of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Single VerticalScaleLinesIntermediateTickLength {
            get {
                return TheLinearVerticalScaleLinesIntermediate.TickLength;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.TickLength != value) {
                    TheLinearVerticalScaleLinesIntermediate.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The width of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Single VerticalScaleLinesIntermediateTickWidth {
            get {
                return TheLinearVerticalScaleLinesIntermediate.TickWidth;
            }
            set {
                if (TheLinearVerticalScaleLinesIntermediate.TickWidth != value) {
                    TheLinearVerticalScaleLinesIntermediate.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Minor
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("Minor scale lines enabled or disabled.")]
        public Boolean VerticalScaleLinesMinorEnabled {
            get {
                return TheLinearVerticalScaleLineMinor.Enabled;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.Enabled != value) {
                    TheLinearVerticalScaleLineMinor.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The number of minor scale lines.")]
        public Int32 VerticalScaleLinesMinorNumOfTicks {
            get {
                return TheLinearVerticalScaleLineMinor.NumOfTicks;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.NumOfTicks != value) {
                    TheLinearVerticalScaleLineMinor.NumOfTicks = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The color of the minor scale lines.")]
        public Color VerticalScaleLinesMinorTickForeColor {
            get {
                return TheLinearVerticalScaleLineMinor.ForeColor;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.ForeColor != value) {
                    TheLinearVerticalScaleLineMinor.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The start of the minor scale lines.")]
        public Point VerticalScaleLinesMinorStart {
            get {
                return TheLinearVerticalScaleLineMinor.Start;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.Start != value) {
                    TheLinearVerticalScaleLineMinor.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single VerticalScaleLinesMinorLength {
            get {
                return TheLinearVerticalScaleLineMinor.Length;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.Length != value) {
                    TheLinearVerticalScaleLineMinor.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The length of the minor scale tick lines.")]
        public Single VerticalScaleLinesMinorTickLength {
            get {
                return TheLinearVerticalScaleLineMinor.TickLength;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.TickLength != value) {
                    TheLinearVerticalScaleLineMinor.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Minor Lines]"),
        System.ComponentModel.Description("The width of the minor scale lines.")]
        public Single VerticalScaleLinesMinorTickWidth {
            get {
                return TheLinearVerticalScaleLineMinor.TickWidth;
            }
            set {
                if (TheLinearVerticalScaleLineMinor.TickWidth != value) {
                    TheLinearVerticalScaleLineMinor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Major
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("Major scale lines enabled or disabled.")]
        public Boolean VerticalScaleLinesMajorEnabled {
            get {
                return TheLinearVerticalScaleLinesMajor.Enabled;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.Enabled != value) {
                    TheLinearVerticalScaleLinesMajor.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The step value of the major scale lines.")]
        public Single VerticalScaleLinesMajorStepValue {
            get {
                return TheLinearVerticalScaleLinesMajor.StepValue;
            }
            set {
                if ((TheLinearVerticalScaleLinesMajor.StepValue != value) && (value > 0)) {
                    TheLinearVerticalScaleLinesMajor.StepValue = Math.Max(Math.Min(value, TheGuage.MaximumValue), TheGuage.MinimumValue);
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The color of the major scale lines.")]
        public Color VerticalScaleLinesMajorTickForeColor {
            get {
                return TheLinearVerticalScaleLinesMajor.ForeColor;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.ForeColor != value) {
                    TheLinearVerticalScaleLinesMajor.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The start of the major scale lines.")]
        public Point VerticalScaleLinesMajorStart {
            get {
                return TheLinearVerticalScaleLinesMajor.Start;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.Start != value) {
                    TheLinearVerticalScaleLinesMajor.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single VerticalScaleLinesMajorLength {
            get {
                return TheLinearVerticalScaleLinesMajor.Length;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.Length != value) {
                    TheLinearVerticalScaleLinesMajor.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The length of the major scale lines.")]
        public Single VerticalScaleLinesMajorTickLength {
            get {
                return TheLinearVerticalScaleLinesMajor.TickLength;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.TickLength != value) {
                    TheLinearVerticalScaleLinesMajor.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Major Lines]"),
        System.ComponentModel.Description("The width of the major scale lines.")]
        public Single VerticalScaleLinesMajorTickWidth {
            get {
                return TheLinearVerticalScaleLinesMajor.TickWidth;
            }
            set {
                if (TheLinearVerticalScaleLinesMajor.TickWidth != value) {
                    TheLinearVerticalScaleLinesMajor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Numbers
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Numbers]"),
        System.ComponentModel.Description("The start of the scale numbers.")]
        public Point VerticalScaleNumbersStart {
            get {
                return TheLinearVerticalScaleNumber.Start;
            }
            set {
                if (TheLinearVerticalScaleNumber.Start != value) {
                    TheLinearVerticalScaleNumber.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Numbers]"),
        System.ComponentModel.Description("The length of the scale numbers.")]
        public Single VerticalScaleNumbersLength {
            get {
                return TheLinearVerticalScaleNumber.Length;
            }
            set {
                if (TheLinearVerticalScaleNumber.Length != value) {
                    TheLinearVerticalScaleNumber.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }


        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Numbers]"),
        System.ComponentModel.Description("The color of the scale numbers.")]
        public Color VerticalScaleNumbersForeColor {
            get {
                return TheLinearVerticalScaleNumber.ForeColor;
            }
            set {
                if (TheLinearVerticalScaleNumber.ForeColor != value) {
                    TheLinearVerticalScaleNumber.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Numbers]"),
        System.ComponentModel.Description("The format of the scale numbers.")]
        public String VerticalScaleNumbersFormat {
            get {
                return TheLinearVerticalScaleNumber.Format;
            }
            set {
                if (TheLinearVerticalScaleNumber.Format != value) {
                    TheLinearVerticalScaleNumber.Format = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(LinearVerticalOriantationTypeEnum), typeof(LinearVerticalOriantationTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Scale Numbers]"),
        System.ComponentModel.Description("The angle relative to the tangent of the base arc at a scale line that is used to orientation numbers. set to 0 for no orientation or e.g. set to 90.")]
        public LinearVerticalOriantationTypeEnum VerticalScaleNumbersOrientation {
            get {
                return TheLinearVerticalScaleNumber.Orientation;
            }
            set {
                if (TheLinearVerticalScaleNumber.Orientation != value) {
                    TheLinearVerticalScaleNumber.Orientation = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Range
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 1]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean VerticalRange1Enabled {
            get {
                return TheLinearVerticalRanges[0].Enabled;
            }
            set {
                if (TheLinearVerticalRanges[0].Enabled != value) {
                    TheLinearVerticalRanges[0].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 1]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color VerticalRange1Color {
            get {
                return TheLinearVerticalRanges[0].ForeColor;
            }
            set {
                if (TheLinearVerticalRanges[0].ForeColor != value) {
                    TheLinearVerticalRanges[0].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 1]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single VerticalRange1Start {
            get {
                return TheLinearVerticalRanges[0].Start;
            }
            set {
                if (TheLinearVerticalRanges[0].Start != value) {
                    TheLinearVerticalRanges[0].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 1]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single VerticalRange1End {
            get {
                return TheLinearVerticalRanges[0].End;
            }
            set {
                if (TheLinearVerticalRanges[0].End != value) {
                    TheLinearVerticalRanges[0].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 1]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 VerticalRange1Width {
            get {
                return TheLinearVerticalRanges[0].Width;
            }
            set {
                if (TheLinearVerticalRanges[0].Width != value) {
                    TheLinearVerticalRanges[0].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 2]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean VerticalRange2Enabled {
            get {
                return TheLinearVerticalRanges[1].Enabled;
            }
            set {
                if (TheLinearVerticalRanges[1].Enabled != value) {
                    TheLinearVerticalRanges[1].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 2]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color VerticalRange2Color {
            get {
                return TheLinearVerticalRanges[1].ForeColor;
            }
            set {
                if (TheLinearVerticalRanges[1].ForeColor != value) {
                    TheLinearVerticalRanges[1].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 2]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single Range2Start {
            get {
                return TheLinearVerticalRanges[1].Start;
            }
            set {
                if (TheLinearVerticalRanges[1].Start != value) {
                    TheLinearVerticalRanges[1].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 2]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single VerticalRange2End {
            get {
                return TheLinearVerticalRanges[1].End;
            }
            set {
                if (TheLinearVerticalRanges[1].End != value) {
                    TheLinearVerticalRanges[1].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 2]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 VerticalRange2Width {
            get {
                return TheLinearVerticalRanges[1].Width;
            }
            set {
                if (TheLinearVerticalRanges[1].Width != value) {
                    TheLinearVerticalRanges[1].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 3]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean VerticalRange3Enabled {
            get {
                return TheLinearVerticalRanges[2].Enabled;
            }
            set {
                if (TheLinearVerticalRanges[2].Enabled != value) {
                    TheLinearVerticalRanges[2].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 3]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color VerticalRange3Color {
            get {
                return TheLinearVerticalRanges[2].ForeColor;
            }
            set {
                if (TheLinearVerticalRanges[2].ForeColor != value) {
                    TheLinearVerticalRanges[2].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 3]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single VerticalRange3Start {
            get {
                return TheLinearVerticalRanges[2].Start;
            }
            set {
                if (TheLinearVerticalRanges[2].Start != value) {
                    TheLinearVerticalRanges[2].Start = value;
                    Refresh();
                }
            }
        }


        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 3]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single VerticalRange3End {
            get {
                return TheLinearVerticalRanges[2].End;
            }
            set {
                if (TheLinearVerticalRanges[2].End != value) {
                    TheLinearVerticalRanges[2].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 3]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 VerticalRange3Width {
            get {
                return TheLinearVerticalRanges[2].Width;
            }
            set {
                if (TheLinearVerticalRanges[2].Width != value) {
                    TheLinearVerticalRanges[2].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 4]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean VerticalRange4Enabled {
            get {
                return TheLinearVerticalRanges[3].Enabled;
            }
            set {
                if (TheLinearVerticalRanges[3].Enabled != value) {
                    TheLinearVerticalRanges[3].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 4]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color VerticalRange4Color {
            get {
                return TheLinearVerticalRanges[3].ForeColor;
            }
            set {
                if (TheLinearVerticalRanges[3].ForeColor != value) {
                    TheLinearVerticalRanges[3].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 4]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single VerticalRange4Start {
            get {
                return TheLinearVerticalRanges[3].Start;
            }
            set {
                if (TheLinearVerticalRanges[3].Start != value) {
                    TheLinearVerticalRanges[3].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 4]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single VerticalRange4End {
            get {
                return TheLinearVerticalRanges[3].End;
            }
            set {
                if (TheLinearVerticalRanges[3].End != value) {
                    TheLinearVerticalRanges[3].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 4]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 VerticalRange4Width {
            get {
                return TheLinearVerticalRanges[3].Width;
            }
            set {
                if (TheLinearVerticalRanges[3].Width != value) {
                    TheLinearVerticalRanges[3].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 5]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean VerticalRange5Enabled {
            get {
                return TheLinearVerticalRanges[4].Enabled;
            }
            set {
                if (TheLinearVerticalRanges[4].Enabled != value) {
                    TheLinearVerticalRanges[4].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 5]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color VerticalRange5Color {
            get {
                return TheLinearVerticalRanges[4].ForeColor;
            }
            set {
                if (TheLinearVerticalRanges[4].ForeColor != value) {
                    TheLinearVerticalRanges[4].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 5]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single VerticalRange5Start {
            get {
                return TheLinearVerticalRanges[4].Start;
            }
            set {
                if (TheLinearVerticalRanges[4].Start != value) {
                    TheLinearVerticalRanges[4].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 5]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single VerticalRange5End {
            get {
                return TheLinearVerticalRanges[4].End;
            }
            set {
                if (TheLinearVerticalRanges[4].End != value) {
                    TheLinearVerticalRanges[4].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Range 5]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 VerticalRange5Width {
            get {
                return TheLinearVerticalRanges[4].Width;
            }
            set {
                if (TheLinearVerticalRanges[4].Width != value) {
                    TheLinearVerticalRanges[4].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Needle
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Needle]"),
        System.ComponentModel.Description("The origin of the needle.")]
        public Point VerticalNeedleStart {
            get {
                return TheLinearVerticalNeedle.Start;
            }
            set {
                if (TheLinearVerticalNeedle.Start != value) {
                    TheLinearVerticalNeedle.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(NeedleTypeEnum), typeof(NeedleTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Needle]"),
        System.ComponentModel.Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        public NeedleTypeEnum VerticalNeedleType {
            get {
                return TheLinearVerticalNeedle.Type;
            }
            set {
                if (TheLinearVerticalNeedle.Type != value) {
                    TheLinearVerticalNeedle.Type = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Needle]"),
        System.ComponentModel.Description("The length of the needle.")]
        public Int32 VerticalNeedleLength {
            get {
                return TheLinearVerticalNeedle.NeedleLength;
            }
            set {
                if (TheLinearVerticalNeedle.NeedleLength != value) {
                    TheLinearVerticalNeedle.NeedleLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Needle]"),
        System.ComponentModel.Description("The color of the needle.")]
        public Color VerticalNeedleForeColor {
            get {
                return TheLinearVerticalNeedle.ForeColor;
            }
            set {
                if (TheLinearVerticalNeedle.ForeColor != value) {
                    TheLinearVerticalNeedle.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Vertical [Needle]"),
        System.ComponentModel.Description("The width of the needle.")]
        public Int32 VerticalNeedleWidth {
            get {
                return TheLinearVerticalNeedle.NeedleWidth;
            }
            set {
                if (TheLinearVerticalNeedle.NeedleWidth != value) {
                    TheLinearVerticalNeedle.NeedleWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion
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
                graphics.RenderVerticalRanges(ClientRectangle, TheLinearVerticalBand.Start, TheLinearVerticalBand.Length, TheGuage.MinimumValue, TheGuage.MaximumValue, TheLinearVerticalRanges);

                graphics.RenderVerticalScaleLines(
                                                       ClientRectangle,
                                                       TheLinearVerticalScaleLineMinor.Enabled, TheLinearVerticalScaleLineMinor.Start, TheLinearVerticalScaleLineMinor.Length, TheLinearVerticalScaleLineMinor.TickLength, TheLinearVerticalScaleLineMinor.TickWidth, TheLinearVerticalScaleLineMinor.ForeColor, TheLinearVerticalScaleLineMinor.NumOfTicks,
                                                       TheLinearVerticalScaleLinesIntermediate.Enabled, TheLinearVerticalScaleLinesIntermediate.Start, TheLinearVerticalScaleLinesIntermediate.Length, TheLinearVerticalScaleLinesIntermediate.TickLength, TheLinearVerticalScaleLinesIntermediate.TickWidth, TheLinearVerticalScaleLinesIntermediate.ForeColor,
                                                       TheLinearVerticalScaleLinesMajor.Enabled, TheLinearVerticalScaleLinesMajor.Start, TheLinearVerticalScaleLinesMajor.Length, TheLinearVerticalScaleLinesMajor.TickLength, TheLinearVerticalScaleLinesMajor.TickWidth, TheLinearVerticalScaleLinesMajor.ForeColor, TheLinearVerticalScaleLinesMajor.StepValue,
                                                       TheGuage.MinimumValue, TheGuage.MaximumValue,
                                                       TheLinearVerticalScaleNumber.Orientation
                );

                graphics.RenderVerticalBand(ClientRectangle, TheLinearVerticalBand.Start, TheLinearVerticalBand.Length, TheLinearVerticalBand.Width, TheLinearVerticalBand.ForeColor);

                graphics.RenderVerticalScaleNumbers(
                                                        ClientRectangle,
                                                        Font,
                                                        TheLinearVerticalScaleNumber.ForeColor,
                                                        TheFontBound,
                                                        TheLinearVerticalScaleNumber.Format,
                                                        TheGuage.MinimumValue,
                                                        TheGuage.MaximumValue,
                                                        TheLinearVerticalScaleLinesMajor.StepValue,
                                                        TheLinearVerticalScaleNumber.Start,
                                                        TheLinearVerticalScaleNumber.Length
                 );

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);
                graphics.RenderVerticalNeedle(ClientRectangle, TheLinearVerticalNeedle.Start, TheLinearVerticalNeedle.Length, TheLinearVerticalNeedle.NeedleLength, TheLinearVerticalNeedle.NeedleWidth, TheGuage.MinimumValue, TheGuage.MaximumValue, TheLinearVerticalNeedle.Type, TheLinearVerticalNeedle.ForeColor, TheGuage.Value);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion
    }
}
