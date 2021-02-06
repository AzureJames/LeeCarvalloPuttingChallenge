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
        static int firstPlayerPosition = 0;
        static int point = 0;

        static void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
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

        private static void MoveBall()
        {
            ballPositionX += ballDirectionX;
            ballPositionY += ballDirectionY;

           
        }

        static void BallRight ()
        {
            ballDirectionX = 1;
            ballDirectionY = 0;
        }

        static void BallLeft()
        {
            ballDirectionX = -1;
            ballDirectionY = 0;
        }

        static void BallUp()
        {
            ballDirectionX = 0;
            ballDirectionY = 1;
        }

        static void BallDown()
        {
            ballDirectionX = 0;
            ballDirectionY = -1;
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
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;
            RemoveScrollBars();
            Init();
            
            int lineCounter = 0;
            Console.WriteLine(" ,    ,  .  , .    ,   <||   .,  , ,  .  , ,      ");
            Console.WriteLine(" ,  , .  ,  .  , .      ||    .,  , ,  .  ,    . ,");
            while (lineCounter < 13)

            {
                Console.WriteLine(" ,  ,   ,  .  , .   .  ,  .  .,  , ,  .  ,  .  , ,");
                Console.WriteLine(". ,  , .  ,  .  , .   .     .,  , ,  .  ,  .  .   ");
                lineCounter++;
            }

            new Thread(() =>
            {
                while (true)
                {

                    if (Console.KeyAvailable)
                    {
                        RemoveBall();
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            point++;
                            BallRight();
                            MoveBall();
                            
                        }
                        if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            point++;
                            BallLeft();
                            MoveBall();
                            
                        }
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            point++;
                            BallDown();
                            MoveBall();
                            
                        }
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            point++;
                            BallUp();
                            MoveBall();
                            
                        }
                        DrawBall();

                        if (ballPositionY== 1 && ballPositionX >= 24 && ballPositionX <=25)
                        {
                            Console.Write($"\n\n\n\nscore:{point}");
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