using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
          DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=stephanie_faber_test;";
        }

        public void Dispose()
        {
            Stylist.ClearAll();
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            //Arrange
            Stylist testStylist = new Stylist("Alex");

            //Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Alex");

            //Act
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsItemInDatabase_Item()
        {
            //Arrange
            Stylist testStylist = new Stylist("Alex");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            //Assert
            Assert.AreEqual(testStylist, foundStylist);
        }
    }
}
