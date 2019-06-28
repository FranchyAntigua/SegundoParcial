using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.BLL
{
    public class InscripcionBLL
    {
        public static bool Guardar(Inscripcion inscripcion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Inscripcion.Add(inscripcion) != null)
                {
                    contexto.Estudiante.Find(inscripcion.EstudianteId).Balance += inscripcion.Monto;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Inscripcion inscripcion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            var Estudiante = contexto.Estudiante.Find(inscripcion.EstudianteId);
            try
            {
                Inscripcion InscripcionAnt = Buscar(inscripcion.InscripcionId);

                if (InscripcionAnt.EstudianteId != inscripcion.EstudianteId)
                {
                    var EstudianteAnterior = contexto.Estudiante.Find(InscripcionAnt.EstudianteId);
                    Estudiante.Balance += inscripcion.Monto;
                    EstudianteAnterior.Balance -= InscripcionAnt.Monto;
                    EstudianteBLL.Modificar(Estudiante);
                    EstudianteBLL.Modificar(EstudianteAnterior);
                }

                int modificado = inscripcion.Monto - InscripcionAnt.Monto;
                Estudiante.Balance += modificado;
                EstudianteBLL.Modificar(Estudiante);

                contexto.Entry(inscripcion).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Inscripcion inscripcion = contexto.Inscripcion.Find(id);

                contexto.Estudiante.Find(inscripcion.EstudianteId).Balance -= inscripcion.Monto;

                contexto.Inscripcion.Remove(inscripcion);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Inscripcion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inscripcion inscripcion = new Inscripcion();

            try
            {
                inscripcion = contexto.Inscripcion.Find(id);

                if (inscripcion != null)
                {

                    inscripcion.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return inscripcion;
        }


        public static List<Inscripcion> GetList(Expression<Func<Inscripcion, bool>> expression)
        {
            List<Inscripcion> lista = new List<Inscripcion>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Inscripcion.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }        

    }
}
