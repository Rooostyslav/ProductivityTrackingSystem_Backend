using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.DAL.Entities
{
	public class WorkingHour
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		public int ExpectedHours { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime StartTime { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.DateTime)]
		public DateTime EndTime { get; set; }

		[Required]
		[Column(Order = 5)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string MethodOfTracking { get; set; }

		[Required]
		[Column(Order = 6)]
		public int UserId { get; set; }

		public virtual User User { get; set; }

		[Required]
		[Column(Order = 7)]
		public int ProjectId { get; set; }

		public virtual Project Project { get; set; }
	}
}
