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
        [Display(Name ="Заголовок")]
        [Required]
        public string Title { get; set; }
        [Display(Name ="Текст")]
        [StringLength(int.MaxValue)]
        [Required]
        public string Text { get; set; }
        [Display(Name ="Дата добавления")]
        public DateTime Time { get; set; }
        virtual public ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}