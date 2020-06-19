using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegistroPrestamoDetalle.Validations
{
    public class CedulaValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string cadena = value as string;

                String expresion;
                expresion = @"^\d{3}[- ]?\d{7}[- ]?\d{1}$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Cedula no valida");
                    }
                }
                else
                    return new ValidationResult("Cedula no valido");
            }
            return new ValidationResult("Debe introducir una cedula");
        }
    }
}
