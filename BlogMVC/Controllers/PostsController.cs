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
    
    public class PostsController : Controller
    {
        private IBlogRepository _repository;
        public PostsController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index(int? id)
        {
            User user = new User();
            if (id == null || id==0)
            {
                user = _repository.FindByName(User.Identity.Name);
                TempData["UserId"] = user.ID;
                return View(_repository.GetPosts(user.ID));
            }
            user = _repository.GetUser(id);
            TempData["UserId"] = user.ID;
            if (user.UserName == User.Identity.Name)
            {
                return View(_repository.GetPosts(user.ID));
            }
            ViewBag.Name = user.UserName;
            return View("BlogPage", _repository.GetPosts(user.ID));
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
            User user = _repository.GetUser(Convert.ToInt32(TempData["UserId"]));
            if(User.Identity.Name==user.UserName)
            {
                return View(post);
            }
            ViewBag.Name = user.UserName;
            return View("PostDetails",post);
        }
        public ActionResult Create()
        {
            User user = _repository.FindByName(User.Identity.Name);
            ViewBag.UserId = user.ID;
            return View();
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
                return RedirectToAction("Index");
            }
            return View(post);
        }
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
            return RedirectToAction("Index");
        }
    }
}
