using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try3
{
    class Program
    {
        const int sizeOfField = 3;
        static XOCell[] gameField;
        public enum XOCell {X, O, Empty};

        static void Draw()
        {
            for (int i = 0; i < sizeOfField; i++)
            {
                for (int j = 0; j < sizeOfField; j++)
                {
                    switch (gameField[i * sizeOfField + j])
                    {
                        case XOCell.X: Console.Write("X "); break;
                        case XOCell.O:  Console.Write("O "); break;
                        case XOCell.Empty: Console.Write("- "); break;
                    }    
                }
                Console.WriteLine();
            }
        }

        static void IsActiveUser(bool turn)
        {
            int enteredValue = 0;
            do
            {
                if (int.TryParse(Console.ReadLine(), out enteredValue) && enteredValue > 0 && enteredValue <= 9 && gameField[enteredValue - 1] == XOCell.Empty)
                {
                    gameField[enteredValue - 1] = turn ? XOCell.X : XOCell.O;
                }
                else
                {
                    enteredValue = 0;
                }
            }
            while (enteredValue == 0);
        }

        static void ActiveUserPC(bool turn)
        {
            int randomizedValue = 0;
            Random rnd = new Random();
            do
            {
                randomizedValue = rnd.Next(0, 10);
                if (randomizedValue > 0 && randomizedValue <= 9 && gameField[randomizedValue - 1] == XOCell.Empty)
                {
                    gameField[randomizedValue - 1] = turn ? XOCell.X : XOCell.O;
                }
                else
                {
                    randomizedValue = 0;
                }
            }

            while (randomizedValue == 0);
        }

        static bool Check(bool turn)
        {
            XOCell checkingValue;
            checkingValue = turn ? XOCell.X : XOCell.O;
            bool result = false;
            if ( (((gameField[0] == gameField[1]) && (gameField[1] == gameField[2]))&& (gameField[2] == checkingValue) || (gameField[3] == gameField[4]) && (gameField[4] == gameField[5]) && (gameField[5] == checkingValue)
                || (gameField[6] == gameField[7]) && (gameField[7] == gameField[8]) && (gameField[8] == checkingValue) || (gameField[0] == gameField[3]) && (gameField[3] == checkingValue) && (gameField[3] == gameField[6]) && (gameField[6] == checkingValue)
                || (gameField[1] == gameField[4]) && (gameField[4] == gameField[7]) && (gameField[7] == checkingValue) || (gameField[2] == gameField[5]) && (gameField[5] == gameField[8]) && (gameField[8] == checkingValue) && (gameField[8] == checkingValue)
                || (gameField[0] == gameField[4]) && (gameField[4] == gameField[8]) && (gameField[8] == checkingValue) || (gameField[2] == gameField[4]) && (gameField[4] == checkingValue) && (gameField[4] == gameField[6]) && (gameField[6] == checkingValue)))
            {
                Console.WriteLine(turn ? "X win" : "0 win");
                result = true;
            }

            return result;
        }

        static void GameMode()
        {
            gameField = new XOCell[sizeOfField * sizeOfField] { XOCell.Empty, XOCell.Empty, XOCell.Empty,
                XOCell.Empty, XOCell.Empty, XOCell.Empty, XOCell.Empty, XOCell.Empty, XOCell.Empty };
            int turnsLeft = sizeOfField * sizeOfField;
            int mode = 0;
            bool turn = true;
            Console.WriteLine("Choose player : press 1 for 1vs1 / press 2 for 1vsPC");
            mode = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                Draw();
                while (turnsLeft > 0)
                {
                    IsActiveUser(turn);
                    Draw();
                    if (Check(turn))
                    {
                        break;
                    }

                    turn = !turn;
                    turnsLeft--;
                }
            }
            else if (mode == 2)
            {
                Draw();
                while (turnsLeft > 0)
                {
                    if (turnsLeft % 2 == 1)
                    {
                        IsActiveUser(turn);
                        Draw();
                        if (Check(turn))
                        {
                            break;
                        }

                        turn = !turn;
                        turnsLeft--;
                    }
                    else if (turnsLeft % 2 == 0)
                    {
                        ActiveUserPC(turn);
                        Console.WriteLine();
                        Draw();
                        if (Check(turn
                            ))
                        {
                            break;
                        }

                        turn = !turn;
                        turnsLeft--;
                    }
                }
            }
            else
            {
                Console.WriteLine("invalid, try choose correctly");
                GameMode();
            }
        }

        static void Main(string[] args)
        {
            GameMode();
            Console.ReadKey();
        }
    }
}

