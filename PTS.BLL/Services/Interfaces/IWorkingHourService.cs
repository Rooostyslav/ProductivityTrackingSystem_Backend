using PTS.BLL.DTOs.WorkingHour;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface IWorkingHourService
	{
		Task<IEnumerable<WorkingHourDTO>> FindAllWorkingHoursAsync();

		Task<IEnumerable<WorkingHourDTO>> FindWorkingHoursByUserAsync(int userId);

		Task<WorkingHourDTO> FindByIdAsync(int workingHourId);

		Task<WorkingHourDTO> CreateAsync(CreateWorkingHourDTO workingHour);

		Task<WorkingHourDTO> UpdateAsync(UpdateWorkingHourDTO workingHourToUpdate);

		Task<WorkingHourDTO> DeleteAsync(int workingHourId);
	}
}
