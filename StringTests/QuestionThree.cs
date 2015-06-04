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
        public static List<string> Permute(string value)
        {
            if (value == null)
                return null;

            var result = GetPermutation(value.ToCharArray());

            foreach (var s in result)
            {
                Console.Write(s + " ");
                
            }

            return result.ToList();
        }
       

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static List<string> GetPermutation(char[] list)
        {
            int x = list.Length - 1;

            List<string> result = new List<string>();
            return GetPermutation(list, 0, x, result);


        }

        private static List<string> GetPermutation(char[] list, int index, int count, List<string> result)
        {
            
            if (index == count)
            {
                result.Add( new string(list));
            }
            else
                for (int i = index; i <= count; i++)
                {
                    Swap(ref list[index], ref list[i]);
                    GetPermutation(list, index + 1, count, result);
                    Swap(ref list[index], ref list[i]);
                }


            return result;
        }


    }
}
