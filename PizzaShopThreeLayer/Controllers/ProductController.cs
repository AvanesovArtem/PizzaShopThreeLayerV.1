using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Interfaces;
using PizzaShopThreeLayer.Models;
 

namespace PizzaShopThreeLayer.Controllers
{
    public class ProductController : AsyncController
    {
       
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
           
        }
        public ActionResult AddProduct()
        {
            return View("UploadProduct");
        }

        [HttpPost]
        public ActionResult AddProduct(UploadProductViewModel prod)
        {
            if (ModelState.IsValid && prod.Image != null)
            {
                string path = Server.MapPath("~/Image/" + prod.Name.Replace(" ", "") + ".png");

                prod.Absolutepath = path;
                Mapper.Initialize(cfg =>cfg.CreateMap<UploadProductViewModel, UploadProductDTO>());

                var product = Mapper.Map<UploadProductViewModel, UploadProductDTO>(prod);
                _productService.CreateProduct(product);
            }
            else
            {
                ModelState.AddModelError("Image","Заполните все поля");
            }
               return View("UploadProduct");
        }
        
        public ActionResult Products()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(_productService.GetAll());
            return View(products);
        }

        [HttpGet]
        public ActionResult Remove(int ?ide)
        {
            if (ide != null)
            {
                _productService.RemoveProduct((int)ide);
                return PartialView();
            }
            return RedirectToAction("Edit");

        }

        [HttpGet]
        public ActionResult Edit()
        {
            IEnumerable<ProductDTO> prod = _productService.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prod);
            
            return View("Products",products);
        }
        [HttpPost]
        public ActionResult Edit(UploadProductViewModel prod)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UploadProductViewModel, UploadProductDTO>());
                var product = Mapper.Map<UploadProductViewModel,UploadProductDTO>(prod);
                _productService.UpdateProduct(product);

                return RedirectToAction("Edit", "Product");
            }
  
            return View("Products");
        }
        public ActionResult AutoComplete(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var pro = _productService.GetProductsByName(term);
                return Json(pro, JsonRequestBehavior.AllowGet); 
            }
            return RedirectToAction("Menu", "Home");
        }
        public ActionResult FoundProductByName(int? id)
        {
            if (id != null)
            {
                ProductDTO prod = _productService.GetById((int)id);
                Mapper.Initialize(x => x.CreateMap<ProductDTO, ProductViewModel>());
                var product = Mapper.Map<ProductDTO, ProductViewModel>(prod);

                return View(product);
            }
            return RedirectToAction("Menu", "Home");
        }

    }
}