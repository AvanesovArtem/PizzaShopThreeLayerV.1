using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaShopThreeLayer;
using PizzaShopThreeLayer.Controllers;
using Moq;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Interfaces;

namespace PizzaShopThreeLayer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;
        Mock<IProductService> moc = new Mock<IProductService>();

        [TestInitialize]
        public void SetupContext()
        {     
            moc.Setup(a => a.GetAll()).Returns(new List<ProductDTO>());
            controller = new HomeController(moc.Object);
        }

        [TestMethod]
        public void IndexViewModelNutNull()
        {
   
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

      
    }
}
