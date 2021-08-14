using AutoMapper;
using PTS.BLL.DTOs.Company;
using PTS.BLL.DTOs.Device;
using PTS.BLL.DTOs.Project;
using PTS.BLL.DTOs.User;
using PTS.BLL.DTOs.WorkingHour;
using PTS.DAL.Entities;

namespace PTS.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//user
			CreateMap<User, UserDTO>();
			CreateMap<CreateUserDTO, User>();
			CreateMap<UpdateUserDTO, User>();

			//working hour
			CreateMap<WorkingHour, WorkingHourDTO>();
			CreateMap<CreateWorkingHourDTO, WorkingHour>();
			CreateMap<UpdateWorkingHourDTO, WorkingHour>();

			//project
			CreateMap<Project, ProjectDTO>();
			CreateMap<CreateProjectDTO, Project>();
			CreateMap<UpdateProjectDTO, Project>();
			
			//device
			CreateMap<Device, DeviceDTO>();
			CreateMap<CreateDeviceDTO, Device>();
			CreateMap<UpdateDeviceDTO, Device>();

			//company
			CreateMap<Company, CompanyDTO>();
			CreateMap<CreateCompanyDTO, Company>();
			CreateMap<UpdateCompanyDTO, Company>();
		}
	}
}
