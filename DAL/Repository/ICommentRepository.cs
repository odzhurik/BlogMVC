using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments(int? PostID);
        Comment GetComment(int? id);
        void EditComment(Comment comment);
        void DeleteComment(int id);
        void AddComment(Comment comment);
    }
}
