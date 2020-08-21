using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangMan
{
    public class WordList : IWordList
    {
        private readonly string[] wordList;

        public static WordList LoadWordList(string pathToWordList)
        {
            try
            {
                var absPath = Path.GetFullPath(pathToWordList);

                var readWords = new List<string>();
                using (StreamReader file = new StreamReader(absPath))
                {
                    while (!file.EndOfStream)
                    {
                        readWords.Add(file.ReadLine());
                    }
                }

                return new WordList(readWords.ToArray());
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public string PickRandomWord()
        {
            string randomWord;
            int randomIndex = new Random().Next(wordList.Length);

            try
            {
                randomWord = wordList[randomIndex];
            }
            catch (IndexOutOfRangeException)
            {
                randomWord = wordList[0];
            }

            return randomWord;
        }

        public bool IsEmpty()
        {
            return wordList.Length == 0;
        }

        protected WordList(string[] list)
        {
            wordList = list;
        }
    }
}
