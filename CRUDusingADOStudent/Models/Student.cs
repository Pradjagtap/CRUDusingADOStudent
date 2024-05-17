using System.ComponentModel.DataAnnotations;

namespace CRUDusingADOStudent.Models
{
    public class Student
    {
        [Key] //this is pk in table
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//?to allow null value from DB
        [Required]
        public string? Email { get; set; }
        [Required]
        public double Percentage { get; set; }

    }
}
