using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }
    }
}