using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Work
    {
        public static int Number (int k)
        {
            string str = k.ToString();
            string substr = null;
            char[] temp = null;
            int i = str.Length - 1;
            for (; i > 0; i--)
                if (str[i - 1] < str[i])
                {
                    substr = str.Substring(i - 1);
                    break;
                }
            if (i == 0) return -1;
            else
            {
                temp = substr.ToCharArray();
                
                Array.Sort(temp,1,temp.Length-1);
                int el = Array.FindIndex(temp, p => p > temp[0]);
                Console.WriteLine("  " + el);
                Console.WriteLine("  " + temp[0] + "  " + temp[el]);
                char buf = temp[0];
                temp[0] = temp[el];
                temp[el] = buf;
                return int.Parse(str.Substring(0, i-1) + new string(temp));
            }
        }

        Predicate<char> pred = SearchElement;
        static bool SearchElement(char el)
        {
            return el > 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Work.Number(k));
        }
    }
}
