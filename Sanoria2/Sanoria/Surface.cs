using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sanoria
{
    static class Surface
    {
        // Clear Level + count

        public static void nextLevel(ref TextBlock TBLevel, int currentLevel, ref TextBlock CALCEquation, string newLevel, ref TextBox CALCResult, ref TextBlock CALCInfo)
        {
            TBLevel.Text = "Round " + currentLevel;
            CALCEquation.Text = newLevel;
            CALCResult.Text = null;
            CALCInfo.Text = null;
            CALCResult.Focus();
        }

        public static void retry(ref TextBlock CALCInfo, ref TextBox CALCResult)
        {
            CALCInfo.Text = "WRONG ANSWER";
            CALCResult.Text = "";
        }
    }
}
