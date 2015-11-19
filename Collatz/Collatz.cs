using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Optimized with help from: http://stackoverflow.com/questions/12360625/algorithm-guidance-with-3n1-conjecture
 * 
 * Collatz Conjecture Cycle length calculator
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */


namespace Collatz
{
    class Collatz
    {
        static int Main(string[] args)
        {
            if (args.Length == 2) //Two parameters
            {
                StreamWriter writer = new StreamWriter("collatz.txt");
                writer.AutoFlush = true;

                int min = int.Parse(args[0]), max = int.Parse(args[1]) + 1;

                Console.WriteLine("Writing to file. Range is (" + args[0] + ", " + args[1] + ").");
                var startTime = DateTime.Now;

                for (int i = min; i < max; i++)
                {
                    //writer.WriteLine(i + ": " + GetCycleLength(i));
                    writer.WriteLine(i + " " + GetCycleLength(i));
                }
                Console.WriteLine("Done!");
                var totalSeconds = (DateTime.Now - startTime).TotalSeconds;
                Console.WriteLine("Program took {0} seconds to run", totalSeconds);
                writer.Close();

            }
            else if (args.Length == 1) //Single parameter
            {
                int value = int.Parse(args[0]);

                Console.WriteLine("Calculating length of cycle for: " + value);
                var startTime = DateTime.Now;
                Console.WriteLine(GetCycleLength (value) );
                Console.WriteLine("Done!");
                var totalSeconds = (DateTime.Now - startTime).TotalSeconds;
                Console.WriteLine("Program took {0} seconds to run", totalSeconds);
            }
            else if (args.Length >= 3) //Too many parameters
            {
                PrintUsage();
                Console.WriteLine("Too many parameters given!");
            }
            else //No parameters given
            {
                PrintUsage();  
            }
            return 0;
        }

        static void collatz(ref int n)
        {
            if (n % 2 == 0) //Even numbers
            {
                n /= 2;
            }
            else //Odd numbers
            {
                n = (3 * n) + 1;
            }
            //Console.WriteLine(n);
        }

        static string GetCycleLength(int n)
        {
            if (n > 0)
            {
                int count = 1;
                while (n != 1)
                {
                    collatz(ref n);
                    count++;
                }
                //string next =  "Cycle Length is: " + count;
                string next = count.ToString();
                return next;
            }
            else 
            {
                string ex = "";
                return ex;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("Collatz.exe minimum maximum");
            Console.WriteLine("Collatz.exe collatzCalc");
            Environment.ExitCode = -1;
        }
    }
}
