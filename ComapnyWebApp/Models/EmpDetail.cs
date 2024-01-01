using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComapnyWebApp.Models
{
    public class EmpDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Address Line 1 is Required")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address Line 2 is Required")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public int City { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public int State { get; set; }

        [Required(ErrorMessage = "Pincode is Required")]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "Department Id is Required")]
        
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Employee Id is Required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Role Id is Required")]
        public int RoleId { get; set; }

        [ForeignKey("DeptId")]
        public Department Department {  get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
