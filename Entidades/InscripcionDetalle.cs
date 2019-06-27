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
        public int AsignaturaId { get; set; }
        public int EstudianteId { get; set; }

        public InscripcionDetalle(int inscripcionId)
        {

                InscripcionId = 0;
                AsignaturaId = 0;
                EstudianteId = 0;
            }

            public InscripcionDetalle(int inscripcionId, int asignaturaId, int estudianteId)
            {
                InscripcionId = inscripcionId;
                AsignaturaId = asignaturaId;
                EstudianteId = estudianteId;
            }
        }
}
