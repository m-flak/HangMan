using System;
using System.Collections.Generic;
using System.Text;
using DustInTheWind.ConsoleTools;

namespace HangMan.UI
{
    public class GameOverScreen : BlockControl
    {
        public bool Won { get; set; } = false;

        protected override void DoDisplayContent(ControlDisplay display)
        {
            var oldColor = CustomConsole.EmphasiesColor;

            if (Won)
            {
                CustomConsole.EmphasiesColor = ConsoleColor.Green;
                CustomConsole.WriteEmphasies("CONGRATULATIONS! YOU WON!!!");
                CustomConsole.WriteLine();
            }
            else
            {
                CustomConsole.EmphasiesColor = ConsoleColor.Red;
                CustomConsole.WriteEmphasies("YOU LOST... :(");
                CustomConsole.WriteLine();
            }

            CustomConsole.EmphasiesColor = oldColor;
        }
    }
}
