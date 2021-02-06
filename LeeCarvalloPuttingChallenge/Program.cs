using System;
using System.Threading;

namespace LeeCarvalloPuttingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool putter = false;
            bool iron = false;
            bool driver = false;
            int strokes = 0;
            string userInput;
            int x = 0;

            string[] holeOne = { "0000000000", "00SS.P.000", "00SS...000", "000///0000", "00////00SS", "00////00SS", "00///000SS", "000*000000" };

            Console.WriteLine("WELCOME TO LEE CARVALLO'S PUTTING CHALLENGE!");
            Thread.Sleep(2900);

            //while (x < 4)
            //{
                //first hole
                

                /*
                 *            #
                0000000000    0
                00SS.P.000    1
                00SS...000    2
                000///0000    3
                00////00WW    4
                00////00WW    5
                00///000WW    6
                000*000000    7
                */

                foreach (var item in holeOne) //draw course
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nSTROKES:{strokes}\n MAP:   / fairway   0 rough  . green   * places ball has been   P  flag  S  sand");
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");


                Console.WriteLine("What club are you using next?  i=iron d=driver p=putter");
                userInput = Console.ReadLine();  //input club
                Thread.Sleep(500);
                Console.WriteLine("\n\n");


                switch (userInput) //assign which club is being used based on userInput
                {
                    case "i":
                        iron = true;
                        putter = false;
                        driver = true;
                        break;
                    case "p":
                        putter = true;
                        iron = false;
                        driver = false;
                        break;
                    case "d":
                        driver = true;
                        putter = false;
                        iron = false;
                        break;
                    default:
                        iron = true;
                        driver = false;
                        putter = false;
                        break;
                }


                if (putter)  //read which club is being used and update the map
                {
                    holeOne[6] = "00/*/000SS";
                }
                else if (iron)
                {
                    holeOne[4] = "00//*/00SS";
                }
                else //driver
                {
                    holeOne[2] = "00SS*..000";
                }


                //end of first hole
                strokes++;
                x++;
            //}






            //experiment second stroke, FIRST STROKE WAS IRON
            /*
                     *            #
                    0000000000    0
                    00SS.P.000    1
                    00SS...000    2
                    000///0000    3
                    00//^/00SS    4
                    00////00WW    5
                    00///000WW    6
                    000^000000    7
                    */


            foreach (var item in holeOne) //draw course
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nSTROKES:{strokes}\n MAP:   / fairway   0 rough  . green   * places ball has been   P  flag  S  sand");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            Console.WriteLine("What club are you using next?  i=iron d=driver p=putter");
            userInput = Console.ReadLine();  //input club
            Thread.Sleep(500);
            Console.WriteLine("\n\n");


            switch (userInput) //assign which club is being used based on userInput
            {
                case "i":
                    iron = true;
                    putter = false;
                    driver = true;
                    break;
                case "p":
                    putter = true;
                    iron = false;
                    driver = false;
                    break;
                case "d":
                    driver = true;
                    putter = false;
                    iron = false;
                    break;
                default:
                    iron = true;
                    driver = false;
                    putter = false;
                    break;
            }

            
            if (putter)  //read which club is being used and update the map
            {
                holeOne[3] = "000/*/0000"; //done
            }
            
            
            if (iron)
            {
                holeOne[1] = "00SS.P*000";
            }
            else //driver
            {
                holeOne[0] = "0000000000";
            }

            strokes++;
            Thread.Sleep(3000);

        }
    }
}
    

