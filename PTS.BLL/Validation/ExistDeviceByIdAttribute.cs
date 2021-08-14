using PTS.BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PTS.BLL.Validation
{
	public class ExistDeviceByIdAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IDeviceService deviceService =
					(IDeviceService)validationContext.GetService(typeof(IDeviceService));

				var result = deviceService.FindByIdAsync((int)value).Result;
				if (result == null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
