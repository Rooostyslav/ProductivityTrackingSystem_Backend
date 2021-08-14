using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.User
{
	public class CreateUserDTO
	{
		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string SecondName { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string Role { get; set; }
	}
}
