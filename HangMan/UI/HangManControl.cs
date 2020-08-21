using System;
using System.Collections.Generic;
using System.Text;
using DustInTheWind.ConsoleTools;


namespace HangMan.UI
{
    public class HangManControl : BlockControl
    {
        private readonly HangingMan hangingMan;
        private bool hasLostLife = false;

        public HangManControl(HangingMan hangingMan)
        {
            this.hangingMan = hangingMan;

            BeforeDisplay += HangManControl_BeforeDisplay;
            hangingMan.LifeLost += HangingMan_LifeLost;
        }

        private void HangingMan_LifeLost(object sender, EventArgs e)
        {
            hasLostLife = true;
        }

        private void HangManControl_BeforeDisplay(object sender, EventArgs e)
        {
            if (hasLostLife)
            {
                hasLostLife = false;

                var oldColor = CustomConsole.EmphasiesColor;
                CustomConsole.EmphasiesColor = ConsoleColor.Red;
                CustomConsole.WriteEmphasies($"That is incorrect. You may miss {hangingMan.Life} more time(s)");
                CustomConsole.WriteLine();
                CustomConsole.EmphasiesColor = oldColor;
            }
        }

        protected override void DoDisplayContent(ControlDisplay display)
        {
            foreach (string line in hangingMan.GetStickFigure())
            {
                display.WriteRow(line);
            }
        }
    }
}
