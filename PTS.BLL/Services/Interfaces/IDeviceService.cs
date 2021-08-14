using PTS.BLL.DTOs.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface IDeviceService
	{
		Task<IEnumerable<DeviceDTO>> FindAllDevicesAsync();

		Task<IEnumerable<DeviceDTO>> FindDevicesByUserAsync(int userId);

		Task<DeviceDTO> FindByIdAsync(int deviceId);

		Task<DeviceDTO> CreateAsync(CreateDeviceDTO device);

		Task<DeviceDTO> UpdateAsync(UpdateDeviceDTO deviceToUpdate);

		Task<DeviceDTO> DeleteAsync(int deviceId);
	}
}
