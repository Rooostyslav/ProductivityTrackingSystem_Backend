using PTS.BLL.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.WorkingHour
{
	public class UpdateWorkingHourDTO
	{
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Working hour id must be between {1} and {2}.")]
		[ExistWorkingHourById(ErrorMessage = "The working hour does not exist.")]
		public int Id { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Expected hours id must be between {1} and {2}.")]
		public int ExpectedHours { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartTime { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime EndTime { get; set; }

		[Required]
		[StringLength(50)]
		public string MethodOfTracking { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "User id must be between {1} and {2}.")]
		[ExistUserById(ErrorMessage = "The user does not exist.")]
		public int UserId { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Project id must be between {1} and {2}.")]
		[ExistProjectById(ErrorMessage = "The project does not exist.")]
		public int ProjectId { get; set; }
	}
}
