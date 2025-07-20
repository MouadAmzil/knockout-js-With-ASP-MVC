using System.ComponentModel.DataAnnotations;

namespace working_with_knockout_js_MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        public int Age { get; set; }
    }
}
