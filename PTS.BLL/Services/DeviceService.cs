using AutoMapper;
using PTS.BLL.DTOs.Device;
using PTS.BLL.Infrastructure;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Interfaces;
using PTS.DAL.UnitOfWok;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTS.BLL.Services
{
	public class DeviceService : IDeviceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IDeviceRepository _devices;
		private readonly IMapper _mapper;

		public DeviceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_devices = unitOfWork.Devices;
			_mapper = mapper;
		}

		public async Task<DeviceDTO> CreateAsync(CreateDeviceDTO device)
		{
			var mapped = _mapper.Map<Device>(device);
			mapped.HashedPassword = Hash.CreateMD5(device.Password);

			var result = await _devices.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<DeviceDTO>(result);
		}

		public async Task<DeviceDTO> DeleteAsync(int deviceId)
		{
			var device = await _devices.GetByIdAsync(deviceId);
			if (device != null)
			{
				var deleted = await _devices.DeleteAsync(device);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<DeviceDTO>(device);
			}

			return null;
		}

		public async Task<IEnumerable<DeviceDTO>> FindAllDevicesAsync()
		{
			var devices = await _devices.GetAllAsync();
			return _mapper.Map<IEnumerable<DeviceDTO>>(devices);
		}

		public async Task<DeviceDTO> FindByIdAsync(int deviceId)
		{
			var device = await _devices.GetByIdAsync(deviceId);
			return _mapper.Map<DeviceDTO>(device);
		}

		public async Task<IEnumerable<DeviceDTO>> FindDevicesByUserAsync(int userId)
		{
			var devices = await _devices.GetAllAsync();
			devices = devices.Where(d => d.UserId == userId);
			return _mapper.Map<IEnumerable<DeviceDTO>>(devices);
		}

		public async Task<DeviceDTO> UpdateAsync(UpdateDeviceDTO deviceToUpdate)
		{
			var device = await _devices.GetByIdAsync(deviceToUpdate.Id);
			device = _mapper.Map(deviceToUpdate, device);
			device.HashedPassword = Hash.CreateMD5(deviceToUpdate.Password);

			var updated = await _devices.UpdateAsync(device);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<DeviceDTO>(updated);
		}
	}
}
