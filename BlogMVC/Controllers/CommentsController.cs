﻿using BlogMVC.Custom_Attributes;
using DAL.Repository;
using Entities;
using System.Net;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{

    public class CommentsController : Controller
    {
        private IBlogRepository _repository;
        public CommentsController(IBlogRepository repository)
        {
            _repository = repository;
        }
        public ActionResult GetComments(int? PostID)
        {
            return PartialView("_GetComments", _repository.GetComments(PostID));
        }
        [HttpGet]
        [MyAuthentication]
        public ActionResult Create(int? PostID)
        {
            User user = _repository.FindByName(User.Identity.Name);
            Comment comment = new Comment();
            comment.UserID = user.ID;
            comment.PostID = (int)PostID;
            return PartialView("_Create", comment);
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
        [Authorize(Roles = "User, Admin")]
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
            User user = _repository.FindByName(User.Identity.Name);
            comment.UserID = user.ID;
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
        [Authorize(Roles = "User, Admin")]
        public HttpStatusCode Delete(int id)
        {
            _repository.DeleteComment(id);
            return HttpStatusCode.OK;
        }
    }
}
