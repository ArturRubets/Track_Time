﻿
using System;

namespace Track_Time.Models
{
    public class TrackTime
    {
        public int Id { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime DateEvent { get; set; }

        public TimeSpan WorkingHours { get; set; }


    }
}
