using System;

namespace HangMan
{
    internal class Program
    {
        private const int EXIT_OK = 0;
        private const int EXIT_BAD = 1;

        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ERROR: No wordlist document provided!");
                Console.WriteLine("Please provide a wordlist to play HangMan with.");
                return EXIT_BAD;
            }

            WordList wordList;
            try
            {
                wordList = WordList.LoadWordList(args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return EXIT_BAD;
            }
            if (wordList.IsEmpty())
            {
                Console.WriteLine("ERROR: The wordlist document is empty!");
                Console.WriteLine("Please provide a wordlist that contains some words.");
                return EXIT_BAD;
            }

            HangManGame game = new HangManGame(wordList);
            game.Run();

            return EXIT_OK;
        }
    }
}
