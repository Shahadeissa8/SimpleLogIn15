using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimpleLogIn15.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        [DisplayName("UserName")]
        [Required(ErrorMessage = "Required field")]
        public string UserName { get; set; }
        [DisplayName("User Email")]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [DisplayName("User Password")]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("UserPassword",ErrorMessage ="Invalid password confirmation")]
        public string ConfirmUserPassword { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
