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
            List<Repeater> repeaters = new List<Repeater>(){
                new Repeater(0,1),
                new Repeater(1,2),
                new Repeater(3,4),
                new Repeater(0,5)
            };


            simpleRadioStation.CreateRepeaters(repeaters);

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
            List<Repeater> repeaters = new List<Repeater>(){
                new Repeater(0,1),
                new Repeater(1,2),
                new Repeater(3,4),
                new Repeater(0,5)
            };


            simpleRadioStation.CreateRepeaters(repeaters);

            var orphanedRepeaters = simpleRadioStation.GetOrphanedRepeaters();

            foreach (var repeater in orphanedRepeaters)
                actual += repeater.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
