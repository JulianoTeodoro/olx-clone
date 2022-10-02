using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Validations
{
    public class ValidationImage: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string valor = (string)value;
            var calcular = System.Text.Encoding.UTF8.GetByteCount(valor);

            if (calcular > 1000000)
            {
                return new ValidationResult("A imagem deve ser menor que 2 mb");
            }
            return ValidationResult.Success;
        }
    }
}
