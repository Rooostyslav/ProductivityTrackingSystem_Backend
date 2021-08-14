using PTS.BLL.DTOs.Project;
using PTS.BLL.DTOs.User;
using System;

namespace PTS.BLL.DTOs.WorkingHour
{
	public class WorkingHourDTO
	{
		public int Id { get; set; }

		public int ExpectedHours { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public string MethodOfTracking { get; set; }

		public int UserId { get; set; }

		public UserDTO User { get; set; }

		public int ProjectId { get; set; }

		public ProjectDTO Project { get; set; }
	}
}
