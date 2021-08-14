using AutoMapper;
using PTS.BLL.DTOs.Project;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Interfaces;
using PTS.DAL.UnitOfWok;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTS.BLL.Services
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProjectRepository _projects;
		private readonly IMapper _mapper;

		public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_projects = unitOfWork.Projects;
			_mapper = mapper;
		}

		public async Task<ProjectDTO> CreateAsync(CreateProjectDTO project)
		{
			var mapped = _mapper.Map<Project>(project);
			var result = await _projects.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ProjectDTO>(result);
		}

		public async Task<ProjectDTO> DeleteAsync(int projectId)
		{
			var project = await _projects.GetByIdAsync(projectId);
			if (project != null)
			{
				var deleted = await _projects.DeleteAsync(project);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<ProjectDTO>(project);
			}

			return null;
		}

		public async Task<IEnumerable<ProjectDTO>> FindAllProjectsAsync()
		{
			var projects = await _projects.GetAllAsync();
			return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
		}

		public async Task<ProjectDTO> FindByIdAsync(int ProjectId)
		{
			var Project = await _projects.GetByIdAsync(ProjectId);
			return _mapper.Map<ProjectDTO>(Project);
		}

		public async Task<IEnumerable<ProjectDTO>> FindProjectsByUserAsync(int userId)
		{
			var workingHours = await _unitOfWork.WorkingHours.GetAllAsync();
			workingHours = workingHours.Where(w => w.UserId == userId);
			var projects = workingHours.Select(w => w.Project).Distinct();
			return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
		}

		public async Task<ProjectDTO> UpdateAsync(UpdateProjectDTO projectToUpdate)
		{
			var project = await _projects.GetByIdAsync(projectToUpdate.Id);
			project = _mapper.Map(projectToUpdate, project);

			var updated = await _projects.UpdateAsync(project);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<ProjectDTO>(updated);
		}
	}
}
