using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.BLL.DTOs.Company;
using PTS.BLL.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTrackingSystem.API.Controllers
{
	[ApiController]
	[Route("api/companies")]
	public class CompaniesController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompaniesController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetCompanys()
		{
			var items = await _companyService.FindAllCompaniesAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetCompanyById(int id)
		{
			var item = await _companyService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateCompany(
			[FromBody] CreateCompanyDTO companyToCreate)
		{
			var result = await _companyService.CreateAsync(companyToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateCompany(
			[FromBody] UpdateCompanyDTO companyToUpdate)
		{
			var result = await _companyService.UpdateAsync(companyToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteCompany(int id)
		{
			await _companyService.DeleteAsync(id);
			return Ok();
		}
	}
}
