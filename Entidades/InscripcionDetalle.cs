using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
   public class InscripcionDetalle
    {
        [Key]
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCredito { get; set; }
        public int Monto { get; set; }

        [ForeignKey("AsignaturaId")]
        public virtual Asignaturas Asignatura { get; set; }

        public InscripcionDetalle()
        {
            Id = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            Descripcion = string.Empty;
            PrecioCredito = 0;
            Monto = 0;
        }

        public InscripcionDetalle(int id, int inscripcionId, int asignaturaId, string descripcion, int precioCredito, int monto)
        {
            Id = id;
            InscripcionId = inscripcionId;
            AsignaturaId = asignaturaId;
            Descripcion = descripcion;
            PrecioCredito = precioCredito;
            Monto = monto;
        }
   }
}
