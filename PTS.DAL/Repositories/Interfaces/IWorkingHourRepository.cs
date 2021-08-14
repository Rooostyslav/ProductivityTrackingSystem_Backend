using PTS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Interfaces
{
	public interface IWorkingHourRepository
	{
		Task<IEnumerable<WorkingHour>> GetAllAsync();

		Task<WorkingHour> GetByIdAsync(int WorkingHourId);

		Task<WorkingHour> AddAsync(WorkingHour WorkingHour);

		Task<WorkingHour> UpdateAsync(WorkingHour updatedWorkingHour);

		Task<WorkingHour> DeleteAsync(WorkingHour WorkingHour);
	}
}
