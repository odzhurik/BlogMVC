using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Blog
    {
        [Key]
        [ForeignKey("User")]
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public Blog()
        {
            Posts = new List<Post>();
        }
    }
}
