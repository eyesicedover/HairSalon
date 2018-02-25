using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using System;

namespace HairSalon.Controllers.Tests
{
    [TestClass]
    public class StylistControllerTest
    {

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            ActionResult result = new StylistController().Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateForm_ReturnsCorrectView_True()
        {
            //Arrange
            ActionResult result = new StylistController().CreateForm();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            //Arrange
            int id = 2;
            ActionResult result = new StylistController().Details(id);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
