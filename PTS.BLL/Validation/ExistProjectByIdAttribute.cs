using PTS.BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.Validation
{
	public class ExistProjectByIdAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IProjectService projectService =
					(IProjectService)validationContext.GetService(typeof(IProjectService));

				var result = projectService.FindByIdAsync((int)value).Result;
				if (result == null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
