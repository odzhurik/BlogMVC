using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogMVC.Models.DAL
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("BlogConnection")
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}