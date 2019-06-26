using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
   public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Balance { get; set; }
        public virtual List<InscripcionDetalle> Detalle { get; set; }

        public Estudiante()
        {
            this.EstudianteId = 0;
            this.Fecha = DateTime.Now;
            this.Nombres = string.Empty;
            this.Balance = string.Empty;
            this.Detalle = new List<InscripcionDetalle>();

        }
        public void AgregarDetalle(int inscripcionId, DateTime Fecha, int Monto)
        {
            this.Detalle.Add(new InscripcionDetalle (inscripcionId, Fecha, Monto));
        }
    }
}
