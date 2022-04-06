using System.ComponentModel.DataAnnotations;

namespace KUSYS.Web.UI.Models
{
    public class UserContext
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}
