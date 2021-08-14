using AutoMapper;
using PTS.BLL.DTOs.WorkingHour;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Interfaces;
using PTS.DAL.UnitOfWok;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTS.BLL.Services
{
	public class WorkingHourService : IWorkingHourService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWorkingHourRepository _workingHours;
		private readonly IMapper _mapper;

		public WorkingHourService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_workingHours = unitOfWork.WorkingHours;
			_mapper = mapper;
		}

		public async Task<WorkingHourDTO> CreateAsync(CreateWorkingHourDTO workingHour)
		{
			var mapped = _mapper.Map<WorkingHour>(workingHour);
			var result = await _workingHours.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<WorkingHourDTO>(result);
		}

		public async Task<WorkingHourDTO> DeleteAsync(int workingHourId)
		{
			var workingHour = await _workingHours.GetByIdAsync(workingHourId);
			if (workingHour != null)
			{
				var deleted = await _workingHours.DeleteAsync(workingHour);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<WorkingHourDTO>(workingHour);
			}

			return null;
		}

		public async Task<IEnumerable<WorkingHourDTO>> FindAllWorkingHoursAsync()
		{
			var workingHours = await _workingHours.GetAllAsync();
			return _mapper.Map<IEnumerable<WorkingHourDTO>>(workingHours);
		}

		public async Task<WorkingHourDTO> FindByIdAsync(int workingHourId)
		{
			var workingHour = await _workingHours.GetByIdAsync(workingHourId);
			return _mapper.Map<WorkingHourDTO>(workingHour);
		}

		public async Task<IEnumerable<WorkingHourDTO>> FindWorkingHoursByUserAsync(int userId)
		{
			var workingHours = await _workingHours.GetAllAsync();
			workingHours = workingHours.Where(w => w.UserId == userId);
			return _mapper.Map<IEnumerable<WorkingHourDTO>>(workingHours);
		}

		public async Task<WorkingHourDTO> UpdateAsync(UpdateWorkingHourDTO workingHourToUpdate)
		{
			var workingHour = await _workingHours.GetByIdAsync(workingHourToUpdate.Id);
			workingHour = _mapper.Map(workingHourToUpdate, workingHour);

			var updated = await _workingHours.UpdateAsync(workingHour);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<WorkingHourDTO>(updated);
		}
	}
}
