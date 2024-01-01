using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComapnyWebApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        public string DeptName { get; set; }

        [NotMapped]
        public List<Department> AllDepartment { get; set; }
    }
}
