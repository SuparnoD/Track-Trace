/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 06/12/2020
 * FILE NAME: PersonTests.cs
 * PURPOSE: Unit Test for Person.cs
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
    public class PersonTests
    {
        [TestMethod()]
        public void PersonTest()
        {
            Person perOne = new Person();
            perOne.ID = 500;
            perOne.PhoneNumber = "01310000000";

            // Testing to see if the object is not null
            Assert.IsNotNull(perOne);
        }

        [TestMethod()]
        public void PersonTest1()
        {
            Person perOne = new Person();
            perOne.ID = 500;
            perOne.PhoneNumber = "01310000000";

            // Testing to see that the object ID is equal to 500
            Assert.AreEqual(perOne.ID, 500);
            // Testing to see that the object phone number is equal to 01310000000
            Assert.AreEqual(perOne.PhoneNumber, "01310000000");

            // Testing to see that the object ID is not equal to 'John Smith'
            Assert.AreNotEqual(perOne.ID, "John Smith");
            // Testing to see that the object phone number is not equal to 500
            Assert.AreNotEqual(perOne.PhoneNumber, 500);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            Person perOne = new Person();
            perOne.ID = 500;
            perOne.PhoneNumber = "01310000000";

            // Testing to see that the ToString() method returns '500'
            Assert.AreEqual(perOne.ToString(), "500");
        }

        [TestMethod()]
        public void ToStringTest1()
        {
            Person perOne = new Person();
            perOne.ID = 500;
            perOne.PhoneNumber = "01310000000";

            // Testing to see that the ToString() method does not return 'John Smith'
            Assert.AreNotEqual(perOne.ToString(), "John Smith");
            // Testing to see that the ToString() method does not return '01310000000'
            Assert.AreNotEqual(perOne.ToString(), "01310000000");
        }
    }
}