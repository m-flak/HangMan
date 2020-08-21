using System;
using System.Collections.Generic;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.InputControls;
using HangMan.UI;

namespace HangMan
{
    internal class HangManGame
    {
        private readonly HashSet<string> incorrectGuesses;
        private readonly IWordList allTheWords;
        private Word currentWord;
        private readonly HangingMan hangingMan;

        private readonly IncorrectGuessesControl incorrectGuessesControl;
        private readonly HangManControl hangManControl;
        private readonly CurrentWordControl currentWordControl;
        private readonly ValueView<char> nextGuessControl;
        private readonly GameOverScreen gameOverScreen;

        public HangManGame(IWordList wordList)
        {
            // DATA
            allTheWords = wordList;
            currentWord = new Word(allTheWords.PickRandomWord());
            hangingMan = new HangingMan();
            incorrectGuesses = new HashSet<string>();

            // CONTROLS
            incorrectGuessesControl = new IncorrectGuessesControl();

            currentWordControl = new CurrentWordControl();
            currentWordControl.ChangeDisplayedWord(currentWord.GetWord());

            nextGuessControl = new ValueView<char>("Enter your next guess: ")
            {
                TypeConversionErrorMessage = "Please enter only a single letter."
            };

            hangManControl = new HangManControl(hangingMan);
            gameOverScreen = new GameOverScreen();
        }

        public void Run()
        {
            while (currentWord.GetLettersRemaining() > 0 && hangingMan.IsDead() == false)
            {
                Console.Clear();
                if (incorrectGuesses.Count > 0)
                {
                    incorrectGuessesControl.UpdateIncorrectGuesses(incorrectGuesses);
                    incorrectGuessesControl.Display();
                }
                hangManControl.Display();
                currentWordControl.ChangeDisplayedWord(currentWord.GetWord());
                currentWordControl.Display();

                // Block awaiting input
                char letter = nextGuessControl.Read();
                
                // Update the hanging man if answer incorrect
                if (!currentWord.UnmaskLetter(letter))
                {
                    hangingMan.SubtractLife();
                    incorrectGuesses.Add($"{letter}");
                }
            }

            // The game is now over!
            Console.Clear();
            gameOverScreen.Won = !hangingMan.IsDead();
            gameOverScreen.Display();

            if (YesNoQuestion.QuickRead("Play again?", YesNoAnswer.No).HasFlag(YesNoAnswer.Yes))
            {
                incorrectGuesses.Clear();
                incorrectGuessesControl.ResetIncorrectGuesses();
                hangingMan.ResetStickFigure();
                currentWord = new Word(allTheWords.PickRandomWord());
                currentWordControl.ChangeDisplayedWord(currentWord.GetWord());
                Run();
            }
        }
    }
}
