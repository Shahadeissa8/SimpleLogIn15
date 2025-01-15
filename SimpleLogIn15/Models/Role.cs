using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleLogIn15.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [DisplayName("Role Name")]
        [Required(ErrorMessage ="Required Field")]
        public string RoleName { get; set; }
    }
}
