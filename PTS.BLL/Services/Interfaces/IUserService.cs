using PTS.BLL.BusinessModels;
using PTS.BLL.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> FindByLoginAsync(Login login);

		Task<IEnumerable<UserDTO>> FindAllUsersAsync();

		Task<UserDTO> FindByIdAsync(int userId);

		Task<UserDTO> CreateAsync(CreateUserDTO user);

		Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate);

		Task<UserDTO> DeleteAsync(int userId);
	}
}
