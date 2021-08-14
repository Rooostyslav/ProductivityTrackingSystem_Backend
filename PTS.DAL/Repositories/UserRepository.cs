using Microsoft.EntityFrameworkCore;
using PTS.DAL.EF;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Common;
using PTS.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly DbSet<User> _users;

		public UserRepository(TrackingSystemContext trackingSystemContext)
			: base(trackingSystemContext)
		{
			_users = trackingSystemContext.Users;
		}

		public override async Task<IEnumerable<User>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<User> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(u => u.Id == id);
		}

		private IQueryable<User> GetQueryWithIncludes()
		{
			return _users.Include(u => u.Devices)
				.Include(u => u.WorkingHours);
		}
	}
}
