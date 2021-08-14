using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.Backup
{
	public class Backup
	{
		[Required]
		[StringLength(50)]
		public string FileName { get; set; }
	}
}
