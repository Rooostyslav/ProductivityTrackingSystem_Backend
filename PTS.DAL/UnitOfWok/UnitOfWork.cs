using PTS.DAL.EF;
using PTS.DAL.Repositories;
using PTS.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PTS.DAL.UnitOfWok
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly TrackingSystemContext _trackingSystemContext;
		private IUserRepository _userRepository;
		private IProjectRepository _projectRepository;
		private IWorkingHourRepository _workingHourRepository;
		private ICompanyRepository _companyRepository;
		private IDeviceRepository _deviceRepository;

		public UnitOfWork(TrackingSystemContext trackingSystemContext)
		{
			_trackingSystemContext = trackingSystemContext;
		}

		public IUserRepository Users
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_trackingSystemContext);
				}

				return _userRepository;
			}
		}

		public IDeviceRepository Devices
		{
			get
			{
				if (_deviceRepository == null)
				{
					_deviceRepository = new DeviceRepository(_trackingSystemContext);
				}

				return _deviceRepository;
			}
		}

		public ICompanyRepository Companies
		{
			get
			{
				if (_companyRepository == null)
				{
					_companyRepository = new CompanyRepository(_trackingSystemContext);
				}

				return _companyRepository;
			}
		}

		public IWorkingHourRepository WorkingHours
		{
			get
			{
				if (_workingHourRepository == null)
				{
					_workingHourRepository = new WorkingHourRepository(_trackingSystemContext);
				}

				return _workingHourRepository;
			}
		}

		public IProjectRepository Projects
		{
			get
			{
				if (_projectRepository == null)
				{
					_projectRepository = new ProjectRepository(_trackingSystemContext);
				}

				return _projectRepository;
			}
		}

		public async Task SaveAsync()
		{
			await _trackingSystemContext.SaveChangesAsync();
		}
	}
}
