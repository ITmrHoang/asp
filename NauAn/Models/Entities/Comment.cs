using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Bình luận không được để trống!")]
        public string Content { get; set; }
        public int? UserID { get; set; }
        public User CommentOfUser { get; set; }
        public int PostID { get; set; }
        [ForeignKey("PostID")]
        public Post Post { get; set; }
    }
}
