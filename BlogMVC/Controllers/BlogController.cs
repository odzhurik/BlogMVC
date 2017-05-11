using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _repository;
        public BlogController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            User user = _repository.FindByName(User.Identity.Name);
            if(User.IsInRole("Admin"))
            {
               return RedirectToAction("Index", "Admin");
            }
            if (user.Blog == null)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index", "Post");
        }
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            Blog blog = new Blog();
            User user = _repository.FindByName(User.Identity.Name);
            blog.ID = user.ID;
            return View(blog);
        }
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            User user = _repository.FindByName(User.Identity.Name);
            blog.ID = user.ID;
            _repository.AddBlog(blog);
            return RedirectToAction("Index", "Post");
        }
        [HttpGet]
        public JsonResult GetByCategory(int? id)
        {
            return Json(_repository.GetBlogsByCategory(id).Select(p => new { Title = p.Title, ID = p.ID }), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int?id)
        {
            User user = _repository.FindByName(User.Identity.Name);
            Blog blog = user.Blog;
            return View(blog);
        }
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            _repository.EditBlog(blog);
            return RedirectToAction("Index","Blog");
        }
    }
}