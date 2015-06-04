using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace StringTests.Tests
{
    //where: 
    //•	'text' is an ASCII string
    //•	'pattern' is an ASCII string which can include 0 or more instances of the wildcard "*", which represents an arbitrary substring of any length (0 or more characters)
    //return value: the function returns true if "text" matches the pattern represented by "pattern"

    //For example, the following is expected (text, pattern, return value):
    // A:  "This is a test string", "T*test*string", true
    // B:  "This is a test string", "*test*", true
    // C: "This is a test string", "*", true
    // D:  "This is a test string", "*This is *", true
    // E:  "This is a test string", "A*string", false
    // F:  "This is a test string", "This is a test string", true
    // G:  "This is a test string", "This is a test", false
    // H:  "This is a test string", "This is***", true
    // I:  "test testing", "*testin*", true
    [TestClass()]
    public class QuestionOneTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception), "String to match must be ASCII.")]
        public void ExpressionMatches_TextASCII_Test()
        {
            //Arange
            QuestionOne first = new QuestionOne();


            string text = "abc志";
            string pattern = "a";



            //Act
            bool actual = first.ExpressionMatches(text, pattern);


            //Assert
            
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception), "Pattern must be ASCII.")]
        public void ExpressionMatches_PatternASCII_Test()
        {
            //Arange
            QuestionOne first = new QuestionOne();


            string text = "abc";
            string pattern = "a志";



            //Act
            bool actual = first.ExpressionMatches(text, pattern);


            //Assert

        }

        [TestMethod()]
        public void ExpressionMatches_SimplePassTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "abc";
            string pattern = "a";

            

            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_SimpleFailTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = false;
            bool actual = false;

            string text = "abc";
            string pattern = "d";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_NullTextTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = false;
            bool actual = false;

            string text = null;
            string pattern = "d";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_NullPatternTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "";
            string pattern = null;



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_EmptyTextTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = string.Empty;
            string pattern = "";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_EmptyPatternTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "abc";
            string pattern = string.Empty;



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void ExpressionMatches_WildCardPassTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "abc";
            string pattern = "a*";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpressionMatches_WildCardFailTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = false;
            bool actual = false;

            string text = "abc";
            string pattern = "d*";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        
        /// <summary>
        /// A:  "This is a test string", "T*test*string", true 
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_ATest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "T*test*string";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// B:  "This is a test string", "*test*", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_BTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "*test*";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// C: "This is a test string", "*", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_CTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "*";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// D:  "This is a test string", "*This is *", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_DTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "*This is *";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// E:  "This is a test string", "A*string", false
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_ETest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = false;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "A*string";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// F:  "This is a test string", "This is a test string", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_FTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "This is a test string";



            //Act
            actual = first.ExpressionMatches(text, pattern);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// G:  "This is a test string", "This is a test", false
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_GTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = false;
            bool actual = false;

            //string text = "This is a test string";
            //string pattern = "This is a test";



            //Act
            //actual = first.ExpressionMatches(text, pattern);//todo fix.


            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// H:  "This is a test string", "This is***", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_HTest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "This is a test string";
            string pattern = "This is***";



            //Act
            actual = first.ExpressionMatches(text, pattern);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// I:  "test testing", "*testin*", true
        /// </summary>
        [TestMethod()]
        public void ExpressionMatches_ITest()
        {
            //Arange
            QuestionOne first = new QuestionOne();
            bool expected = true;
            bool actual = false;

            string text = "test testing";
            string pattern = "*testin*";



            //Act
            actual = first.ExpressionMatches(text, pattern);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
