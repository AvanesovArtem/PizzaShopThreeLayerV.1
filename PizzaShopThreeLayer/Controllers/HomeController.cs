using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using PizzaShop.BLL.Interfaces;
using AutoMapper;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Infrastructure;
using PizzaShopThreeLayer.Models;
using PizzaShop.BLL.Services;

namespace PizzaShopThreeLayer.Controllers
{
    public class HomeController : Controller
    {
        private IUserServise UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserServise>();
            }
        }

        private IProductService _productService;
        public HomeController(IProductService product)
        {
            _productService = product;
        }
        public ActionResult Index()
        {
   
            IEnumerable<ProductDTO> prod = _productService.GetFirstN(8);
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prod);

            return View("Index",products);
        }

        //[Authorize(Roles="admin")]
      
        public ActionResult Menu(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                IEnumerable<ProductDTO> prodItems = _productService.GetItemsPage(page);
                Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
                var product = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prodItems);
                return PartialView("PartialMenu",product);
            }
            IEnumerable<ProductDTO> prod = _productService.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prod);
            return View(products);

        }
        protected override void Dispose(bool disposing)
        {
            _productService.Dispose();
            base.Dispose(disposing);
        }
    }
}