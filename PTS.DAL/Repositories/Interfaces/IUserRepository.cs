using PTS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();

		Task<User> GetByIdAsync(int userId);

		Task<User> AddAsync(User user);

		Task<User> UpdateAsync(User updatedUser);

		Task<User> DeleteAsync(User user);
	}
}
