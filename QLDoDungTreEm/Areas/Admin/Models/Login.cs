using System.ComponentModel.DataAnnotations;

namespace QLDoDungTreEm.Areas.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Mời Nhập User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời Bạn Nhập Passowrd")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}