using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IBlogRepository
    {
        IEnumerable<Post> GetPosts(int? userId);
        void AddPost(Post post);
        Post GetPost(int? id);
        void EditPost(Post post);
        void DeletePost(int id);
        IEnumerable<Comment> GetComments(int? PostID);
        Comment GetComment(int? id);
        void EditComment(Comment comment);
        void DeleteComment(int id);
        void AddComment(Comment comment);
        User FindUser(User enteredUser);
        User FindByName(string name);
        bool AddUser(User user);
        User GetUser(int? id);
        IEnumerable<Category> GetCategories();
        void AddBlog(Blog blog);
        IEnumerable<Blog> GetBlogsByCategory(int? id);
        IEnumerable<Post> GetPostsByCategory(int? id);
        IEnumerable<string> GetRolesForUser(string userName);
        void AddRole(string roleName);
        Role GetRole(int? id);
        Role GetRoleByName(string name);
        void EditUser(User user);
        IEnumerable<User> GetUsers();
        void EditBlog(Blog blog);
    }
}
