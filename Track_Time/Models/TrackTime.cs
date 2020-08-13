
namespace Track_Time.Models
{
    public class TrackTime
    {
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        public int EmployeeId { get; set; }
        public ActivityType Employee { get; set; }

        public int ProjectId { get; set; }
        public ActivityType Project { get; set; }

        public int RoleId { get; set; }
        public ActivityType Role { get; set; }
    }
}
