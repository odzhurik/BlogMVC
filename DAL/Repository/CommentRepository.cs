using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class CommentRepository:IDisposable,ICommentRepository
    {
        private BlogContext _db = new BlogContext();
        public IEnumerable<Comment> GetComments(int? PostID)
        {
            var comments = _db.Comments.Where(c => c.PostID == PostID);
            return comments.ToList();
        }
        public Comment GetComment(int? id)
        {
            Comment comment = _db.Comments.Find(id);
            return comment;
        }
        public void AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }
        public void EditComment(Comment comment)
        {
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            Comment comment = GetComment(id);
            _db.Comments.Remove(comment);
            _db.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
