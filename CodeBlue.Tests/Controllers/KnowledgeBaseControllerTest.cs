using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlue.Models;
using CodeBlue.Controllers;
using System.Web.Mvc;

namespace CodeBlue.Tests.Controllers
{
    [TestClass]
    public class KnowledgeBaseControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            KnowledgeBaseController controller = new KnowledgeBaseController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            KnowledgeBaseController controller = new KnowledgeBaseController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create(KnowledgeBase model)
        {
            // Arrange
            KnowledgeBaseController controller = new KnowledgeBaseController();

            //Act
            ViewResult result = controller.Create(model) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            KnowledgeBaseController controller = new KnowledgeBaseController();

            //Act
            ViewResult result = controller.Details() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
