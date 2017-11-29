using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try3
{
    class Program
    {
        const int razr = 3;
        static int[] a;
        
        static void Draw()
        {
            for (int i=0;i<razr;i++)
            {
                for (int j=0; j<razr; j++)
                    switch (a[i*razr+j])
                    {
                        case -1:
                            Console.Write("X ");
                            break;
                        case 0:
                            Console.Write("O ");
                            break;
                        default:
                            Console.Write(a[i * razr + j] + " ");
                            break;
                    }
                Console.WriteLine();
            }
        }

        static void activeUser(bool turn)
        {
            int w = 0;
            do
            {
                if (int.TryParse(Console.ReadLine(), out w) && w > 0 && w <= razr*razr && a[w - 1] > 0)
                    a[w - 1] = turn ? -1 : 0;
                else
                    w = 0;
            }
            while (w == 0);
        }
        static void activeUserPC(bool turn)
        {
            int w = 0;
            Random rnd = new Random();
            do
            {
                w = rnd.Next(0, 10);
                if ( w > 0 && w <= razr * razr && a[w - 1] > 0)
                    a[w - 1] = turn ? -1 : 0;
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
                if (((a[0] == -1) && (a[1] == -1) && (a[2] == -1)) || ((a[3] == -1) && (a[4] == -1)
                    && (a[5] == -1)) || ((a[6] == -1) && (a[7] == -1) && (a[8] == -1)) || ((a[0] == -1) && (a[3] == -1) && (a[6] == -1))
                    || ((a[1] == -1) && (a[4] == -1) && (a[7] == -1)) || ((a[2] == -1) && (a[5] == -1) && (a[8] == -1))
                    || ((a[0] == -1) && (a[4] == -1) && (a[8] == -1)) || ((a[2] == -1) && (a[4] == -1) && (a[6] == -1)))
                {
                    result = true;
                    Console.WriteLine("X wIN");
                }
                else if (((a[0] == 0) && (a[1] == 0) && (a[2] == 0)) || ((a[3] == 0) && (a[4] == 0)
                    && (a[5] == 0)) || ((a[6] == 0) && (a[7] == 0) && (a[8] == 0)) || ((a[0] == 0) && (a[3] == 0) && (a[6] == 0))
                    || ((a[1] == 0) && (a[4] == 0) && (a[7] == 0)) || ((a[2] == 0) && (a[5] == 0) && (a[8] == 0))
                    || ((a[0] == 0) && (a[4] == 0) && (a[8] == 0)) || ((a[2] == 0) && (a[4] == 0) && (a[6] == 0)))
                {
                    result = true;
                    Console.WriteLine("0 wIN");
                }


                return result;
            }
        }

        static void gameMode()
        {
            a = new int[razr * razr] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int s = razr * razr;
            int mode = 0;
            bool turn = true;

            
            Console.WriteLine("Choose player : press 1 for 1vs1 / press 2 for 1vsPC");
            mode = Convert.ToInt32(Console.ReadLine());
            if (mode == 1)
            {
                Draw();
                while (s > 0)
                {
                    activeUser(turn);
                    Draw();
                    if (Check)
                        break;

                    turn = !turn;
                    s--;
                }

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(a[i] + " ");
                }
            }
            else if (mode == 2)
            {
                Draw();
                while (s>0)
                {

                    if (s%2==1)
                    {
                        activeUser(turn);
                        Draw();
                        if (Check)
                            break;
                        turn = !turn;
                        s--;
                    }
                    else if (s%2==0)
                    {
                        activeUserPC(turn);
                        Console.WriteLine();
                        Draw();
                        

                        if (Check)
                            break;
                        turn = !turn;
                        s--;
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

