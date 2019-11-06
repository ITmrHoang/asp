using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models
{
    public class UserRegisterView
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(60, MinimumLength = 5)]
        [Display(Name = "Tên Đăng Nhập:")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        public string UserName { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Mật khẩu phải dài hơn 5 ký tự!")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [Display(Name = "Mật Khẩu:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //  [System.ComponentModel.DefaultValue('User')]
        [Display(Name = "Xác Nhận Mật Khẩu:")]
        [Compare("Password", ErrorMessage ="Mật khẩu xác nhận không trùng khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPasssword { get; set; }
        public string Role { get; set; } = "user" ;
    }
}
