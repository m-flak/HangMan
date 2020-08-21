using System;
using System.Collections.Generic;
using System.Text;
using HangMan;
using NUnit;
using NUnit.Framework;

namespace HangMan.Tests
{
    [TestFixture]
    class WordTests
    {
        [Test]
        public void GetWordUnsolvedTest()
        {
            var word = new Word("Shaman");

            Assert.AreEqual("******", word.GetWord());
        }

        [Test]
        public void GetWordWithoutMaskTest()
        {
            const string text = "Shaman";
            var word = new Word(text);

            Assert.AreEqual(text.ToLower(), word.GetWordWithoutMask());
        }

        [Test]
        public void UnmaskLetterCaseSensitivityTest()
        {
            var word = new Word("Shaman");

            Assert.IsTrue(word.UnmaskLetter('s'));
            Assert.AreEqual("s*****", word.GetWord());
        }

        [Test]
        public void UnmaskLetterSameLettersTest()
        {
            var word = new Word("Pummel");

            Assert.IsTrue(word.UnmaskLetter('m'));
            Assert.AreEqual("**mm**", word.GetWord());
        }

        [Test]
        public void GetLettersRemainingTest()
        {
            var word = new Word("deleveled");

            word.UnmaskLetter('d');
            Assert.AreEqual(7, word.GetLettersRemaining());

            word.UnmaskLetter('e');
            Assert.AreEqual(3, word.GetLettersRemaining());
        }
    }
}
