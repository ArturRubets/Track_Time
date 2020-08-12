using System;
using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class Project
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
    }
}
