using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic funcName = new System.Dynamic.ExpandoObject();

            Dictionary<int, dynamic> problems = new Dictionary<int, dynamic>()
            {
                { 1, new {title = "Multiples of 3 and 5", func = new Action(multiples3and5)}},
                { 2,  new {title = "Even Fibonacci Numbers", func = new Action(evenFib)}},
                { 3,  new {title = "Largest Prime factor", func = new Action(multiples3and5)}}
            };

            Console.WriteLine("Please select the question you would like to solve: ");
            string ans = Console.ReadLine();
            int problemNumber = Convert.ToInt32(ans);
            if (problems.ContainsKey(problemNumber))
            {
                Console.WriteLine(problems[problemNumber].title);
                problems[problemNumber].func();

            }
            Console.Read();
        }

        public static void multiples3and5()
        {
            int sum = 0;

            for (int i = 0; i < 1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
            Console.Read();
        }


        public static void evenFib()
        {          
            int sum = 1;
            Int64 value = 0;
            do
            {
                int i = 2;
                value = Fibonacci(i);
                i++;
                Console.WriteLine(i);
            } while (value < 4000000);
            Console.WriteLine(value);
        }

        // Fast doubling algorithm
        private static Int64 Fibonacci(int n)
        {
            Int64 a = 0;
            Int64 b = 1;
            for (int i = 31; i >= 0; i--)
            {
                Int64 d = a * (b * 2 - a);
                Int64 e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    Int64 c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }
    }
}
