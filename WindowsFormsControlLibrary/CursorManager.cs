using System;
using System.Collections.Generic;
using System.Windows.Forms;

[System.Diagnostics.DebuggerStepThrough]
public class CursorManager {
    #region Constructors
    private CursorManager() { }
    #endregion

    #region Public Methods
    public static ICursor CreateCursor(Form form) { return new CursorContainer(form, Cursors.WaitCursor); }
    #endregion

    #region Private Classes
    private class CursorContainer : ICursor {
        #region Members
        private Form theForm = null;
        private Cursor theCursor = null;
        #endregion

        internal CursorContainer(Form argForm, Cursor argCursor) {
            theForm = argForm;
            if (theForm == null) return;
            theCursor = theForm.Cursor;
            theForm.Cursor = argCursor;
        }

        #region IDisposable Members
        public void Dispose() {
            try {
                if (theCursor == null) return;
                theForm.Cursor = theCursor;
            } catch { }
        }
        #endregion
    }
    #endregion
}

#region Public Interfacas
public interface ICursor : IDisposable { }
#endregion