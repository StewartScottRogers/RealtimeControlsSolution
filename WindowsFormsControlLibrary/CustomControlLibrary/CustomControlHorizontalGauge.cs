using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlHorizontalGauge : Control {
        #region Constants
        private const Single TheMinimumValue = -400;
        private const Single TheMaximumValue = 500;
        private const Int32 TheLength = 400;
        #endregion

        #region Members
        private GuageDef TheGuage = new GuageDef(0, TheMinimumValue, TheMaximumValue);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Horizontal Guage", Color.Black, true),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false)
        };

        private LinearHorizontalRangeDef[] TheLinearHorizontalRanges = new LinearHorizontalRangeDef[] { 
            new LinearHorizontalRangeDef(true, TheMinimumValue, 200, 4, Color.GreenYellow),
            new LinearHorizontalRangeDef(true, 200, 300, 5, Color.Yellow),
            new LinearHorizontalRangeDef(true, 300, TheMaximumValue, 6, Color.Red),
            new LinearHorizontalRangeDef(false, 0, 0, 0, Color.FromKnownColor(KnownColor.Control)),
            new LinearHorizontalRangeDef(false, 0, 0, 0,  Color.FromKnownColor(KnownColor.Control))        
        };

        private LinearHorizontalBandDef TheLinearHorizontalBand = new LinearHorizontalBandDef(new Point(15, 35), TheLength);
        private LinearHorizontalScaleLineMinorDef TheLinearHorizontalScaleLinesMinor = new LinearHorizontalScaleLineMinorDef(true, Color.LightGray, new Point(15, 35), TheLength);
        private LinearHorizontalScaleLineIntermediateDef TheLinearHorizontalScaleLinesIntermediate = new LinearHorizontalScaleLineIntermediateDef(true, Color.Gray, new Point(15, 35), TheLength);
        private LinearHorizontalScaleLineMajorDef TheLinearHorizontalScaleLinesMajor = new LinearHorizontalScaleLineMajorDef(true, Color.Black, new Point(15, 35), TheLength);
        private LinearHorizontalScaleNumberDef TheLinearHorizontalScaleNumber = new LinearHorizontalScaleNumberDef(new Point(15, 20), TheLength, LinearHorizontalOriantationTypeEnum.Bottom);
        private LinearHorizontalNeedleDef TheLinearHorizontalNeedle = new LinearHorizontalNeedleDef(new Point(15, 40), TheLength);

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
        public CustomControlHorizontalGauge() {
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
                    TheGuage.Value = value;
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
        System.ComponentModel.Category("Gauge Horizontal [Band]"),
        System.ComponentModel.Description("The color of the band.")]
        public Color HorizontalBandForeColor {
            get {
                return TheLinearHorizontalBand.ForeColor;
            }
            set {
                if (TheLinearHorizontalBand.ForeColor != value) {
                    TheLinearHorizontalBand.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Band]"),
        System.ComponentModel.Description("The start point of the band.")]
        public Point HorizontalBandStart {
            get {
                return TheLinearHorizontalBand.Start;
            }
            set {
                if (TheLinearHorizontalBand.Start != value) {
                    TheLinearHorizontalBand.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Band]"),
        System.ComponentModel.Description("The Length of the band.")]
        public Int32 HorizontalBandLength {
            get {
                return TheLinearHorizontalBand.Length;
            }
            set {
                if (TheLinearHorizontalBand.Length != value) {
                    TheLinearHorizontalBand.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Band]"),
        System.ComponentModel.Description("The width of the band.")]
        public Int32 HorizontalBandWidth {
            get {
                return TheLinearHorizontalBand.Width;
            }
            set {
                if (TheLinearHorizontalBand.Width != value) {
                    TheLinearHorizontalBand.Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Intermediate
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("Intermediate scale lines enabled or disabled.")]
        public Boolean HorizontalScaleLinesIntermediateEnabled {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.Enabled;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.Enabled != value) {
                    TheLinearHorizontalScaleLinesIntermediate.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Color HorizontalScaleLinesIntermediateTickForeColor {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.ForeColor;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.ForeColor != value) {
                    TheLinearHorizontalScaleLinesIntermediate.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The start of the intermediate scale lines.")]
        public Point HorizontalScaleLinesIntermediateStart {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.Start;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.Start != value) {
                    TheLinearHorizontalScaleLinesIntermediate.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single HorizontalScaleLinesIntermediateLength {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.Length;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.Length != value) {
                    TheLinearHorizontalScaleLinesIntermediate.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }


        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The length of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Single HorizontalScaleLinesIntermediateTickLength {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.TickLength;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.TickLength != value) {
                    TheLinearHorizontalScaleLinesIntermediate.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The width of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Single HorizontalScaleLinesIntermediateTickWidth {
            get {
                return TheLinearHorizontalScaleLinesIntermediate.TickWidth;
            }
            set {
                if (TheLinearHorizontalScaleLinesIntermediate.TickWidth != value) {
                    TheLinearHorizontalScaleLinesIntermediate.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Minor
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("Minor scale lines enabled or disabled.")]
        public Boolean HorizontalScaleLinesMinorEnabled {
            get {
                return TheLinearHorizontalScaleLinesMinor.Enabled;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.Enabled != value) {
                    TheLinearHorizontalScaleLinesMinor.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The number of minor scale lines.")]
        public Int32 HorizontalScaleLinesMinorNumOf {
            get {
                return TheLinearHorizontalScaleLinesMinor.NumOfTicks;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.NumOfTicks != value) {
                    TheLinearHorizontalScaleLinesMinor.NumOfTicks = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The color of the minor scale lines.")]
        public Color HorizontalScaleLinesMinorTickForeColor {
            get {
                return TheLinearHorizontalScaleLinesMinor.ForeColor;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.ForeColor != value) {
                    TheLinearHorizontalScaleLinesMinor.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The start of the minor scale lines.")]
        public Point HorizontalScaleLinesMinorStart {
            get {
                return TheLinearHorizontalScaleLinesMinor.Start;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.Start != value) {
                    TheLinearHorizontalScaleLinesMinor.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single HorizontalScaleLinesMinorLength {
            get {
                return TheLinearHorizontalScaleLinesMinor.Length;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.Length != value) {
                    TheLinearHorizontalScaleLinesMinor.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The length of the minor tick scale lines.")]
        public Single HorizontalScaleLinesMinorTickLength {
            get {
                return TheLinearHorizontalScaleLinesMinor.TickLength;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.TickLength != value) {
                    TheLinearHorizontalScaleLinesMinor.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Minor Lines]"),
        System.ComponentModel.Description("The width of the minor scale lines.")]
        public Single HorizontalScaleLinesMinorTickWidth {
            get {
                return TheLinearHorizontalScaleLinesMinor.TickWidth;
            }
            set {
                if (TheLinearHorizontalScaleLinesMinor.TickWidth != value) {
                    TheLinearHorizontalScaleLinesMinor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Major
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("Major scale lines enabled or disabled.")]
        public Boolean HorizontalScaleLinesMajorEnabled {
            get {
                return TheLinearHorizontalScaleLinesMajor.Enabled;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.Enabled != value) {
                    TheLinearHorizontalScaleLinesMajor.Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The step value of the major scale lines.")]
        public Single HorizontalScaleLinesMajorStepValue {
            get {
                return TheLinearHorizontalScaleLinesMajor.StepValue;
            }
            set {
                if ((TheLinearHorizontalScaleLinesMajor.StepValue != value) && (value > 0)) {
                    TheLinearHorizontalScaleLinesMajor.StepValue = Math.Max(Math.Min(value, TheGuage.MaximumValue), TheGuage.MinimumValue);
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The color of the major scale lines.")]
        public Color HorizontalScaleLinesMajorTickForeColor {
            get {
                return TheLinearHorizontalScaleLinesMajor.ForeColor;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.ForeColor != value) {
                    TheLinearHorizontalScaleLinesMajor.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The start of the major scale lines.")]
        public Point HorizontalScaleLinesMajorStart {
            get {
                return TheLinearHorizontalScaleLinesMajor.Start;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.Start != value) {
                    TheLinearHorizontalScaleLinesMajor.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The length of the scale.")]
        public Single HorizontalScaleLinesMajorLength {
            get {
                return TheLinearHorizontalScaleLinesMajor.Length;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.Length != value) {
                    TheLinearHorizontalScaleLinesMajor.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The length of the major scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Single HorizontalScaleLinesMajorTickLength {
            get {
                return TheLinearHorizontalScaleLinesMajor.TickLength;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.TickLength != value) {
                    TheLinearHorizontalScaleLinesMajor.TickLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Major Lines]"),
        System.ComponentModel.Description("The width of the major scale lines.")]
        public Single HorizontalScaleLinesMajorTickWidth {
            get {
                return TheLinearHorizontalScaleLinesMajor.TickWidth;
            }
            set {
                if (TheLinearHorizontalScaleLinesMajor.TickWidth != value) {
                    TheLinearHorizontalScaleLinesMajor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Number
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Numbers]"),
        System.ComponentModel.Description("The start of the scale numbers.")]
        public Point HorizontalScaleNumbersStart {
            get {
                return TheLinearHorizontalScaleNumber.Start;
            }
            set {
                if (TheLinearHorizontalScaleNumber.Start != value) {
                    TheLinearHorizontalScaleNumber.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Numbers]"),
        System.ComponentModel.Description("The length of the scale numbers.")]
        public Single HorizontalScaleNumbersLength {
            get {
                return TheLinearHorizontalScaleNumber.Length;
            }
            set {
                if (TheLinearHorizontalScaleNumber.Length != value) {
                    TheLinearHorizontalScaleNumber.Length = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Numbers]"),
        System.ComponentModel.Description("The color of the scale numbers.")]
        public Color HorizontalScaleNumbersColor {
            get {
                return TheLinearHorizontalScaleNumber.ForeColor;
            }
            set {
                if (TheLinearHorizontalScaleNumber.ForeColor != value) {
                    TheLinearHorizontalScaleNumber.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Numbers]"),
        System.ComponentModel.Description("The format of the scale numbers.")]
        public String HorizontalScaleNumbersFormat {
            get {
                return TheLinearHorizontalScaleNumber.Format;
            }
            set {
                if (TheLinearHorizontalScaleNumber.Format != value) {
                    TheLinearHorizontalScaleNumber.Format = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(LinearHorizontalOriantationTypeEnum), typeof(LinearHorizontalOriantationTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Scale Numbers]"),
        System.ComponentModel.Description("The angle relative to the tangent of the base arc at a scale line that is used to orientation numbers. set to 0 for no orientation or e.g. set to 90.")]
        public LinearHorizontalOriantationTypeEnum HorizontalScaleNumbersOrientation {
            get {
                return TheLinearHorizontalScaleNumber.Orientation;
            }
            set {
                if (TheLinearHorizontalScaleNumber.Orientation != value) {
                    TheLinearHorizontalScaleNumber.Orientation = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Range
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 1]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean HorizontalRange1Enabled {
            get {
                return TheLinearHorizontalRanges[0].Enabled;
            }
            set {
                if (TheLinearHorizontalRanges[0].Enabled != value) {
                    TheLinearHorizontalRanges[0].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 1]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color HorizontalRange1Color {
            get {
                return TheLinearHorizontalRanges[0].ForeColor;
            }
            set {
                if (TheLinearHorizontalRanges[0].ForeColor != value) {
                    TheLinearHorizontalRanges[0].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 1]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single HorizontalRange1Start {
            get {
                return TheLinearHorizontalRanges[0].Start;
            }
            set {
                if (TheLinearHorizontalRanges[0].Start != value) {
                    TheLinearHorizontalRanges[0].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 1]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single HorizontalRange1End {
            get {
                return TheLinearHorizontalRanges[0].End;
            }
            set {
                if (TheLinearHorizontalRanges[0].End != value) {
                    TheLinearHorizontalRanges[0].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 1]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 HorizontalRange1Width {
            get {
                return TheLinearHorizontalRanges[0].Width;
            }
            set {
                if (TheLinearHorizontalRanges[0].Width != value) {
                    TheLinearHorizontalRanges[0].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 2]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean HorizontalRange2Enabled {
            get {
                return TheLinearHorizontalRanges[1].Enabled;
            }
            set {
                if (TheLinearHorizontalRanges[1].Enabled != value) {
                    TheLinearHorizontalRanges[1].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 2]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color HorizontalRange2Color {
            get {
                return TheLinearHorizontalRanges[1].ForeColor;
            }
            set {
                if (TheLinearHorizontalRanges[1].ForeColor != value) {
                    TheLinearHorizontalRanges[1].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 2]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single HorizontalRange2Start {
            get {
                return TheLinearHorizontalRanges[1].Start;
            }
            set {
                if (TheLinearHorizontalRanges[1].Start != value) {
                    TheLinearHorizontalRanges[1].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 2]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single HorizontalRange2End {
            get {
                return TheLinearHorizontalRanges[1].End;
            }
            set {
                if (TheLinearHorizontalRanges[1].End != value) {
                    TheLinearHorizontalRanges[1].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 2]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 HorizontalRange2Width {
            get {
                return TheLinearHorizontalRanges[1].Width;
            }
            set {
                if (TheLinearHorizontalRanges[1].Width != value) {
                    TheLinearHorizontalRanges[1].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 3]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean HorizontalRange3Enabled {
            get {
                return TheLinearHorizontalRanges[2].Enabled;
            }
            set {
                if (TheLinearHorizontalRanges[2].Enabled != value) {
                    TheLinearHorizontalRanges[2].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 3]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color HorizontalRange3Color {
            get {
                return TheLinearHorizontalRanges[2].ForeColor;
            }
            set {
                if (TheLinearHorizontalRanges[2].ForeColor != value) {
                    TheLinearHorizontalRanges[2].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 3]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single HorizontalRange3Start {
            get {
                return TheLinearHorizontalRanges[2].Start;
            }
            set {
                if (TheLinearHorizontalRanges[2].Start != value) {
                    TheLinearHorizontalRanges[2].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 3]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single HorizontalRange3End {
            get {
                return TheLinearHorizontalRanges[2].End;
            }
            set {
                if (TheLinearHorizontalRanges[2].End != value) {
                    TheLinearHorizontalRanges[2].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 3]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 HorizontalRange3Width {
            get {
                return TheLinearHorizontalRanges[2].Width;
            }
            set {
                if (TheLinearHorizontalRanges[2].Width != value) {
                    TheLinearHorizontalRanges[2].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 4]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean HorizontalRange4Enabled {
            get {
                return TheLinearHorizontalRanges[3].Enabled;
            }
            set {
                if (TheLinearHorizontalRanges[3].Enabled != value) {
                    TheLinearHorizontalRanges[3].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 4]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color HorizontalRange4Color {
            get {
                return TheLinearHorizontalRanges[3].ForeColor;
            }
            set {
                if (TheLinearHorizontalRanges[3].ForeColor != value) {
                    TheLinearHorizontalRanges[3].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 4]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single HorizontalRange4Start {
            get {
                return TheLinearHorizontalRanges[3].Start;
            }
            set {
                if (TheLinearHorizontalRanges[3].Start != value) {
                    TheLinearHorizontalRanges[3].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 4]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single HorizontalRange4End {
            get {
                return TheLinearHorizontalRanges[3].End;
            }
            set {
                if (TheLinearHorizontalRanges[3].End != value) {
                    TheLinearHorizontalRanges[3].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 4]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 HorizontalRange4Width {
            get {
                return TheLinearHorizontalRanges[3].Width;
            }
            set {
                if (TheLinearHorizontalRanges[3].Width != value) {
                    TheLinearHorizontalRanges[3].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 5]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean HorizontalRange5Enabled {
            get {
                return TheLinearHorizontalRanges[4].Enabled;
            }
            set {
                if (TheLinearHorizontalRanges[4].Enabled != value) {
                    TheLinearHorizontalRanges[4].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 5]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color HorizontalRange5Color {
            get {
                return TheLinearHorizontalRanges[4].ForeColor;
            }
            set {
                if (TheLinearHorizontalRanges[4].ForeColor != value) {
                    TheLinearHorizontalRanges[4].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 5]"),
        System.ComponentModel.Description("The start of the range.")]
        public Single HorizontalRange5Start {
            get {
                return TheLinearHorizontalRanges[4].Start;
            }
            set {
                if (TheLinearHorizontalRanges[4].Start != value) {
                    TheLinearHorizontalRanges[4].Start = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 5]"),
        System.ComponentModel.Description("The end of the range.")]
        public Single HorizontalRange5End {
            get {
                return TheLinearHorizontalRanges[4].End;
            }
            set {
                if (TheLinearHorizontalRanges[4].End != value) {
                    TheLinearHorizontalRanges[4].End = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Range 5]"),
        System.ComponentModel.Description("The width of the range.")]
        public Int32 HorizontalRange5Width {
            get {
                return TheLinearHorizontalRanges[4].Width;
            }
            set {
                if (TheLinearHorizontalRanges[4].Width != value) {
                    TheLinearHorizontalRanges[4].Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Needle
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Needle]"),
        System.ComponentModel.Description("The origin of the needle.")]
        public Point HorizontalNeedleCenter {
            get {
                return TheLinearHorizontalNeedle.Start;
            }
            set {
                if (TheLinearHorizontalNeedle.Start != value) {
                    TheLinearHorizontalNeedle.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(NeedleTypeEnum), typeof(NeedleTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Needle]"),
        System.ComponentModel.Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        public NeedleTypeEnum HorizontalNeedleType {
            get {
                return TheLinearHorizontalNeedle.Type;
            }
            set {
                if (TheLinearHorizontalNeedle.Type != value) {
                    TheLinearHorizontalNeedle.Type = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Needle]"),
        System.ComponentModel.Description("The length of the needle.")]
        public Int32 HorizontalNeedleLength {
            get {
                return TheLinearHorizontalNeedle.NeedleLength;
            }
            set {
                if (TheLinearHorizontalNeedle.NeedleLength != value) {
                    TheLinearHorizontalNeedle.NeedleLength = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Needle]"),
        System.ComponentModel.Description("The color of the needle.")]
        public Color HorizontalNeedleForeColor {
            get {
                return TheLinearHorizontalNeedle.ForeColor;
            }
            set {
                if (TheLinearHorizontalNeedle.ForeColor != value) {
                    TheLinearHorizontalNeedle.ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge Horizontal [Needle]"),
        System.ComponentModel.Description("The width of the needle.")]
        public Int32 HorizontalNeedleWidth {
            get {
                return TheLinearHorizontalNeedle.NeedleWidth;
            }
            set {
                if (TheLinearHorizontalNeedle.NeedleWidth != value) {
                    TheLinearHorizontalNeedle.NeedleWidth = value;
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
                graphics.RenderHorizontalRanges(ClientRectangle, TheLinearHorizontalBand.Start, TheLinearHorizontalBand.Length, TheGuage.MinimumValue, TheGuage.MaximumValue, TheLinearHorizontalRanges);

                graphics.RenderHorizontalScaleLines(
                                                        ClientRectangle,
                                                        TheLinearHorizontalScaleLinesMinor.Enabled, TheLinearHorizontalScaleLinesMinor.Start, TheLinearHorizontalScaleLinesMinor.Length, TheLinearHorizontalScaleLinesMinor.TickLength, TheLinearHorizontalScaleLinesMinor.TickWidth, TheLinearHorizontalScaleLinesMinor.ForeColor, TheLinearHorizontalScaleLinesMinor.NumOfTicks,
                                                        TheLinearHorizontalScaleLinesIntermediate.Enabled, TheLinearHorizontalScaleLinesIntermediate.Start, TheLinearHorizontalScaleLinesIntermediate.Length, TheLinearHorizontalScaleLinesIntermediate.TickLength, TheLinearHorizontalScaleLinesIntermediate.TickWidth, TheLinearHorizontalScaleLinesIntermediate.ForeColor,
                                                        TheLinearHorizontalScaleLinesMajor.Enabled, TheLinearHorizontalScaleLinesMajor.Start, TheLinearHorizontalScaleLinesMajor.Length, TheLinearHorizontalScaleLinesMajor.TickLength, TheLinearHorizontalScaleLinesMajor.TickWidth, TheLinearHorizontalScaleLinesMajor.ForeColor, TheLinearHorizontalScaleLinesMajor.StepValue,
                                                        TheGuage.MinimumValue, TheGuage.MaximumValue,
                                                        TheLinearHorizontalScaleNumber.Orientation
                );

                graphics.RenderHorizontalBand(ClientRectangle, TheLinearHorizontalBand.Start, TheLinearHorizontalBand.Length, TheLinearHorizontalBand.Width, TheLinearHorizontalBand.ForeColor);

                graphics.RenderHorizontalScaleNumbers(
                                                         ClientRectangle,
                                                         Font,
                                                         TheLinearHorizontalScaleNumber.ForeColor,
                                                         TheFontBound,
                                                         TheLinearHorizontalScaleNumber.Format,
                                                         TheGuage.MinimumValue,
                                                         TheGuage.MaximumValue,
                                                         TheLinearHorizontalScaleLinesMajor.StepValue,
                                                         TheLinearHorizontalScaleNumber.Start,
                                                         TheLinearHorizontalScaleNumber.Length
                );

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);
                graphics.RenderHorizontalNeedle(ClientRectangle, TheLinearHorizontalNeedle.Start, TheLinearHorizontalNeedle.Length, TheLinearHorizontalNeedle.NeedleLength, TheLinearHorizontalNeedle.NeedleWidth, TheGuage.MinimumValue, TheGuage.MaximumValue, TheLinearHorizontalNeedle.Type, TheLinearHorizontalNeedle.ForeColor, TheGuage.Value);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion
    }
}
