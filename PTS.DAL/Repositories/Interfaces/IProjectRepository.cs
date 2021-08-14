using PTS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Interfaces
{
	public interface IProjectRepository
	{
		Task<IEnumerable<Project>> GetAllAsync();

		Task<Project> GetByIdAsync(int projectId);

		Task<Project> AddAsync(Project project);

		Task<Project> UpdateAsync(Project updatedProject);

		Task<Project> DeleteAsync(Project project);
	}
}
