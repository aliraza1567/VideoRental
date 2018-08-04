using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.Validations
{
    public class StockNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock <= 0 || movie.NumberInStock > 20)
            {
                return new ValidationResult("Stock number should be between 1 and 20");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}