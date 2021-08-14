using PTS.BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.Validation
{
	public class ExistWorkingHourByIdAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IWorkingHourService workingHourService =
					(IWorkingHourService)validationContext.GetService(typeof(IWorkingHourService));

				var result = workingHourService.FindByIdAsync((int)value).Result;
				if (result == null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
