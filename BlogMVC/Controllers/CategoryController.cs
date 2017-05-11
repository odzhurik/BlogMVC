using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class CategoryController : Controller
    {
        private IBlogRepository _repository;
        public CategoryController(IBlogRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public JsonResult GetCategories()
        {
              return Json(_repository.GetCategories().Select(p=> new {Name=p.Name, ID=p.ID }), JsonRequestBehavior.AllowGet);
        }
    }
}