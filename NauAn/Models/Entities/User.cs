using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models.Entities
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        public string UserName { get; set; }

        [StringLength(60, MinimumLength = 5, ErrorMessage = "Mật khẩu phải dài hơn 5 ký tự!")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Ngày Sinh")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Vai Trò")]
        public string  Role { get; set; } = "user";

        [Display(Name = "Giới Tính")]
        public int? Gender { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rank> Ranks { get; set; }
        public ICollection<Follow> Follows { get; set; }
    }
}
