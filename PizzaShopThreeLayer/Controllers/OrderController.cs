using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShopThreeLayer.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        //public ActionResult AllOrders()
        //{
        //    return View();
        //}
        public ActionResult MakeOrder()
        {
            return PartialView();
        }
        public ActionResult AllOrders()
        {
            return View();
        }

    }
}