using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
