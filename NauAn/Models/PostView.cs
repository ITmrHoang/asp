using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NauAn.Models.Entities;

namespace NauAn.Models
{
    public class PostView
    {
        public int ID { get; set; }
        [Display(Name = "Tên Bài Viết")]
        [Required(ErrorMessage = "Tên bài viết không được bỏ trống!")]
        public string PostName { get; set; }
        [Display(Name = "Tiêu Đề")]
        [Required(ErrorMessage = "Tiêu đề không được bỏ trống!")]
        public string Title { get; set; }
        [Display(Name = "Công thức")]
        [Required(ErrorMessage = "Công thức không được bỏ trống!")]
        public string Content { get; set; }
        [Display(Name = "Số người truy cập")]
        public int? Rating { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
