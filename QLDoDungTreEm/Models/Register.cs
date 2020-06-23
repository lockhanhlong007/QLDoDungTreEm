using System;
using System.ComponentModel.DataAnnotations;

namespace QLDoDungTreEm.Models
{
    public class Register
    {
        [Key]
        public int MaKH { set; get; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Required FullName!")]
        public string HoTen { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Required UserName!")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length is at least 6 characters!")]
        [Required(ErrorMessage = "Required Password!")]
        public string MatKhau { get; set; }

        [Display(Name = "Comfirm Password")]
        [Compare("MatKhau", ErrorMessage = "Comfirm Password Don't Match!")]
        public string XacNhanMatKhau { set; get; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required Phone Number!")]
        public string DienThoai { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required Address!")]
        public string DiaChi { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Required Date Of Birth!")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Gender")]
        [Range(1, int.MaxValue, ErrorMessage = "Required Select Gender")]
        public Gender GioiTinh { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required Email!")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }
    }

    public enum Gender
    {
        Nam = 1,

        Nữ = 2
    }
}