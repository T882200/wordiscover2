using System;
using Microsoft.Office.Tools.Ribbon;

namespace ProximitySearchAddin
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnProximitySearch_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ShowProximitySearch();
        }
    }
}
