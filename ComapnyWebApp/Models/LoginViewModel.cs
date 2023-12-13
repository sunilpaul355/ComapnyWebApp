using System.ComponentModel.DataAnnotations;

namespace ComapnyWebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        public string EmployeeCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

    }
}
