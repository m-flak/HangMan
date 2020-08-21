using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    public class Word
    {
        private readonly char[] letters;
        private readonly byte[] mask;

        public Word(string word)
        {
            letters = word.ToLower().ToCharArray();
            mask = new byte[letters.Length];
        }

        public string GetWord()
        {
            var maskedLetters = letters.Select((letter, index) => mask[index] == 1 ? letter : '*');

            return new string(maskedLetters.ToArray());
        }

        public bool UnmaskLetter(char letter)
        {
            bool letterUnmasked = false;

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter)
                {
                    letterUnmasked |= true;
                    mask[i] = 1;
                }
            }

            return letterUnmasked;
        }

        public string GetWordWithoutMask()
        {
            return new string(letters);
        }

        public int GetLettersRemaining()
        {
            return mask.Where(m => m == 0).Count();
        }
    }
}
