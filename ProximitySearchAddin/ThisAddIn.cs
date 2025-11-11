using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace ProximitySearchAddin
{
    public partial class ThisAddIn
    {
        private ProximitySearchForm _searchForm;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Initialize DocumentHelpers with the Word Application
            DocumentHelpers.Initialize(this.Application);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (_searchForm != null && !_searchForm.IsDisposed)
            {
                _searchForm.Close();
                _searchForm.Dispose();
            }
        }

        /// <summary>
        /// Show the Proximity Search dialog
        /// </summary>
        public void ShowProximitySearch()
        {
            try
            {
                if (_searchForm == null || _searchForm.IsDisposed)
                {
                    _searchForm = new ProximitySearchForm();
                }

                if (!_searchForm.Visible)
                {
                    _searchForm.Show();
                }
                else
                {
                    _searchForm.BringToFront();
                    _searchForm.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Proximity Search: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
