using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        void AddPost(Post post);
        Post GetPost(int? id);
        void EditPost(Post post);
        void DeletePost(int id);
    }
}
