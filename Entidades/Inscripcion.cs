using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
    public class Inscripcion
    {

        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        public virtual List<InscripcionDetalle> Detalle { get; set; }


        public Inscripcion(int inscripcionId)
        {

            InscripcionId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            this.Detalle = new List<InscripcionDetalle>();
        }

        public void AgregarDetalle(int inscripcionId, int EstudianteId, int Monto)
        {
            this.Detalle.Add(new InscripcionDetalle(inscripcionId, EstudianteId, Monto));
        }
    }
}


