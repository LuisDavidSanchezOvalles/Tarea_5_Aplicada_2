﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamoDetalle.Validations
{
    public class NombresValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cadena = value as string;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                //if (cadena.Length <= 0)
                //    return new ValidationResult("Debes poner un Nombre");


                foreach (var caracter in cadena)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                        return new ValidationResult("El nombre solo puede tener letras");
                }

                return ValidationResult.Success;

            }
            return new ValidationResult("Debes poner un Nombre");
        }
    }
}
