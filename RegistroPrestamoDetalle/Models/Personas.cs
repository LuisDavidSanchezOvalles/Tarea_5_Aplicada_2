using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RegistroPrestamoDetalle.Validations;

namespace RegistroPrestamoDetalle.Models
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "No debe de estar Vacío el campo 'PersonaId'")]
        [IdValidacion]
        public int PersonaId { set; get; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Nombre'")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Telefono'")]
        [TelefonoValidacion]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Cedula'")]
        [CedulaValidacion]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Dirección'")]
        [MinLength(10, ErrorMessage = "La dirección bebe tener minimo (10 caracteres).")]
        [MaxLength(100, ErrorMessage = "La dirección debe tener Maximo (100 caracteres).")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]
        [FechaNacimientoValidacion]
        public DateTime FechaNacimiento { get; set; }
        public decimal Balance { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombres = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0;
        }

        public Personas(int personaId, string nombre, string telefono, string cedula, string direccion, DateTime fechaNacimiendo, decimal balance)
        {
            PersonaId = personaId;
            Nombres = nombre;
            Telefono = telefono;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiendo;
            Balance = balance;
        }
    }
}
