using DAL.Repository;
using Entities;
using System.Net;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentRepository _repository;
        public CommentsController(ICommentRepository repository)
        {
            _repository = repository;
        }

        public ActionResult GetComments(int? PostID)
        {
            return PartialView("_GetComments", _repository.GetComments(PostID));
        }
        [HttpGet]
        public ActionResult Create(int? PostID)
        {
            ViewBag.PostID = PostID;
            return PartialView("_Create");
        }
        [HttpPost]
        public HttpStatusCode Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repository.AddComment(comment);
                return HttpStatusCode.Created;
            }
            return HttpStatusCode.BadRequest;
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _repository.GetComment(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", comment);

        }
        [HttpPost]
        public HttpStatusCode Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repository.EditComment(comment);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
        [HttpPost]
        public HttpStatusCode Delete(int id)
        {
            _repository.DeleteComment(id);
            return HttpStatusCode.OK;
        }
    }
}
