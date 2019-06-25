using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
  public  class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }
        public string Descripcion { get; set; }
        public int Creditos { get; set; }

        public Asignaturas()
        {
            this.AsignaturaId = 0;
            this.Descripcion = string.Empty;
            this.Creditos = 0;
        }
    }
}
