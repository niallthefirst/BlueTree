using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTests
{
    public class QuestionThree
    {
        /// <summary>
        /// Write a function that prints (to standard output) all possible permutations of an input string.  
        /// For example, permute("abc") should print (not necessarily in this order): abc acb bac bca cab cba
        /// </summary>
        /// <param name="value"></param>
        public static void Permute(string value)
        {
            GetPer(value.ToCharArray());
            //foreach (var permutation in QuestionThree.permute(value))
              //  Console.WriteLine(permutation + " ");
        }
        //public static List<string> permute(string value)
        //{
        //    List<string> result = null;



        //    return result;
        //}

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
                Console.Write(" ");
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}
