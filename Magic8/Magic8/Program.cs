using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Magic8
{
    class Program
    {
        static void Main(string[] args)
        {

            thenameoftheprogram();
            Random randomObject = new Random();
            while (true)
            {
                string thequestion = WhatTheprogramis();
                int secondstostandby = randomObject.Next(5)+1;
                Console.WriteLine("Please standby...trying to find an answer.");
                Thread.Sleep(secondstostandby * 1000);
                if (thequestion.StartsWith("why") || thequestion.StartsWith("what"))
                {
                    Console.WriteLine("You can't start the question like that in a Y/N game, Dummy!");
                    continue;
                }
                if (thequestion.StartsWith("when") && (thequestion.ToUpper()=="When" || thequestion.ToLower()=="when"))
                {
                    Console.WriteLine("When will you realize that this is a Y/N game...Jeezz");
                    continue;
                }
                if (thequestion.Length == 0)
                {
                    Console.WriteLine("You need to ask a question!");
                    continue;
                }
                if (thequestion.ToLower() == "quit")
                {
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    break;
                }
                if (thequestion.ToLower() == "you suck")
                {
                    Console.WriteLine("NO, You suck! goodbye! >:-[ ");
                    break;
                }
                int randomnumber = randomObject.Next(7) + 1;
                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (randomnumber)
                {
                    case 1:
                        {
                            Console.WriteLine("Maybe...");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Time will tell!");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Heck No!!");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Sorry...");
                            secondstostandby = randomObject.Next(2) + 1;
                            Thread.Sleep(secondstostandby * 1000);
                            Console.WriteLine("YESSSSS!!!");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Probably, If pigs can fly.");
                            break;
                        }
                    case 6:
                        Console.WriteLine("Telling from your ugly looks, seems unlikely");
                        break;
                    case 7:
                        Console.WriteLine("Ofcourse YO!!!");
                        break;

                }

            }



        }
        static string WhatTheprogramis()
        {
            Random randomObject = new Random();
            Console.ForegroundColor = (ConsoleColor)randomObject.Next(15);

            Console.Write("Ask your question: ");
            string thequestion = Console.ReadLine();
            return thequestion;
            
        }
        static void thenameoftheprogram()
        {
            Console.WriteLine("Welcome to the Magic 8 Ball game!");
        }
    }
}
