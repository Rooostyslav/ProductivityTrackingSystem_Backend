using PTS.BLL.Validation;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.Device
{
	public class UpdateDeviceDTO
	{
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Device id must be between {1} and {2}.")]
		[ExistDeviceById(ErrorMessage = "The device does not exist.")]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Type { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "User id must be between {1} and {2}.")]
		[ExistUserById(ErrorMessage = "The user does not exist.")]
		public int UserId { get; set; }
	}
}
