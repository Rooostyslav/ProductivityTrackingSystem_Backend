using Microsoft.EntityFrameworkCore;
using PTS.DAL.Entities;

namespace PTS.DAL.EF
{
	public class TrackingSystemContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<WorkingHour> WorkingHours { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Device> Devices { get; set; }

		public TrackingSystemContext(DbContextOptions<TrackingSystemContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
