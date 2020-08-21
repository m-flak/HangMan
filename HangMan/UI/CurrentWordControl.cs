using System;
using System.Collections.Generic;
using System.Text;
using DustInTheWind.ConsoleTools;

namespace HangMan.UI
{
    public class CurrentWordControl : Label
    {
        private const string STATIC_TEXT = "The word is:";

        public void ChangeDisplayedWord(string word)
        {
            this.Text = $"{STATIC_TEXT} {word}";
        }
    }
}
