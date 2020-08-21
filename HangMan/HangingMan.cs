using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    public class HangingMan
    {
        private const int MAX_LIFE = 6;

        private int life = MAX_LIFE;
        private char[,] stickFigure = CreateHangingMan();

        private static char[,] CreateHangingMan()
        {
            return new char[,]
            {
                {'|', '-', '-', '|', ' '},
                {'|', ' ', ' ', ' ', ' '},
                {'|', ' ', ' ', ' ', ' '},
                {'|', ' ', ' ', ' ', ' '}
            };
        }

        public event EventHandler LifeLost;

        public int Life { get => life; }

        public bool IsDead()
        {
            return life == 0;
        }

        public void SubtractLife()
        {
            if (life == 0)
            {
                return;
            }

            life -= 1;

            switch (life)
            {
                case 5:
                    ref char head = ref stickFigure[1, 3];
                    head = 'O';
                    break;
                case 4:
                    ref char torso = ref stickFigure[2, 3];
                    torso = '|';
                    break;
                case 3:
                    ref char rightArm = ref stickFigure[2, 2];
                    rightArm = '/';
                    break;
                case 2:
                    ref char leftArm = ref stickFigure[2, 4];
                    leftArm = '\\';
                    break;
                case 1:
                    ref char rightLeg = ref stickFigure[3, 2];
                    rightLeg = '/';
                    break;
                case 0:
                    ref char leftLeg = ref stickFigure[3, 3];
                    leftLeg = '\\';
                    break;
                default:
                    return;
            }

            LifeLost?.Invoke(this, EventArgs.Empty);
        }

        public void ResetStickFigure()
        {
            stickFigure = CreateHangingMan();
            life = MAX_LIFE;
        }

        public string[] GetStickFigure()
        {
            string[] stringyStickFigure = new string[4];

            for (int i = 0; i < 4; i++)
            {
                string line = "";
                for (int j = 0; j < 5; j++)
                {
                    line += this.stickFigure[i, j];
                }
                stringyStickFigure[i] = new string(line);
            }

            return stringyStickFigure;
        }
    }
}
