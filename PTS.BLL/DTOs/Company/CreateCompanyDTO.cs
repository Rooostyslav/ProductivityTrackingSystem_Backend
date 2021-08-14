using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.Company
{
	public class CreateCompanyDTO
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string BusinessDomain { get; set; }
	}
}
