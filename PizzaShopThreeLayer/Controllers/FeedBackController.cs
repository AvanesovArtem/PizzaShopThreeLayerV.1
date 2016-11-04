using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject.Infrastructure.Language;
using PizzaShop.BLL.DTO;
using PizzaShop.BLL.Interfaces;
using PizzaShop.DAL.Entities;
using PizzaShopThreeLayer.Models;

namespace PizzaShopThreeLayer.Controllers
{
    public class FeedBackController : Controller
    {
        private ICommentService _commentService;

        public FeedBackController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public ActionResult Comments()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            IEnumerable<CommentDTO> comment = _commentService.GetAllComment();
            //var comments = Mapper.Map<IEnumerable<CommentDTO>, IEnumerable<CommentViewModel>>(comment);
            //Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            //var comments = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(_commentService.GetAllComment().ToEnumerable());
            return View("FeedBack",comment);
        }

        [HttpGet]
        public ActionResult Remove(int ?ide)
        {
            if (ide != null)
            {
                _commentService.DeleteComment((int)ide);
            }
            return PartialView("Remove");
        }

        public ActionResult AddComment(string message)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CommentViewModel,CommentDTO>());
            CommentViewModel commentView = new CommentViewModel
            {
                DateTime = DateTime.Now,
                Message = message,
                UserEmail = User.Identity.Name
            };
            var commentDto = Mapper.Map<CommentViewModel, CommentDTO>(commentView);
            _commentService.CreateComment(commentDto);

            return PartialView("AddCommentPartial",commentView);
        }
    }
}