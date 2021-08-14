using PTS.BLL.Validation;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.User
{
	public class UpdateUserDTO
	{
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "User id must be between {1} and {2}.")]
		[ExistUserById(ErrorMessage = "The user does not exist.")]
		public int Id { get; set; }

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
