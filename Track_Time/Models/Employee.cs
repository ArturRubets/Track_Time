using System;
using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class Employee
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        [RegularExpression(@"[MW]", ErrorMessage = "Invalid. M or W")]
        public char Sex { get; set; }
    }
}
