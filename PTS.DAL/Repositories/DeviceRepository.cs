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
	public class DeviceRepository : Repository<Device>, IDeviceRepository
	{
		private readonly DbSet<Device> _devices;

		public DeviceRepository(TrackingSystemContext trackingSystemContext)
			: base(trackingSystemContext)
		{
			_devices = trackingSystemContext.Devices;
		}

		public override async Task<IEnumerable<Device>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<Device> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(d => d.Id == id);
		}

		private IQueryable<Device> GetQueryWithIncludes()
		{
			return _devices.Include(d => d.User);
		}
	}
}
