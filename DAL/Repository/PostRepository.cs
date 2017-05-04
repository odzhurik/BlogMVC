using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class PostRepository: IDisposable,IPostRepository
    {
        private BlogContext _db = new BlogContext();
        public IEnumerable<Post> GetPosts()
        {
            return _db.Posts.ToList();
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
