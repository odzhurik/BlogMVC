using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Display(Name ="Заголовок")]
        public string Title { get; set; }
        [Display(Name ="Текст")]
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}