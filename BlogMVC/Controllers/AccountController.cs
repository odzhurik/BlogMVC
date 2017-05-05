using BlogMVC.Models;
using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogMVC.Controllers
{
    public class AccountController : Controller
    {
        private IBlogRepository _repository;
        public AccountController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = _repository.FindUser(model);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Posts");
                }
                else
                {
                    ModelState.AddModelError("", "Doesn't exist this user");
                }
            }
            return View(model);
        }
        [HttpGet]
        public JsonResult CheckUserName(string userName)
        {
            User user = _repository.FindByName(userName);
            if (user != null)
            {
                return Json("Exist",JsonRequestBehavior.AllowGet);
            }
            return Json("Ok",JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = model.Name;
                user.Password = model.Password;
                if (_repository.AddUser(user))
                {
                    return RedirectToAction("Index",new { Controller="Posts", id=user.ID});
                }
            }
            return RedirectToAction("Register");
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Start");
        }
    }
}