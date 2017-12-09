using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlue.Controllers;
using System.Web.Mvc;

namespace CodeBlue.Tests.Controllers
{
    [TestClass]
    public class TicketControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            TicketController controller = new TicketController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
