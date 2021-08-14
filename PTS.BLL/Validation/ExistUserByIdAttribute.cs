using PTS.BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.Validation
{
	public class ExistUserByIdAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IUserService userService =
					(IUserService)validationContext.GetService(typeof(IUserService));

				var result = userService.FindByIdAsync((int)value).Result;
				if (result == null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
