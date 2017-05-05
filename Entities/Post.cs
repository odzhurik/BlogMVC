using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Post
    {
        public int ID { get; set; }
        [Display(Name ="Title of post")]
        [Required]
        public string Title { get; set; }
        [Display(Name ="Text of post")]
        [StringLength(int.MaxValue)]
        [Required]
        public string Text { get; set; }
        [Display(Name ="Added")]
        public DateTime Time { get; set; }
        virtual public ICollection<Comment> Comments { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}