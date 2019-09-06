using System;
using System.Collections;
using System.Reflection;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = int.Parse(args[0]);

            var stack = new int[end];

            Recursive1(start, end);

            Console.ReadLine();
        }

        static void TryRecursive(int current, int end)
        {
            try
            {
                int tmp = 1 / (current - end);

                var modThree = (current % 3);
                var modFive = (current % 5);
                var combined = modThree + modFive;

                try
                {
                    int tmp2 = 1 / combined;

                    try
                    {
                        int tmp3 = 1 / modThree;

                        try
                        {
                            int tmp4 = 1 / modFive;

                            Console.WriteLine(current);
                        }
                        catch
                        {
                            Console.WriteLine("Buzz");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Fizz");
                    }
                }
                catch
                {
                    Console.WriteLine("FizzBuzz");
                }

                Recursive1(++current, end);
            }
            catch
            {
                Console.WriteLine("Finished");
            }
        }

        static string Current(int current)
        {
            var modThree = Math.Pow( 0, ( current % 3) );
            var modFive = Math.Pow(0, (current % 5));
            string format = $"{{{ modThree + modFive }}}";
            return string.Format(format, current, "", "" );
        }

        static string Fizz( int current )
        {
            var magic = Math.Pow(0, (current % 3));
            string format = $"{{{magic}}}";
            return string.Format(format, "", "Fizz");
        }

        static string Buzz( int current )
        {
            var magic = Math.Pow(0, (current % 5));
            string format = $"{{{magic}}}";
            return string.Format(format, "", "Buzz");
        }

        public static void Recursive0( int current, int end )
        {
            Console.WriteLine("Finished!!!");
        }

        public static void Recursive1( int current, int end )
        {
            var magic = Math.Pow(0, current - (current % end));
            string format = $"Recursive{magic}";

            var type = typeof(Program);
            var method = type.GetMethod(format, BindingFlags.Static | BindingFlags.Public);
            
            Console.WriteLine(Current(current) + Fizz(current) + Buzz(current));

            method.Invoke(new { }, new[] { (object)++current, (object)end });
        }
    }
}
