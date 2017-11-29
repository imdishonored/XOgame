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
        static int[] gameField;

        static void Draw()
        {
            for (int i = 0; i < sizeOfField; i++)
            {
                for (int j = 0; j < sizeOfField; j++)
                    switch (gameField[i * sizeOfField + j])
                    {
                        case -1:    Console.Write("X ");    break;
                        case 0:     Console.Write("O ");    break;
                        default:    Console.Write(gameField[i * sizeOfField + j] + " ");    break;
                    }
                Console.WriteLine();
            }
        }

        static void IsActiveUser(bool turn)
        {
            int enteredTurn = 0;
            do
            {
                if (int.TryParse(Console.ReadLine(), out enteredTurn) && enteredTurn > 0 && enteredTurn <= sizeOfField * sizeOfField && gameField[enteredTurn - 1] > 0)
                    gameField[enteredTurn - 1] = turn ? -1 : 0;
                else
                    enteredTurn = 0;
            }
            while (enteredTurn == 0);
        }
        static void activeUserPC(bool turn)
        {
            int w = 0;
            Random rnd = new Random();
            do
            {
                w = rnd.Next(0, 10);
                if (w > 0 && w <= sizeOfField * sizeOfField && gameField[w - 1] > 0)
                    gameField[w - 1] = turn ? -1 : 0;
                else
                    w = 0;
            }
            while (w == 0);
        }

        static bool Check
        {
            get
            {
                bool result = false;
                if (((gameField[0] == -1) && (gameField[1] == -1) && (gameField[2] == -1)) || ((gameField[3] == -1) && (gameField[4] == -1)
                    && (gameField[5] == -1)) || ((gameField[6] == -1) && (gameField[7] == -1) && (gameField[8] == -1)) || ((gameField[0] == -1) && (gameField[3] == -1) && (gameField[6] == -1))
                    || ((gameField[1] == -1) && (gameField[4] == -1) && (gameField[7] == -1)) || ((gameField[2] == -1) && (gameField[5] == -1) && (gameField[8] == -1))
                    || ((gameField[0] == -1) && (gameField[4] == -1) && (gameField[8] == -1)) || ((gameField[2] == -1) && (gameField[4] == -1) && (gameField[6] == -1)))
                {
                    result = true;
                    Console.WriteLine("X wIN");
                }
                else if (((gameField[0] == 0) && (gameField[1] == 0) && (gameField[2] == 0)) || ((gameField[3] == 0) && (gameField[4] == 0)
                    && (gameField[5] == 0)) || ((gameField[6] == 0) && (gameField[7] == 0) && (gameField[8] == 0)) || ((gameField[0] == 0) && (gameField[3] == 0) && (gameField[6] == 0))
                    || ((gameField[1] == 0) && (gameField[4] == 0) && (gameField[7] == 0)) || ((gameField[2] == 0) && (gameField[5] == 0) && (gameField[8] == 0))
                    || ((gameField[0] == 0) && (gameField[4] == 0) && (gameField[8] == 0)) || ((gameField[2] == 0) && (gameField[4] == 0) && (gameField[6] == 0)))
                {
                    result = true;
                    Console.WriteLine("0 wIN");
                }
                return result;
            }
        }

        static void gameMode()
        {
            gameField = new int[sizeOfField * sizeOfField] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
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
                    if (Check)
                        break;
                    turn = !turn;
                    turnsLeft--;
                }

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(gameField[i] + " ");
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
                        if (Check)
                            break;
                        turn = !turn;
                        turnsLeft--;
                    }
                    else if (turnsLeft % 2 == 0)
                    {
                        activeUserPC(turn);
                        Console.WriteLine();
                        Draw();
                        if (Check)
                            break;
                        turn = !turn;
                        turnsLeft--;
                    }
                }
            }
            else
            {
                Console.WriteLine("invalid, try choose correctly");
                gameMode();
            }
        }

        static void Main(string[] args)
        {
            gameMode();
            Console.ReadKey();
        }
    }
}

