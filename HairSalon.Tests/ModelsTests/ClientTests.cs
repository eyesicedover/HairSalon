using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
          DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=stephanie_faber_test;";
        }

        public void Dispose()
        {
            Client.ClearAll();
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            //Arrange
            Client testClient = new Client("Josh", 3);

            //Act
            testClient.Save();
            List<Client> resultList = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            //Assert
            Assert.AreEqual(testList.Count, resultList.Count);
            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void GetClients_DbStartsEmpty_0()
        {
            //Arrange
            Client testClient = new Client("Josh", 3);
            testClient.Save();

            //Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetSpecificClients_DbStartsEmpty_0()
        {
            //Arrange
            Client testClient1 = new Client("Berthold", 3);
            testClient1.Save();
            Client testClient2 = new Client("Amber", 1);
            testClient2.Save();
            Client testClient3 = new Client("Juan", 3);
            testClient3.Save();
            Client testClient4 = new Client("Louise", 2);
            testClient4.Save();

            //Act
            List<Client> resultList = Client.GetSpecificClients(3);
            List<Client> testList = new List<Client>{testClient1, testClient3};
            int result = resultList.Count;

            //Assert
            Assert.AreEqual(testList.Count, resultList.Count);
            CollectionAssert.AreEqual(testList, resultList);
        }
    }
}
