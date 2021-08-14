using PTS.BLL.Validation;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.DTOs.Project
{
	public class CreateProjectDTO
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Description { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Company id must be between {1} and {2}.")]
		[ExistCompanyById(ErrorMessage = "The company does not exist.")]
		public int CompanyId { get; set; }
	}
}
