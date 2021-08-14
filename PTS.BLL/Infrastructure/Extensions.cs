using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PTS.BLL.Services;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.EF;
using PTS.DAL.UnitOfWok;

namespace PTS.BLL.Infrastructure
{
	public static class Extensions
	{
		public static void AddContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<TrackingSystemContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Transient);
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IDeviceService, DeviceService>();
			services.AddScoped<ICompanyService, CompanyService>();
			services.AddScoped<IProjectService, ProjectService>();
			services.AddScoped<IWorkingHourService, WorkingHourService>();
		}

		public static void AddBackupService(this IServiceCollection services, string connectionString,
			string connectionStringToMaster)
		{
			services.AddScoped<IBackupService>(_ =>
				new BackupService(connectionString, connectionStringToMaster));
		}
	}
}
