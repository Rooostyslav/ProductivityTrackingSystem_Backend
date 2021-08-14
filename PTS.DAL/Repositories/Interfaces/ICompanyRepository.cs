using PTS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Interfaces
{
	public interface ICompanyRepository
	{
		Task<IEnumerable<Company>> GetAllAsync();

		Task<Company> GetByIdAsync(int companyId);

		Task<Company> AddAsync(Company company);

		Task<Company> UpdateAsync(Company updatedCompany);

		Task<Company> DeleteAsync(Company company);
	}
}
