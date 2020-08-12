using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class ActivityType
    {
        [Required]
        public string Name { get; set; }
    }
}
