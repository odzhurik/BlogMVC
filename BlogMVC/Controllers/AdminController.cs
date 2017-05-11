using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IBlogRepository _repository;
        public AdminController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult HidePost(int id)
        {
            Post post = _repository.GetPost(id);
            post.Visible = false;
            _repository.EditPost(post);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult BlockUser()
        {
            return View(_repository.GetUsers());
        }
        [HttpPost]
        public JsonResult BlockUser(int id)
        {
            Role role = _repository.GetRoleByName("Blocked User");
            User user = _repository.GetUser(id);
            user.Role = role;
            _repository.EditUser(user);
            return Json("Ok");
        }
    }
}