using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
