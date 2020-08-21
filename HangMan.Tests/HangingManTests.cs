using System;
using System.Collections.Generic;
using System.Text;
using HangMan;
using NUnit;
using NUnit.Framework;

namespace HangMan.Tests
{
    [TestFixture]
    public class HangingManTests
    {
        [Test]
        public void FullStickFigureTest()
        {
            HangingMan hangingMan = new HangingMan();
            string[] deadStickFigure = { "|--| ",
                                         "|  O ",
                                         "| /|\\",
                                         "| /\\ " 
                                       };

            hangingMan.SubtractLife(); // HEAD
            hangingMan.SubtractLife(); // TORSO
            hangingMan.SubtractLife(); // RIGHT ARM
            hangingMan.SubtractLife(); // LEFT ARM
            hangingMan.SubtractLife(); // RIGHT LEG
            hangingMan.SubtractLife(); // LEFT LEG

            Assert.AreEqual(deadStickFigure, hangingMan.GetStickFigure());
        }

        [Test]
        public void ResetStickFigureTest()
        {
            HangingMan hangingMan = new HangingMan();
            string[] initialStickFigure = hangingMan.GetStickFigure();

            hangingMan.SubtractLife(); // HEAD
            hangingMan.SubtractLife(); // TORSO
            hangingMan.SubtractLife(); // RIGHT ARM
            hangingMan.SubtractLife(); // LEFT ARM
            hangingMan.SubtractLife(); // RIGHT LEG
            hangingMan.SubtractLife(); // LEFT LEG

            string[] deadStickFigure = hangingMan.GetStickFigure();

            hangingMan.ResetStickFigure();
            Assert.AreNotEqual(deadStickFigure, hangingMan.GetStickFigure());
            Assert.AreEqual(initialStickFigure, hangingMan.GetStickFigure());
        }
    }
}
