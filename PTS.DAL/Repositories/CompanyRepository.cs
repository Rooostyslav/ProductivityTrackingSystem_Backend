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
	public class CompanyRepository : Repository<Company>, ICompanyRepository
	{
		private readonly DbSet<Company> _companies;

		public CompanyRepository(TrackingSystemContext trackingSystemContext)
			: base(trackingSystemContext)
		{
			_companies = trackingSystemContext.Companies;
		}

		public override async Task<IEnumerable<Company>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<Company> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(c => c.Id == id);
		}

		private IQueryable<Company> GetQueryWithIncludes()
		{
			return _companies.Include(c => c.Projects);
		}
	}
}
