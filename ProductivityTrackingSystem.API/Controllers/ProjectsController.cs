using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackingSystem.API.User;
using PTS.BLL.DTOs.Project;
using PTS.BLL.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTrackingSystem.API.Controllers
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectsController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectsController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetProjects()
		{
			var items = await _projectService.FindAllProjectsAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetProjectById(int id)
		{
			var item = await _projectService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyProjects()
		{
			int myId = User.Id();
			var myProjects = await _projectService.FindProjectsByUserAsync(myId);

			if (myProjects.Count() > 0)
			{
				return Ok(myProjects);
			}

			return NoContent();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateProject(
			[FromBody] CreateProjectDTO projectToCreate)
		{
			var result = await _projectService.CreateAsync(projectToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateProject(
			[FromBody] UpdateProjectDTO projectToUpdate)
		{
			var result = await _projectService.UpdateAsync(projectToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			await _projectService.DeleteAsync(id);
			return Ok();
		}
	}
}
