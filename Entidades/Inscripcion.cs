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
        public int IncripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }

        public Inscripcion()
        {
            this.IncripcionId = 0;
            this.Fecha = DateTime.Now;
            this.Monto = 0;

        }
    }
}
