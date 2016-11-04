using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShopThreeLayer.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}