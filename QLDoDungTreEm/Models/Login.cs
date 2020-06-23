using System.ComponentModel.DataAnnotations;

namespace QLDoDungTreEm.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Required UserName")]
        public string TaiKhoan { set; get; }

        [Required(ErrorMessage = "Required Password")]
        [Display(Name = "Password")]
        public string MatKhau { set; get; }
    }
}