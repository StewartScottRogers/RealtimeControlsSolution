using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal partial class CustomControlArcGauge : Control {
        #region Constants
        private const Single TheMinimumValue = -400;
        private const Single TheMaximumValue = 500;
        #endregion

        #region Members
        private GuageDef TheGuage = new GuageDef(0, TheMinimumValue, TheMaximumValue);

        private CaptionDef[] TheCaptions = new CaptionDef[]{
            new CaptionDef(new Point(4, 3), "Arc Guage", Color.Black, true),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false),
            new CaptionDef(new Point(10, 10), "", Color.Black, false)
        };

        private ArcRangeDef[] TheArcRanges = new ArcRangeDef[] { 
            new ArcRangeDef(true, 77, 80,  TheMinimumValue, 200.0f, Color.GreenYellow),
            new ArcRangeDef(true, 76, 80, 200.0f, 300.0f, Color.Yellow),
            new ArcRangeDef(true, 75, 80, 300.0f, TheMaximumValue, Color.Red),
            new ArcRangeDef(false, 20, 25, 0.0f, 0.0f, Color.FromKnownColor(KnownColor.Control)),
            new ArcRangeDef(false, 20, 25, 0.0f, 0.0f, Color.FromKnownColor(KnownColor.Control))        
        };

        private ArcBandDef TheBand = new ArcBandDef();
        private ArcScaleLineMinorDef TheArcScaleLinesMinor = new ArcScaleLineMinorDef();
        private ArcScaleLineIntermediateDef TheArcScaleLinesIntermediate = new ArcScaleLineIntermediateDef();
        private ArcScaleLineMajorDef TheArcScaleLinesMajor = new ArcScaleLineMajorDef();
        private ArcScaleNumberDef TheArcScaleNumber = new ArcScaleNumberDef();
        private ArcNeedleDef TheArcNeedle = new ArcNeedleDef();
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

        #region Constructor
        public CustomControlArcGauge() {
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
        System.ComponentModel.Category("Gauge [Band]"),
        System.ComponentModel.Description("The color of the band.")]
        public Color BandColor {
            get {
                return TheBand.Color;
            }
            set {
                if (TheBand.Color != value) {
                    TheBand.Color = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Band]"),
        System.ComponentModel.Description("The radius of the band.")]
        public Int32 BandRadius {
            get {
                return TheBand.Radius;
            }
            set {
                if (TheBand.Radius != value) {
                    TheBand.Radius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Band]"),
        System.ComponentModel.Description("The start angle of the band.")]
        public Int32 BandSweepStart {
            get {
                return TheBand.Start;
            }
            set {
                if (TheBand.Start != value) {
                    TheBand.Start = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Band]"),
        System.ComponentModel.Description("The sweep angle of the band.")]
        public Int32 BandSweepLength {
            get {
                return TheBand.Sweep;
            }
            set {
                if (TheBand.Sweep != value) {
                    TheBand.Sweep = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Band]"),
        System.ComponentModel.Description("The width of the band.")]
        public Int32 BandWidth {
            get {
                return TheBand.Width;
            }
            set {
                if (TheBand.Width != value) {
                    TheBand.Width = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Intermediate
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The color of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Color ScaleLinesIntermediateTickForeColor {
            get {
                return TheArcScaleLinesIntermediate.TickForeColor;
            }
            set {
                if (TheArcScaleLinesIntermediate.TickForeColor != value) {
                    TheArcScaleLinesIntermediate.TickForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The inner radius of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesIntermediateTickInnerRadius {
            get {
                return TheArcScaleLinesIntermediate.TickInnerRadius;
            }
            set {
                if (TheArcScaleLinesIntermediate.TickInnerRadius != value) {
                    TheArcScaleLinesIntermediate.TickInnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The outer radius of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesIntermediateTickOuterRadius {
            get {
                return TheArcScaleLinesIntermediate.TickOuterRadius;
            }
            set {
                if (TheArcScaleLinesIntermediate.TickOuterRadius != value) {
                    TheArcScaleLinesIntermediate.TickOuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Intermediate Lines]"),
        System.ComponentModel.Description("The width of the intermediate scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesIntermediateTickWidth {
            get {
                return TheArcScaleLinesIntermediate.TickWidth;
            }
            set {
                if (TheArcScaleLinesIntermediate.TickWidth != value) {
                    TheArcScaleLinesIntermediate.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Minor
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Minor Lines]"),
        System.ComponentModel.Description("The number of minor scale lines.")]
        public Int32 ScaleLinesMinorNumOfTicks {
            get {
                return TheArcScaleLinesMinor.NumOfTicks;
            }
            set {
                if (TheArcScaleLinesMinor.NumOfTicks != value) {
                    TheArcScaleLinesMinor.NumOfTicks = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Minor Lines]"),
        System.ComponentModel.Description("The color of the minor scale lines.")]
        public Color ScaleLinesMinorTickForeColor {
            get {
                return TheArcScaleLinesMinor.TickForeColor;
            }
            set {
                if (TheArcScaleLinesMinor.TickForeColor != value) {
                    TheArcScaleLinesMinor.TickForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Minor Lines]"),
        System.ComponentModel.Description("The inner radius of the minor scale lines.")]
        public Int32 ScaleLinesMinorTickInnerRadius {
            get {
                return TheArcScaleLinesMinor.TickInnerRadius;
            }
            set {
                if (TheArcScaleLinesMinor.TickInnerRadius != value) {
                    TheArcScaleLinesMinor.TickInnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Minor Lines]"),
        System.ComponentModel.Description("The outer radius of the minor scale lines.")]
        public Int32 ScaleLinesMinorTickOuterRadius {
            get {
                return TheArcScaleLinesMinor.TickOuterRadius;
            }
            set {
                if (TheArcScaleLinesMinor.TickOuterRadius != value) {
                    TheArcScaleLinesMinor.TickOuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Minor Lines]"),
        System.ComponentModel.Description("The width of the minor scale lines.")]
        public Int32 ScaleLinesMinorTickWidth {
            get {
                return TheArcScaleLinesMinor.TickWidth;
            }
            set {
                if (TheArcScaleLinesMinor.TickWidth != value) {
                    TheArcScaleLinesMinor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Major
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Major Lines]"),
        System.ComponentModel.Description("The step value of the major scale lines.")]
        public Single ScaleLinesMajorStepValue {
            get {
                return TheArcScaleLinesMajor.StepValue;
            }
            set {
                if ((TheArcScaleLinesMajor.StepValue != value) && (value > 0)) {
                    TheArcScaleLinesMajor.StepValue = Math.Max(Math.Min(value, TheGuage.MaximumValue), TheGuage.MinimumValue);
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Major Lines]"),
        System.ComponentModel.Description("The color of the major scale lines.")]
        public Color ScaleLinesMajorTickForeColor {
            get {
                return TheArcScaleLinesMajor.TickForeColor;
            }
            set {
                if (TheArcScaleLinesMajor.TickForeColor != value) {
                    TheArcScaleLinesMajor.TickForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Major Lines]"),
        System.ComponentModel.Description("The inner radius of the major scale lines.")]
        public Int32 ScaleLinesMajorTickInnerRadius {
            get {
                return TheArcScaleLinesMajor.TickInnerRadius;
            }
            set {
                if (TheArcScaleLinesMajor.TickInnerRadius != value) {
                    TheArcScaleLinesMajor.TickInnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Major Lines]"),
        System.ComponentModel.Description("The outer radius of the major scale lines.")]
        public Int32 ScaleLinesMajorTickOuterRadius {
            get {
                return TheArcScaleLinesMajor.TickOuterRadius;
            }
            set {
                if (TheArcScaleLinesMajor.TickOuterRadius != value) {
                    TheArcScaleLinesMajor.TickOuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Major Lines]"),
        System.ComponentModel.Description("The width of the major scale lines.")]
        public Int32 ScaleLinesMajorTickWidth {
            get {
                return TheArcScaleLinesMajor.TickWidth;
            }
            set {
                if (TheArcScaleLinesMajor.TickWidth != value) {
                    TheArcScaleLinesMajor.TickWidth = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Scale Number
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The radius of the scale numbers.")]
        public Int32 ScaleNumbersRadius {
            get {
                return TheArcScaleNumber.Radius;
            }
            set {
                if (TheArcScaleNumber.Radius != value) {
                    TheArcScaleNumber.Radius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The color of the scale numbers.")]
        public Color ScaleNumbersColor {
            get {
                return TheArcScaleNumber.Color;
            }
            set {
                if (TheArcScaleNumber.Color != value) {
                    TheArcScaleNumber.Color = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The format of the scale numbers.")]
        public String ScaleNumbersFormat {
            get {
                return TheArcScaleNumber.Format;
            }
            set {
                if (TheArcScaleNumber.Format != value) {
                    TheArcScaleNumber.Format = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The number of the scale line to start writing numbers next to.")]
        public Int32 ScaleNumbersStartScaleLine {
            get {
                return TheArcScaleNumber.StartScaleLine;
            }
            set {
                if (TheArcScaleNumber.StartScaleLine != value) {
                    TheArcScaleNumber.StartScaleLine = Math.Max(value, 1);
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The number of scale line steps for writing numbers.")]
        public Int32 ScaleNumbersStepScaleLines {
            get {
                return TheArcScaleNumber.StepScaleLines;
            }
            set {
                if (TheArcScaleNumber.StepScaleLines != value) {
                    TheArcScaleNumber.StepScaleLines = Math.Max(value, 1);
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(ArcOriantationTypeEnum), typeof(ArcOriantationTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Scale Numbers]"),
        System.ComponentModel.Description("The angle relative to the tangent of the base arc at a scale line that is used to orientation numbers. set to 0 for no orientation or e.g. set to 90.")]
        public ArcOriantationTypeEnum ScaleNumbersOrientation {
            get {
                return TheArcScaleNumber.Orientation;
            }
            set {
                if (TheArcScaleNumber.Orientation != value) {
                    TheArcScaleNumber.Orientation = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Range
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean Range1Enabled {
            get {
                return TheArcRanges[0].Enabled;
            }
            set {
                if (TheArcRanges[0].Enabled != value) {
                    TheArcRanges[0].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color Range1Color {
            get {
                return TheArcRanges[0].ForeColor;
            }
            set {
                if (TheArcRanges[0].ForeColor != value) {
                    TheArcRanges[0].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
        public Single Range1StartValue {
            get {
                return TheArcRanges[0].StartValue;
            }
            set {
                if ((TheArcRanges[0].StartValue != value)
                && (value < TheArcRanges[0].EndValue)) {
                    TheArcRanges[0].StartValue = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single Range1EndValue {
            get {
                return TheArcRanges[0].EndValue;
            }
            set {
                if ((TheArcRanges[0].EndValue != value)
                && (TheArcRanges[0].StartValue < value)) {
                    TheArcRanges[0].EndValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range1InnerRadius {
            get {
                return TheArcRanges[0].InnerRadius;
            }
            set {
                if (TheArcRanges[0].InnerRadius != value) {
                    TheArcRanges[0].InnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 1]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range1OuterRadius {
            get {
                return TheArcRanges[0].OuterRadius;
            }
            set {
                if (TheArcRanges[0].OuterRadius != value) {
                    TheArcRanges[0].OuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean Range2Enabled {
            get {
                return TheArcRanges[1].Enabled;
            }
            set {
                if (TheArcRanges[1].Enabled != value) {
                    TheArcRanges[1].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color Range2Color {
            get {
                return TheArcRanges[1].ForeColor;
            }
            set {
                if (TheArcRanges[1].ForeColor != value) {
                    TheArcRanges[1].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
        public Single Range2StartValue {
            get {
                return TheArcRanges[1].StartValue;
            }
            set {
                if ((TheArcRanges[1].StartValue != value)
                && (value < TheArcRanges[1].EndValue)) {
                    TheArcRanges[1].StartValue = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single Range2EndValue {
            get {
                return TheArcRanges[1].EndValue;
            }
            set {
                if ((TheArcRanges[1].EndValue != value)
                && (TheArcRanges[1].StartValue < value)) {
                    TheArcRanges[1].EndValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range2InnerRadius {
            get {
                return TheArcRanges[1].InnerRadius;
            }
            set {
                if (TheArcRanges[1].InnerRadius != value) {
                    TheArcRanges[1].InnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 2]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range2OuterRadius {
            get {
                return TheArcRanges[1].OuterRadius;
            }
            set {
                if (TheArcRanges[1].OuterRadius != value) {
                    TheArcRanges[1].OuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean Range3Enabled {
            get {
                return TheArcRanges[2].Enabled;
            }
            set {
                if (TheArcRanges[2].Enabled != value) {
                    TheArcRanges[2].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color Range3Color {
            get {
                return TheArcRanges[2].ForeColor;
            }
            set {
                if (TheArcRanges[2].ForeColor != value) {
                    TheArcRanges[2].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
        public Single Range3StartValue {
            get {
                return TheArcRanges[2].StartValue;
            }
            set {
                if ((TheArcRanges[2].StartValue != value)
                && (value < TheArcRanges[2].EndValue)) {
                    TheArcRanges[2].StartValue = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single Range3EndValue {
            get {
                return TheArcRanges[2].EndValue;
            }
            set {
                if ((TheArcRanges[2].EndValue != value)
                && (TheArcRanges[2].StartValue < value)) {
                    TheArcRanges[2].EndValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range3InnerRadius {
            get {
                return TheArcRanges[2].InnerRadius;
            }
            set {
                if (TheArcRanges[2].InnerRadius != value) {
                    TheArcRanges[2].InnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 3]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range3OuterRadius {
            get {
                return TheArcRanges[2].OuterRadius;
            }
            set {
                if (TheArcRanges[2].OuterRadius != value) {
                    TheArcRanges[2].OuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean Range4Enabled {
            get {
                return TheArcRanges[3].Enabled;
            }
            set {
                if (TheArcRanges[3].Enabled != value) {
                    TheArcRanges[3].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color Range4Color {
            get {
                return TheArcRanges[3].ForeColor;
            }
            set {
                if (TheArcRanges[3].ForeColor != value) {
                    TheArcRanges[3].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
        public Single Range4StartValue {
            get {
                return TheArcRanges[3].StartValue;
            }
            set {
                if ((TheArcRanges[3].StartValue != value)
                && (value < TheArcRanges[3].EndValue)) {
                    TheArcRanges[3].StartValue = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single Range4EndValue {
            get {
                return TheArcRanges[3].EndValue;
            }
            set {
                if ((TheArcRanges[3].EndValue != value)
                && (TheArcRanges[3].StartValue < value)) {
                    TheArcRanges[3].EndValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range4InnerRadius {
            get {
                return TheArcRanges[3].InnerRadius;
            }
            set {
                if (TheArcRanges[3].InnerRadius != value) {
                    TheArcRanges[3].InnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 4]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range4OuterRadius {
            get {
                return TheArcRanges[3].OuterRadius;
            }
            set {
                if (TheArcRanges[3].OuterRadius != value) {
                    TheArcRanges[3].OuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("Enables or disables the range.")]
        public Boolean Range5Enabled {
            get {
                return TheArcRanges[4].Enabled;
            }
            set {
                if (TheArcRanges[4].Enabled != value) {
                    TheArcRanges[4].Enabled = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("The color of the range.")]
        public Color Range5Color {
            get {
                return TheArcRanges[4].ForeColor;
            }
            set {
                if (TheArcRanges[4].ForeColor != value) {
                    TheArcRanges[4].ForeColor = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
        public Single Range5StartValue {
            get {
                return TheArcRanges[4].StartValue;
            }
            set {
                if ((TheArcRanges[4].StartValue != value)
                && (value < TheArcRanges[4].EndValue)) {
                    TheArcRanges[4].StartValue = value;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single Range5EndValue {
            get {
                return TheArcRanges[4].EndValue;
            }
            set {
                if ((TheArcRanges[4].EndValue != value)
                && (TheArcRanges[4].StartValue < value)) {
                    TheArcRanges[4].EndValue = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range5InnerRadius {
            get {
                return TheArcRanges[4].InnerRadius;
            }
            set {
                if (TheArcRanges[4].InnerRadius != value) {
                    TheArcRanges[4].InnerRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Range 5]"),
        System.ComponentModel.Description("The inner radius of the range.")]
        public Int32 Range5OuterRadius {
            get {
                return TheArcRanges[4].OuterRadius;
            }
            set {
                if (TheArcRanges[4].OuterRadius != value) {
                    TheArcRanges[4].OuterRadius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region Needle
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Needle]"),
        System.ComponentModel.Description("The origin of the needle.")]
        public Point NeedleCenter {
            get {
                return TheArcNeedle.Center;
            }
            set {
                if (TheArcNeedle.Center != value) {
                    TheArcNeedle.Center = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [Editor(typeof(NeedleTypeEnum), typeof(NeedleTypeEnumConverter))]
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Needle]"),
        System.ComponentModel.Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        public NeedleTypeEnum NeedleType {
            get {
                return TheArcNeedle.Type;
            }
            set {
                if (TheArcNeedle.Type != value) {
                    TheArcNeedle.Type = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Needle]"),
        System.ComponentModel.Description("The radius of the needle.")]
        public Int32 NeedleRadius {
            get {
                return TheArcNeedle.Radius;
            }
            set {
                if (TheArcNeedle.Radius != value) {
                    TheArcNeedle.Radius = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Needle]"),
        System.ComponentModel.Description("The color of the needle.")]
        public Color NeedleColor {
            get {
                return TheArcNeedle.Color;
            }
            set {
                if (TheArcNeedle.Color != value) {
                    TheArcNeedle.Color = value;
                    IsBackgroundDrawing = true;
                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gauge [Needle]"),
        System.ComponentModel.Description("The width of the needle.")]
        public Int32 NeedleWidth {
            get {
                return TheArcNeedle.Width;
            }
            set {
                if (TheArcNeedle.Width != value) {
                    TheArcNeedle.Width = value;
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
                graphics.ArcRenderRanges(ClientRectangle, TheArcNeedle.Center, TheBand.Start, TheBand.Sweep, TheGuage.MinimumValue, TheGuage.MaximumValue, TheArcRanges);
                graphics.RenderArcBand(ClientRectangle, TheArcNeedle.Center, TheBand.Radius, TheBand.Start, TheBand.Sweep, TheBand.Width, TheBand.Color);

                graphics.RenderArcScaleLines(
                                                ClientRectangle, TheArcNeedle.Center,
                                                TheArcScaleLinesMinor.TickOuterRadius, TheArcScaleLinesMinor.TickInnerRadius, TheArcScaleLinesMinor.TickWidth, TheArcScaleLinesMinor.TickForeColor, TheArcScaleLinesMinor.NumOfTicks,
                                                TheArcScaleLinesIntermediate.TickOuterRadius, TheArcScaleLinesIntermediate.TickInnerRadius, TheArcScaleLinesIntermediate.TickWidth, TheArcScaleLinesIntermediate.TickForeColor,
                                                TheArcScaleLinesMajor.TickOuterRadius, TheArcScaleLinesMajor.TickInnerRadius, TheArcScaleLinesMajor.TickWidth, TheArcScaleLinesMajor.TickForeColor, TheArcScaleLinesMajor.StepValue,
                                                TheGuage.MinimumValue, TheGuage.MaximumValue, TheBand.Start, TheBand.Sweep
                );

                graphics.RenderArcScaleNumbers(
                                                ClientRectangle,
                                                Font,
                                                TheArcScaleNumber.Color,
                                                TheFontBound,
                                                TheArcNeedle.Center,
                                                TheArcScaleNumber.Radius,
                                                TheGuage.MinimumValue,
                                                TheGuage.MaximumValue,
                                                TheArcScaleNumber.Format,
                                                TheArcScaleNumber.StartScaleLine,
                                                TheArcScaleLinesMajor.StepValue,
                                                TheBand.Start,
                                                TheBand.Sweep,
                                                TheArcScaleNumber.Orientation
                );

                graphics.RenderCaptions(ClientRectangle, Font, TheCaptions);
                graphics.RenderArcNeedle(ClientRectangle, TheArcNeedle.Center, TheArcNeedle.Radius, TheArcNeedle.Width, TheGuage.MinimumValue, TheGuage.MaximumValue, TheBand.Start, TheBand.Sweep, TheArcNeedle.Type, TheArcNeedle.Color, TheGuage.Value);

                PaintEventArgs.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            }
        }
        #endregion
    }
}
