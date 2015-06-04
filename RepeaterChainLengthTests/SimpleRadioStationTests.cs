using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepeaterChainLength;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RepeaterChainLength.Tests
{
    /// <summary>
    ///  1. Given a list of repeater channel number pairs, determine the longest chain of repeaters in the network, 
    /// and identify any repeaters that are "orphaned" because there is no chain that connects them back to the central node.
    /// For example, for this set or repeaters (upstream/downstream):
    /// 0/1, 1/2, 3/4, 0/5
    /// the longest chain is two repeaters and repeater 3/4 is orphaned.
    /// </summary>
    [TestClass()]
    public class SimpleRadioStationTests
    {
        [TestMethod()]
        public void GetLongestChainOfRepeatersTest()
        {
            //Arrange
            SimpleRadioStation simpleRadioStation = new SimpleRadioStation();

            int expected = 2;
            int actual = 0;

            //Act
            simpleRadioStation.AddRepeater(0, 1);
            simpleRadioStation.AddRepeater(1, 2);
            simpleRadioStation.AddRepeater(3, 4);
            simpleRadioStation.AddRepeater(0, 5);
            

            actual = simpleRadioStation.GetLongestChainOfRepeaters();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetOrphanedRepeatersTest()
        {
            //Arrange
            SimpleRadioStation simpleRadioStation = new SimpleRadioStation();

            string expected = "3/4";
            string actual = string.Empty;

            //Act
         
            simpleRadioStation.AddRepeater(0, 1);
            simpleRadioStation.AddRepeater(1, 2);
            simpleRadioStation.AddRepeater(3, 4);
            simpleRadioStation.AddRepeater(0, 5);
            

            actual = simpleRadioStation.GetOrphanedRepeatersAsString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(Exception), "An Transeiver with the same Downstream Frequency 5 already exists")]
        [TestMethod()]
        public void DuplicateDownStreamTest()
        {
            //Arrange
            SimpleRadioStation simpleRadioStation = new SimpleRadioStation();


            //Act
            simpleRadioStation.AddRepeater(0,1);
            simpleRadioStation.AddRepeater(1,2);
            simpleRadioStation.AddRepeater(0,5);
            simpleRadioStation.AddRepeater(0,5);
            


        }

        [ExpectedException(typeof(Exception), "DownStream Frequency cannot be less than 0.")]
        [TestMethod()]
        public void TooLowDownStreamTest()
        {
            //Arrange
            SimpleRadioStation simpleRadioStation = new SimpleRadioStation();

            
            //Act
            simpleRadioStation.AddRepeater(0, 1);
            simpleRadioStation.AddRepeater(1, 2);
            simpleRadioStation.AddRepeater(0, 5);
            simpleRadioStation.AddRepeater(0, 5);
            

            

        }
    }
}
