using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamoDetalle.Validations
{
    public class FechaNacimientoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if (fecha > DateTime.Now)
                    return new ValidationResult("Debes poner una Fecha valida");

                if (fecha < DateTime.Now.AddYears(-100))
                    return new ValidationResult("Esta fecha es muy antigua");

                return ValidationResult.Success;

            }
            return new ValidationResult("Debes poner una Fecha");
        }
    }
}
