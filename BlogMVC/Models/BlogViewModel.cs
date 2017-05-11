using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public BlogViewModel()
        {
            Posts = new List<Post>();
        }
    }
}