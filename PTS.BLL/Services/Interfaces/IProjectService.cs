using PTS.BLL.DTOs.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface IProjectService
	{
		Task<IEnumerable<ProjectDTO>> FindAllProjectsAsync();

		Task<IEnumerable<ProjectDTO>> FindProjectsByUserAsync(int userId);

		Task<ProjectDTO> FindByIdAsync(int projectId);

		Task<ProjectDTO> CreateAsync(CreateProjectDTO project);

		Task<ProjectDTO> UpdateAsync(UpdateProjectDTO projectToUpdate);

		Task<ProjectDTO> DeleteAsync(int projectId);
	}
}
