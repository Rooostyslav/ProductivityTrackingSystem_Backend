using PTS.BLL.DTOs.User;

namespace PTS.BLL.DTOs.Device
{
	public class DeviceDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string HashedPassword { get; set; }

		public int UserId { get; set; }

		public UserDTO User { get; set; }
	}
}
