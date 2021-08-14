using PTS.BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.Validation
{
	public class ExistCompanyByIdAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				ICompanyService companyService =
					(ICompanyService)validationContext.GetService(typeof(ICompanyService));

				var result = companyService.FindByIdAsync((int)value).Result;
				if (result == null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
