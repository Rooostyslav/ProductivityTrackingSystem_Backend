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
	public class WorkingHourRepository : Repository<WorkingHour>, IWorkingHourRepository
	{
		private readonly DbSet<WorkingHour> _workingHours;

		public WorkingHourRepository(TrackingSystemContext trackingSystemContext)
			: base(trackingSystemContext)
		{
			_workingHours = trackingSystemContext.WorkingHours;
		}

		public override async Task<IEnumerable<WorkingHour>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<WorkingHour> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(w => w.Id == id);
		}

		private IQueryable<WorkingHour> GetQueryWithIncludes()
		{
			return _workingHours.Include(w => w.Project)
				.ThenInclude(p => p.Company)
				.Include(w => w.User);
		}
	}
}
