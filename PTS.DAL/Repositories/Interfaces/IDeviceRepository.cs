using PTS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Interfaces
{
	public interface IDeviceRepository
	{
		Task<IEnumerable<Device>> GetAllAsync();

		Task<Device> GetByIdAsync(int deviceId);

		Task<Device> AddAsync(Device device);

		Task<Device> UpdateAsync(Device updatedDevice);

		Task<Device> DeleteAsync(Device device);
	}
}
