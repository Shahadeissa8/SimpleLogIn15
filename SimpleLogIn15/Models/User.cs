using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLogIn15.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [DisplayName("UserName")]
        [Required(ErrorMessage ="Required field")]
        public string UserName { get; set; }
        [DisplayName("User Email")]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [DisplayName("User Password")]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
