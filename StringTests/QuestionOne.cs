using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringTests
{

//    1) Write the following function in either java or c#:
//bool ExpressionMatches(string text, string pattern)
//where: 
//•	'text' is an ASCII string
//•	'pattern' is an ASCII string which can include 0 or more instances of the wildcard "*", which represents an arbitrary substring of any length (0 or more characters)
//return value: the function returns true if "text" matches the pattern represented by "pattern"

//For example, the following is expected (text, pattern, return value):
//   "This is a test string", "T*test*string", true
//   "This is a test string", "*test*", true
//   "This is a test string", "*", true
//   "This is a test string", "*This is *", true
//   "This is a test string", "A*string", false
//   "This is a test string", "This is a test string", true
//   "This is a test string", "This is a test", false
//   "This is a test string", "This is***", true
//   "test testing", "*testin*", true

    public class QuestionOne
    {
        public bool ExpressionMatches(string text, string pattern)
        {
            bool result = true;

            if (text == null)
                return false;

            if (pattern != null)
            {

                var isAscii = ValidateString(text, "String to match must be ASCII.");
                isAscii = ValidateString(pattern, "Pattern must be ASCII.");

                string patternWithWildCard = pattern.Replace("*", ".*?");
                Regex regex = new Regex(patternWithWildCard);
                result = regex.IsMatch(text);
            }   

            return result;
            
        }

        private static bool ValidateString(string value, string message)
        {
            var isAscii = Encoding.UTF8.GetByteCount(value) == value.Length;
            if (!isAscii)
                throw new Exception(message);
            return isAscii;
        }
    }
}
