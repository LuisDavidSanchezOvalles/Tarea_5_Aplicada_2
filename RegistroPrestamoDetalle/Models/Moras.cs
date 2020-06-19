using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RegistroPrestamoDetalle.Validations;

namespace RegistroPrestamoDetalle.Models
{
    public class Moras
    {
        [Key]
        [Required(ErrorMessage = "No debe de estar Vacío el campo 'MoraId'")]
        [IdValidacion]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Total'")]
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MoraDetalle { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MoraDetalle = new List<MorasDetalle>();
        }

        public Moras(int moraId, DateTime fecha, decimal total)
        {
            MoraId = moraId;
            Fecha = fecha;
            Total = total;
        }
    }
}
