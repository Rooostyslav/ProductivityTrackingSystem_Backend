using PTS.BLL.DTOs.Company;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface ICompanyService
	{
		Task<IEnumerable<CompanyDTO>> FindAllCompaniesAsync();

		Task<CompanyDTO> FindByIdAsync(int companyId);

		Task<CompanyDTO> CreateAsync(CreateCompanyDTO company);

		Task<CompanyDTO> UpdateAsync(UpdateCompanyDTO companyToUpdate);

		Task<CompanyDTO> DeleteAsync(int companyId);
	}
}
