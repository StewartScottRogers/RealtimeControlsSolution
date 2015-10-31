using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WindowsFormsControlLibrary {
    [Designer(typeof(RadioButtonControl.CustomControlDesigner))]
    [ToolboxBitmapMisc]
    [DefaultEvent("DialValueChanged")]
    public partial class RadioButtonControl : UserControl {
        #region Public Events

        #endregion

        public RadioButtonControl() {
            InitializeComponent();
        }

        #region Public Properties
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button"),
        System.ComponentModel.Description("The caption.")]
        public String Caption {
            get { return customControlRadialButton1.Caption1Text; }
            set { customControlRadialButton1.Caption1Text = value; }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Radio Button"),
        System.ComponentModel.Description("The checked value.")]
        public Boolean Checked {
            get { return this.customControlRadialButton1.Checked; }
            set { customControlRadialButton1.Checked = value; }
        }
        #endregion

        #region Private Event Handlers

        #endregion

        #region CustomControlDesigner
        private class CustomControlDesigner : ControlDesigner {
            public CustomControlDesigner() { }
            protected override void PostFilterEvents(IDictionary events) {
                events.Remove("AutoSizeChanged");
                events.Remove("AutoValidateChanged");
                events.Remove("BackColorChanged");
                events.Remove("BackgroundImageChanged");
                events.Remove("BackgroundImageLayoutChanged");
                events.Remove("BindingContextChanged");
                events.Remove("CausesValidationChanged");
                events.Remove("ChangeUICues");
                events.Remove("Click");
                events.Remove("ClientSizeChanged");
                events.Remove("ContextMenuStripChanged");
                events.Remove("ControlAdded");
                events.Remove("ControlRemoved");
                events.Remove("CursorChanged");
                events.Remove("DockChanged");
                events.Remove("DoubleClick");
                events.Remove("DragDrop");
                events.Remove("DragEnter");
                events.Remove("DragLeave");
                events.Remove("DragOver");
                events.Remove("EnabledChanged");
                events.Remove("Enter");
                events.Remove("FontChanged");
                events.Remove("ForeColorChanged");
                events.Remove("GiveFeedback");
                events.Remove("HelpRequested");
                events.Remove("ImeModeChanged");
                events.Remove("KeyDown");
                events.Remove("KeyPress");
                events.Remove("KeyUp");
                events.Remove("Layout");
                events.Remove("Leave");
                events.Remove("Load");
                events.Remove("LocationChanged");
                events.Remove("MarginChanged");
                events.Remove("MouseCaptureChanged");
                events.Remove("MouseClick");
                events.Remove("MouseDoubleClick");
                events.Remove("MouseDown");
                events.Remove("MouseEnter");
                events.Remove("MouseHover");
                events.Remove("MouseLeave");
                events.Remove("MouseMove");
                events.Remove("MouseUp");
                events.Remove("Move");
                events.Remove("PaddingChanged");
                events.Remove("Paint");
                events.Remove("ParentChanged");
                events.Remove("PreviewKeyDown");
                events.Remove("CloseOnKeyPreviewMatch");
                events.Remove("QueryAccessibilityHelp");
                events.Remove("QueryContinueDrag");
                events.Remove("RegionChanged");
                events.Remove("Resize");
                events.Remove("RightToLeftChanged");
                events.Remove("Scroll");
                events.Remove("SizeChanged");
                events.Remove("StyleChanged");
                events.Remove("SystemColorsChanged");
                events.Remove("TabIndexChanged");
                events.Remove("TabStopChanged");
                events.Remove("Validated");
                events.Remove("Validating");
                events.Remove("VisibleChanged");

                base.PostFilterEvents(events);
            }
            protected override void PostFilterProperties(IDictionary Properties) {
                Properties.Remove("AccessibleDescription");
                Properties.Remove("AccessibleName");
                Properties.Remove("AccessibleRole");
                Properties.Remove("AllowDrop");
                Properties.Remove("ApplicationSettings");
                Properties.Remove("AutoScroll");
                Properties.Remove("AutoScrollMargin");
                Properties.Remove("AutoScrollMinSize");
                Properties.Remove("AutoSize");
                Properties.Remove("AutoSizeMode");
                Properties.Remove("AutoValidate");
                Properties.Remove("BackColor");
                Properties.Remove("BackgroundImage");
                Properties.Remove("BackgroundImageLayout");
                Properties.Remove("BorderStyle");
                Properties.Remove("CausesValidation");
                Properties.Remove("ContextMenu");
                Properties.Remove("ContextMenuStrip");
                Properties.Remove("Cursor");
                Properties.Remove("DataBindings");
                Properties.Remove("Font");
                Properties.Remove("ForeColor");
                Properties.Remove("FlatStyle");
                Properties.Remove("GenerateMember");
                Properties.Remove("Image");
                Properties.Remove("ImageAlign");
                Properties.Remove("ImageIndex");
                Properties.Remove("ImageList");
                Properties.Remove("ImeMode");
                Properties.Remove("Margin");
                Properties.Remove("Modifiers");
                Properties.Remove("MaximumSize");
                Properties.Remove("MinimumSize");
                Properties.Remove("Padding");
                Properties.Remove("RightToLeft");
                Properties.Remove("Tag");
                Properties.Remove("Text");
                Properties.Remove("TextAlign");
                Properties.Remove("UseWaitCursor");
            }
        }
        #endregion
    }
}