using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Interfaces;
using PizzaShop.BLL.Services;
using PizzaShop.DAL.Repositories;
using PizzaShopThreeLayer.Models;

namespace PizzaShopThreeLayer.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        public CartController()
        {
            _cartService = new CartService(new UnitOfWork("DefaultConnection"));
        }
        // GET: Cart
        public ActionResult AddedProducts()
        {
            string sad = User.Identity.Name;
            IEnumerable<CartDTO> prod = _cartService.GetAllUserProduct(User.Identity.Name);
            Mapper.Initialize(cfg => cfg.CreateMap<CartDTO, CartViewModel>());
            var products = Mapper.Map<IEnumerable<CartDTO>, List<CartViewModel>>(prod);
            return View("Products",products);
        }
        public ActionResult Remove(int ?ide)
        {
            if (ide != null)
            {
                _cartService.RemoveProductFromCart((int)ide);
                return PartialView();
            }
            return RedirectToAction("AddedProducts");

        }
        public ActionResult AddToCart(int? id)
        {
            if (id != null)
            {
                _cartService.AddToCart((int)id, User.Identity.Name);
                return PartialView("AddedProductToCartPartial");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}