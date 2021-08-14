using AutoMapper;
using PTS.BLL.BusinessModels;
using PTS.BLL.DTOs.User;
using PTS.BLL.Infrastructure;
using PTS.BLL.Services.Interfaces;
using PTS.DAL.Entities;
using PTS.DAL.Repositories.Interfaces;
using PTS.DAL.UnitOfWok;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTS.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _users;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_users = unitOfWork.Users;
			_mapper = mapper;
		}

		public async Task<UserDTO> CreateAsync(CreateUserDTO user)
		{
			var mapped = _mapper.Map<User>(user);
			mapped.HashedPassword = Hash.CreateMD5(user.Password);

			var result = await _users.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(result);
		}

		public async Task<UserDTO> DeleteAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			if (user != null)
			{
				var deleted = await _users.DeleteAsync(user);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<UserDTO>(user);
			}

			return null;
		}

		public async Task<IEnumerable<UserDTO>> FindAllUsersAsync()
		{
			var users = await _users.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public async Task<UserDTO> FindByIdAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> FindByLoginAsync(Login login)
		{
			var users = await _users.GetAllAsync();
			string passwordHash = Hash.CreateMD5(login.Password);

			var user = users.FirstOrDefault(u => u.Email == login.Email &&
				u.HashedPassword == passwordHash);

			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate)
		{
			var user = await _users.GetByIdAsync(userToUpdate.Id);
			user = _mapper.Map(userToUpdate, user);
			user.HashedPassword = Hash.CreateMD5(userToUpdate.Password);

			var updated = await _users.UpdateAsync(user);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<UserDTO>(updated);
		}
	}
}
