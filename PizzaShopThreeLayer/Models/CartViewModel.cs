using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShop.DAL.Entities;

namespace PizzaShopThreeLayer.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public string EmailUser { get; set; }

        public Product Product { get; set; }
    }
}