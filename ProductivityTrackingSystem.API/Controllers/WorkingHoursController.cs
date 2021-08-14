using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackingSystem.API.User;
using PTS.BLL.DTOs.WorkingHour;
using PTS.BLL.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTrackingSystem.API.Controllers
{
	[ApiController]
	[Route("api/workinghours")]
	public class WorkingHoursController : ControllerBase
	{
		private readonly IWorkingHourService _workingHourService;

		public WorkingHoursController(IWorkingHourService workingHourService)
		{
			_workingHourService = workingHourService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetWorkingHours()
		{
			var items = await _workingHourService.FindAllWorkingHoursAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetWorkingHourById(int id)
		{
			var item = await _workingHourService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyWorkingHours()
		{
			int myId = User.Id();
			var myWorkingHours = await _workingHourService.FindWorkingHoursByUserAsync(myId);

			if (myWorkingHours.Count() > 0)
			{
				return Ok(myWorkingHours);
			}

			return NoContent();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateWorkingHour(
			[FromBody] CreateWorkingHourDTO workingHourToCreate)
		{
			var result = await _workingHourService.CreateAsync(workingHourToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateWorkingHour(
			[FromBody] UpdateWorkingHourDTO workingHourToUpdate)
		{
			var result = await _workingHourService.UpdateAsync(workingHourToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteWorkingHour(int id)
		{
			await _workingHourService.DeleteAsync(id);
			return Ok();
		}
	}
}
