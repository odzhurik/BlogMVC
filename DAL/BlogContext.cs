using DAL.Migrations;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogConnection")
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
            modelBuilder.Entity<User>()
    .HasMany(c => c.Comments)
    .WithRequired(c => c.User)
    .WillCascadeOnDelete(false);
           
        }
    }
}
