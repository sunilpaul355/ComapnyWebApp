using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComapnyWebApp.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("StateId")]
        public States States { get; set; }

        [NotMapped]
        public List<City> AllCities { get; set; }
    }
}
