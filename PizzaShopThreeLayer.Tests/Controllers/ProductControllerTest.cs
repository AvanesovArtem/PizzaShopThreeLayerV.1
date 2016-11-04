using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Interfaces;
using PizzaShopThreeLayer.Controllers;
using PizzaShopThreeLayer.Models;

namespace PizzaShopThreeLayer.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController controller;

        Mock<IProductService> moc = new Mock<IProductService>();

        [TestInitialize]
        public void SetupContext()
        {
            moc.Setup(a => a.GetAll()).Returns(new List<ProductDTO>());
            controller = new ProductController(moc.Object);
        }
        [TestMethod]
        public void EditViewModelNotNull()
        {
            ViewResult result = controller.Edit() as ViewResult;

          
            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void EditViewEqualEditCshtml()
        {
            ViewResult result = controller.Edit() as ViewResult;

         
            Assert.AreEqual("Products",result.ViewName);
        }

    }
}
