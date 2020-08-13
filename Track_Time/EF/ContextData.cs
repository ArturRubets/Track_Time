using Microsoft.EntityFrameworkCore;
using Track_Time.Models;

namespace Track_Time.EF
{
    public class ContextData : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<TrackTime> TrackTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-3C1R4KNFBPO\MSSQLSERVER01;Initial Catalog='Track_Time';Integrated Security=True");
        }
    }
}
