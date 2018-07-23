using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(IsPalindrome(12321));
            Console.ReadKey();
        }
        public static bool IsPalindrome(int x)
        {
            string str = x.ToString();
            string temp = "";
            for (int i = str.Length; i > 0; i--)
            {
                temp += str[i - 1];
            }
            return str == temp;
        }
    }
}
