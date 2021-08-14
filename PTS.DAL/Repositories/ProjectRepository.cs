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
	public class ProjectRepository : Repository<Project>, IProjectRepository
	{
		private readonly DbSet<Project> _projects;

		public ProjectRepository(TrackingSystemContext trackingSystemContext)
			: base(trackingSystemContext)
		{
			_projects = trackingSystemContext.Projects;
		}

		public override async Task<IEnumerable<Project>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<Project> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(p => p.Id == id);
		}

		private IQueryable<Project> GetQueryWithIncludes()
		{
			return _projects.Include(p => p.WorkingHours)
				.Include(p => p.Company);
		}
	}
}
