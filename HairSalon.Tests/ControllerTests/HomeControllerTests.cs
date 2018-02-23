using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;

namespace HairSalon.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTest
    {

      [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            ActionResult result = new HomeController().Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
