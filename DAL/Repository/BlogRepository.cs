using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BlogRepository : IDisposable, IBlogRepository
    {
        private BlogContext _db = new BlogContext();
        public IEnumerable<Post> GetPosts(int? userId)
        {
            return _db.Posts.Where(p => p.UserID == userId);
        }
        public void AddPost(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
        }
        public Post GetPost(int? id)
        {
            return _db.Posts.Find(id);
        }
        public void EditPost(Post post)
        {
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void DeletePost(int id)
        {
            Post post = GetPost(id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }
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
        public User FindUser(User enteredUser)
        {
            User user = new User();
            user = _db.Users.FirstOrDefault(u => u.UserName == enteredUser.UserName && u.Password == enteredUser.Password);
            return user;
        }
        public User FindByName(string name)
        {
            User user = new User();
            user = _db.Users.Where(p => p.UserName == name).FirstOrDefault();
            return user;
        }
        public bool AddUser(User user)
        {
            bool userExist = _db.Users.Any(p => p.UserName == user.UserName);
            if (!userExist)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            return !userExist;
        }
        public User GetUser(int? id)
        {
            User user = _db.Users.Find(id);
            return user;
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
