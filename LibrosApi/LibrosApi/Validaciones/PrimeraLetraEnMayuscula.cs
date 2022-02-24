using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Validaciones
{
    public class PrimeraLetraEnMayuscula: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra.ToUpper() != primeraLetra)
            {
                return new ValidationResult("La primera Letra debe ser Mayuscula");
            }

            return ValidationResult.Success;
        }
    }
}
