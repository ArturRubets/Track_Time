using System.Data.Entity;
using Track_Time.Models;

namespace Track_Time.EF
{
    public class ContextData : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
