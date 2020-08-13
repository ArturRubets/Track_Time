using System.ComponentModel.DataAnnotations;

namespace Track_Time.Models
{
    public class ActivityType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
