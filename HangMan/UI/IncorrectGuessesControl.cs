using System;
using System.Collections.Generic;
using System.Text;
using DustInTheWind.ConsoleTools;

namespace HangMan.UI
{
    public class IncorrectGuessesControl : Label
    {
        private const string STATIC_TEXT = "Previous incorrect guesses were: ";

        public void UpdateIncorrectGuesses(ISet<string> incorrectGuesses)
        {
            string guessesString = "";
            foreach (string s in incorrectGuesses)
            {
                guessesString += $" {s}";
            }

            this.Text = STATIC_TEXT + guessesString;
        }

        public void ResetIncorrectGuesses()
        {
            this.Text = STATIC_TEXT;
        }

        protected override void DoDisplayContent()
        {
            base.DoDisplayContent();
            CustomConsole.WriteLine();
        }
    }
}
