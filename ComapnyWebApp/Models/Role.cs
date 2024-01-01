using System.ComponentModel.DataAnnotations;

namespace ComapnyWebApp.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
    }
}
