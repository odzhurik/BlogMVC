using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Comment
    {
        public int ID { get; set; }
        [StringLength(int.MaxValue)]
        [Required]
        public string Text { get; set; }
        [Display(Name = "Added")]
        public DateTime Time { get; set; }
        public int PostID { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        virtual public Post Post { get; set; }
    }
}
