using PTS.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PTS.DAL.UnitOfWok
{
	public interface IUnitOfWork
	{
		IUserRepository Users { get; }

		IDeviceRepository Devices { get; }

		ICompanyRepository Companies { get; }

		IWorkingHourRepository WorkingHours { get; }

		IProjectRepository Projects { get; }

		Task SaveAsync();
	}
}
