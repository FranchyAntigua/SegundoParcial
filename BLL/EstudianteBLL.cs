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
   public class EstudianteBLL
    {
        public static bool Guardar(Estudiante estudiante)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Estudiante.Add(estudiante) != null)
                {
                    contexto.SaveChanges();
                    estado = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }

        public static bool Editar(Estudiante estudiante)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    estado = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }
        public static bool Eliminar(int id)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                Estudiante estudiante = contexto.Estudiante.Find(id);

                contexto.Estudiante.Remove(estudiante);

                if (contexto.SaveChanges() > 0)
                {
                    estado = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }

        public static Estudiante Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiante estudiante = new Estudiante();
            try
            {
                estudiante = contexto.Estudiante.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;


        }
        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> expression)
        {
            List<Estudiante> estudiante = new List<Estudiante>();
            Contexto contexto = new Contexto();

            try
            {
                estudiante = contexto.Estudiante.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return estudiante;
        }
    }
}
