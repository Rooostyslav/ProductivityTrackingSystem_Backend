using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackingSystem.API.User;
using PTS.BLL.DTOs.Device;
using PTS.BLL.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTrackingSystem.API.Controllers
{
	[ApiController]
	[Route("api/devices")]
	public class DevicesController : ControllerBase
	{
		private readonly IDeviceService _deviceService;

		public DevicesController(IDeviceService deviceService)
		{
			_deviceService = deviceService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetDevices()
		{
			var items = await _deviceService.FindAllDevicesAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetDeviceById(int id)
		{
			var item = await _deviceService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyDevices()
		{
			int myId = User.Id();
			var myProjects = await _deviceService.FindDevicesByUserAsync(myId);

			if (myProjects.Count() > 0)
			{
				return Ok(myProjects);
			}

			return NoContent();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateDevice(
			[FromBody] CreateDeviceDTO deviceToCreate)
		{
			var result = await _deviceService.CreateAsync(deviceToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateDevice(
			[FromBody] UpdateDeviceDTO deviceToUpdate)
		{
			var result = await _deviceService.UpdateAsync(deviceToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteDevice(int id)
		{
			await _deviceService.DeleteAsync(id);
			return Ok();
		}
	}
}
