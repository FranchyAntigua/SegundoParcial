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
   public class AsignaturasBLL
    {

        public static bool Guardar(Asignaturas asignaturas)
        {
            bool estado = false;
            try
            {
                Contexto context = new Contexto();
                context.Asignaturas.Add(asignaturas);
                context.SaveChanges();
                estado = true;

            }
            catch (Exception)
            {

                throw;
            }
            return estado;
        }
        public static bool Editar(Asignaturas asignaturas)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(asignaturas).State = EntityState.Modified;
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
                Asignaturas asignaturas = contexto.Asignaturas.Find(id);

                contexto.Asignaturas.Remove(asignaturas);

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
        public static Asignaturas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Asignaturas asignaturas = new Asignaturas();
            try
            {
                asignaturas = contexto.Asignaturas.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return asignaturas;
        }
        public static List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> expression)
        {
            List<Asignaturas> analisis = new List<Asignaturas>();
            Contexto contexto = new Contexto();

            try
            {
                analisis = contexto.Asignaturas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return analisis;
        }
    }
}
