using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreakOut
{
    class Program
    {
        static object lockObject = new object();
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        static int ballDirectionX = -1;
        static int ballDirectionY = 1;
        static int point = 0;
        static int clubLength = 10;
        static int clubDrift = 1;
        Random randomLength = new Random();

        static void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth  -12;
            ballPositionY = Console.WindowHeight -8;
        }

        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void Init()
        {
            point = 0;
           
           
            SetBallAtTheMiddleOfTheGameField();
           
           
        }

        static void DrawPaddle()
        {
            for (int x = 8; x < 9; x++)
            {
                PrintAtPosition(x, Console.WindowHeight - 32, '|');
                PrintAtPosition(x, Console.WindowHeight - 33, '#');
            }
            //PrintAtPosition(68, Console.WindowHeight - 32, '\');
            //PrintAtPosition(68, Console.WindowHeight - 32, ' \');
            //PrintAtPosition(68, Console.WindowHeight - 32, '  = ');
            //PrintAtPosition(68, Console.WindowHeight - 32, 'CLUB: IRON  ');
            Console.SetCursorPosition(69, Console.WindowHeight - 35);
            Console.WriteLine("\\");
            Console.SetCursorPosition(69, Console.WindowHeight - 34);
            Console.WriteLine(" \\");
            if (clubLength == 1)
            {
                Console.SetCursorPosition(69, Console.WindowHeight - 33);
                Console.WriteLine("  -- ");
                Console.SetCursorPosition(69, Console.WindowHeight - 32);
                Console.WriteLine("PUTTER");
            }
            if (clubLength == 5)
            {
                Console.SetCursorPosition(69, Console.WindowHeight - 33);
                Console.WriteLine("  -= ");
                Console.SetCursorPosition(69, Console.WindowHeight - 32);
                Console.WriteLine("IRON  ");
            }
            if (clubLength == 10)
            {
                Console.SetCursorPosition(69, Console.WindowHeight - 33);
                Console.WriteLine("  <@>");
                Console.SetCursorPosition(69, Console.WindowHeight - 32);
                Console.WriteLine("DRIVER");
            }
            
            //Console.ReadLine();
        }


        static void Drift()
        {

            switch (clubDrift)
            {
                case 0:
                    {
                        
                        break;
                    }
                case 1:
                    {
                        
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        int driftDirection;
                        Random variableName = new Random();
                        driftDirection = variableName.Next(0, 4);
                        if(driftDirection==0)
                        {
                            ballDirectionY++;
                        }
                        else if (driftDirection == 1)
                        {
                            ballDirectionY--;
                        }
                        else if (driftDirection == 2)
                        {
                            ballDirectionX++;
                        }
                        else if (driftDirection == 3)
                        {
                            ballDirectionX--;
                        }
                        
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }




        private static void MoveBall()
        {
            ballPositionX += ballDirectionX;
            ballPositionY += ballDirectionY;
            //Console.WriteLine($"{ballDirectionX}{ballDirectionY}");

            /*
            if (|distance from center| > 50)
            {
                ballPositionX = 50*
                ballPositionY = 50*
            }
            */

            if (ballPositionX > 70)
            {
                ballPositionX = 70;
            }
            if (ballPositionX < 3)
            {
                ballPositionX = 3;
            }
            if (ballPositionY < 3)
            {
                ballPositionY = 3;
            }
            if (ballPositionY > 35)
            {
                ballPositionY = 35;
            }



        }

        static void BallRight ()
        {
            //Console.WriteLine(ballPositionX);
            ballDirectionX = 1;
            ballDirectionY = 0;
            Drift();
            
        }


        static void BallLeft()
        {
            //Console.WriteLine(ballPositionX);
            ballDirectionX = -1;
            ballDirectionY = 0;
            Drift();
            
        }

        static void BallUp()
        {
            
                //Console.WriteLine(ballPositionY);
                ballDirectionX = 0;
                ballDirectionY = 1;
                Drift();
            
        }

        static void BallDown()
        {
            
                //Console.WriteLine(ballPositionY);
                ballDirectionX = 0;
                ballDirectionY = -1;
                Drift();
            
        }



        static void PrintAtPosition(int x, int y, char symbol)
        {
            lock (lockObject)
            {
               
                Console.SetCursorPosition(x, y);
                Console.Write(symbol);
            }
        }

        static Queue<int[]> ballPath = new Queue<int[]>();

        static void RemoveBall()
        {
            int[] a;
            while (ballPath.Count > 0)
            {
                a = ballPath.Dequeue();
                PrintAtPosition(a[0], a[1], ' ');
            }
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
            ballPath.Enqueue(new int[] { ballPositionX, ballPositionY });
        }

        static void CursorAtTheStart()
        {
            Console.SetCursorPosition(0, 0);
        }

        

        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.BufferWidth = 80;
            Console.WindowHeight = 40;

            RemoveScrollBars();
            Init();
            


            int lineCounter = 0;
            Console.WriteLine(". ,  , .  ,  .  , .   .     .,  , ,  .  ,    .    , . ,  PAR:13     ");
            Console.WriteLine(" ,  ,   ,  .  , .   .  ,  .  .,  , ,  ,     .     , . , .  ,  .  , ,");
            Console.WriteLine(" ,  ,   ,  .  , .   .  ,  .  .,  , ,  ,     .     , . , .  ,  .  , ,");
            Console.WriteLine(". ,  , .  ,  .  , .   .     .,  , ,  .  ,    .    , . ,   ,  .  .   ");
            Console.WriteLine(" ,  ,   ,  .  , .   .  ,  .  .,  , ,  ,     .     , . , .  ,  .  , ,");
            Console.WriteLine(". ,  , .  ,  .  , .   .     .,  , ,  .  ,    .    , . ,   ,  .  .   ");
            Console.WriteLine(" ,  ,   ,  .  , .   .        .,  , ,  .  ,  .  , , .   , .     , . ,");
            Console.WriteLine("        #   .,  , ,  .  , ,      ,        .   , .  , . , ,   .   ,  ");
            Console.WriteLine(" ,      |    .,  , ,  .  ,    .     ,   .   ,  , . ,   .   .       ,");
            Console.WriteLine(" ,  ,   ,  .  , .   .        .,  , ,  .  ,  .  ,      . ,      . , ,");
            while (lineCounter < 13)

            {
                Console.WriteLine(" ,  ,   ,  .  , .   .  ,  .  .,  , ,  ,     .     , . , .  ,  .  , ,");
                Console.WriteLine(". ,  , .  ,  .  , .   .     .,  , ,  .  ,    .    , . ,   ,  .  .   ");
                lineCounter++;
            }



            new Thread(() =>
            {
                while (true)
                {

                    if (Console.KeyAvailable)
                    {
                        RemoveBall();
                        //these four are for hitting the ball
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            point++;
                            BallRight();
                            for (int i = 0; i < clubLength; i++)
                            {
                                Random variableName = new Random();
                                clubDrift = variableName.Next(0, 5);
                                MoveBall();
                            }
                        }
                        if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            point++;
                            BallLeft();
                            for (int i = 0; i < clubLength; i++)
                            {
                                Random variableName = new Random();
                                clubDrift = variableName.Next(0, 5);
                                MoveBall();
                            }

                        }
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            point++;
                            BallDown();
                            for (int i = 0; i < clubLength; i++)
                            {
                                Random variableName = new Random();
                                clubDrift = variableName.Next(0, 5);
                                MoveBall();
                            }

                        }
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            point++;
                            BallUp();
                            for (int i = 0; i < clubLength; i++)
                            {
                                Random variableName = new Random();
                                clubDrift = variableName.Next(0, 5);
                                MoveBall();
                            }

                        }

                        //these are for deciding the clubs 

                        //Random length = new Random();

                        

                        if (keyInfo.Key == ConsoleKey.I)
                        {
                            //Random length = new Random();

                            //static int GenerateRandomNumBetween1and6();

                            //Random variableName = new Random();

                            //clubLength = Random.Next(2, 4);

                            //clubLength= variableName.Next(2, 5);

                            clubLength = 5;
                        }

                        if (keyInfo.Key == ConsoleKey.D)
                        {
                            clubLength = 10;

                        }

                        if (keyInfo.Key == ConsoleKey.P)
                        {
                            clubLength = 1;

                        }



                        DrawPaddle();

                        DrawBall();
                        //win
                        if (ballPositionY== 8 && ballPositionX >= 7 && ballPositionX <=8)
                        {
                            Console.Write($"\n\n\n\ntotal strokes:{point}");
                        }

                    }
                }
            }).Start();

            CursorAtTheStart();

            while (true)
            {
                //RemoveBall();
                //MoveBall();

                DrawBall();
                Thread.Sleep(120);
            }
        }
    }
}