using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComapnyWebApp.Models
{
    [Table("States")]
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        [NotMapped]
        public List<States> AllStates { get; set; }
    }
}
