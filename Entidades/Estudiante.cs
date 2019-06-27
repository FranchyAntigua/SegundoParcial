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
        public int Balance { get; set; }

        public Estudiante()
        {
            this.EstudianteId = 0;
            this.Fecha = DateTime.Now;
            this.Nombres = string.Empty;
            this.Balance = 0;

        }
    }
}
