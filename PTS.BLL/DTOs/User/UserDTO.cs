
namespace PTS.BLL.DTOs.User
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string Email { get; set; }

		public string HashedPassword { get; set; }

		public string Role { get; set; }
	}
}
