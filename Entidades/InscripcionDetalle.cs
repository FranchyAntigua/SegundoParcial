using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
   public class InscripcionDetalle
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }

        public InscripcionDetalle(int inscripcionId)
        {

                InscripcionId = 0;
                Fecha = DateTime.Now;
                Monto = 0;
            }

            public InscripcionDetalle(int inscripcionId, DateTime fecha, int monto)
            {
                InscripcionId = inscripcionId;
                Fecha = fecha;
                Monto = monto;
            }
        }
}
