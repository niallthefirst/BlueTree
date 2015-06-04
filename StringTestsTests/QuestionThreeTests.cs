using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace StringTests.Tests
{
    /// <summary>
    /// Write a function that prints (to standard output) all possible permutations of an input string.  
    /// For example, permute("abc") should print (not necessarily in this order): abc acb bac bca cab cba
    /// </summary>
    [TestClass()]
    public class QuestionThreeTests
    {
        [TestMethod()]
        public void PermuteTest()
        {
            //Arrange
            List<string> expected = new List<string>() { "abc", "acb", "bac", "bca", "cab", "cba" };
            List<string> actual = null;

            //Act
            actual = QuestionThree.Permute("abc");


            //Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void PermuteNullTest()
        {
            //Arrange
            List<string> expected = null;
            List<string> actual = null;

            //Act
            actual = QuestionThree.Permute(null);


            //Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

      
    }
}
