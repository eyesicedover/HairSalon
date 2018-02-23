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
        public void GetClients_DbStartsEmpty_0()
        {
            //Arrange
            Client testClient = new Client("Josh", 3);

            //Act
            int result = Client.GetClients(3).Count;

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}