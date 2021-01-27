/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 06/12/2020
 * FILE NAME: LocationTests.cs
 * PURPOSE: Unit Test for Location.cs
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOSD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD.Tests
{
    [TestClass()]
    public class LocationTests
    {
        [TestMethod()]
        public void LocationTest()
        {
            Location locOne = new Location();
            locOne.Type = "Conferene Centres";
            locOne.Name = "EICC";

            // Testing to see if the object is not null
            Assert.IsNotNull(locOne);
        }

        [TestMethod()]
        public void LocationTest1()
        {
            Location locOne = new Location();
            locOne.Type = ("Historic Sites");
            locOne.Name = ("Edinburgh Castle");

            // Testing to see if the object type is equal to 'Historic Sites'
            Assert.AreEqual(locOne.Type, "Historic Sites");
            // Testing to see if the object name is equal to 'Edinburgh Castle'
            Assert.AreEqual(locOne.Name, "Edinburgh Castle");

            // Testing to see if the object type is not equal to 'Entertainment Venues'
            Assert.AreNotEqual(locOne.Type, "Entertainment Venues");
            // Testing to see if the object name is not equal to 'VUE'
            Assert.AreNotEqual(locOne.Name, "VUE");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Location locOne = new Location();
            locOne.Type = ("Hospitality");
            locOne.Name = ("McDonald's");

            // Testing to see if the ToString() method returns the Name 'McDonald's'
            Assert.AreEqual(locOne.ToString(), "McDonald's");
        }

        [TestMethod()]
        public void ToStringTest1()
        {
            Location locOne = new Location();
            locOne.Type = ("Hotel");
            locOne.Name = ("Leonardo");

            // Testing to see that the ToString() method does not return 'Hotel'
            Assert.AreNotEqual(locOne.ToString(), "Hotel");
        }
    }
}