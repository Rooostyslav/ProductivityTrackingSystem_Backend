using AutoMapper;
using PTS.BLL.DTOs.Company;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Interfaces;
using PTS.DAL.UnitOfWok;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companies;
		private readonly IMapper _mapper;

		public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_companies = unitOfWork.Companies;
			_mapper = mapper;
		}

		public async Task<CompanyDTO> CreateAsync(CreateCompanyDTO company)
		{
			var mapped = _mapper.Map<Company>(company);
			var result = await _companies.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<CompanyDTO>(result);
		}

		public async Task<CompanyDTO> DeleteAsync(int companyId)
		{
			var company = await _companies.GetByIdAsync(companyId);
			if (company != null)
			{
				var deleted = await _companies.DeleteAsync(company);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<CompanyDTO>(company);
			}

			return null;
		}

		public async Task<IEnumerable<CompanyDTO>> FindAllCompaniesAsync()
		{
			var companies = await _companies.GetAllAsync();
			return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
		}

		public async Task<CompanyDTO> FindByIdAsync(int companyId)
		{
			var company = await _companies.GetByIdAsync(companyId);
			return _mapper.Map<CompanyDTO>(company);
		}

		public async Task<CompanyDTO> UpdateAsync(UpdateCompanyDTO companyToUpdate)
		{
			var company = await _companies.GetByIdAsync(companyToUpdate.Id);
			company = _mapper.Map(companyToUpdate, company);

			var updated = await _companies.UpdateAsync(company);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<CompanyDTO>(updated);
		}
	}
}
