using BlogMVC.Models;
using DAL;
using DAL.Repository;
using Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class PostController : Controller
    {
        private IBlogRepository _repository;
        public PostController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index(int? id)
        {
            User user = new User();
            BlogViewModel model = new BlogViewModel();
            if (id == null || id == 0)
            {
                user = _repository.FindByName(User.Identity.Name);
                Session["BlogId"] = user.Blog.ID;
                model.Blog = user.Blog;
                model.Posts = _repository.GetPosts(user.Blog.ID);
                return View(model);
            }
            user = _repository.GetUser(id);
            Session["BlogId"] = user.ID;
            model.Blog = user.Blog;
            model.Posts = _repository.GetPosts(user.Blog.ID);
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _repository.GetPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            User user = _repository.GetUser(Convert.ToInt32(Session["UserId"]));
             return View(post);
        }
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            User user = _repository.FindByName(User.Identity.Name);
            Post post = new Post();
            post.Blog = user.Blog;
             return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _repository.AddPost(post);
                return RedirectToAction("Index");
            }

            return View(post);
        }
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _repository.GetPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _repository.EditPost(post);
                return RedirectToAction("Index", "Post");
            }
            return View(post);
        }
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _repository.GetPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeletePost(id);
            return RedirectToAction("Index","Post");
        }
        [HttpGet]
        public JsonResult GetByCategory(int? id)
        {
            return Json(_repository.GetPostsByCategory(id).Select(p => new { Title = p.Title, ID = p.ID }), JsonRequestBehavior.AllowGet);
        }
    }
}
