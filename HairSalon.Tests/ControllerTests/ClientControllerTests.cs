using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;

namespace HairSalon.Controllers.Tests
{
    [TestClass]
    public class ClientControllerTest
    {

        [TestMethod]
        public void CreateForm_ReturnsCorrectView_True()
        {
            //Arrange
            ActionResult result = new ClientController().CreateForm();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
