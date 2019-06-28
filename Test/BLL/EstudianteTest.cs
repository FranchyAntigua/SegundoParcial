using Microsoft.VisualStudio.TestTools.UnitTesting;
using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BLL
{
    [TestClass()]
    public class EstudianteTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Estudiante e = new Estudiante();
            e.EstudianteId = 1;
            e.Fecha = DateTime.Now;
            e.Nombres = "Calculo";
            e.Balance = 0;

            EstudianteBLL<Estudiante> estudiante = new EstudianteBLL<Estudiante>();
            bool estado = false;
            estado = EstudianteBLL.Guardar(e);
            Assert.AreEqual(true, estado);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            EstudianteBLL<Estudiante> Estudiante = new EstudianteBLL<Estudiante>();
            bool estado = false;
            Estudiante e = EstudianteBLL.Buscar(1);
            e.Nombres = "Fisica";
            estado = EstudianteBLL.Modificar(e);
            Assert.AreEqual(true, estado);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            EstudianteBLL<Estudiante> estudiante = new EstudianteBLL<Estudiante>();
            Estudiante e = EstudianteBLL.Buscar(1);
            Assert.IsNotNull(e);
        }

        [TestMethod()]
        public void GetListTest()
        {
            EstudianteBLL<Estudiante> estudiante = new EstudianteBLL<Estudiante>();
            List<Estudiante> lista = new List<Estudiante>();
            lista = EstudianteBLL.GetList(c => true);
            Assert.IsNotNull(lista);
        }

        //[TestMethod()]
        //public void EliminarTest()
        //{
        //    EstudianteBLL<Estudiante> estudiante = new EstudianteBLL<Estudiante>();
        //    bool estado = false;
        //    estado = EstudianteBLL.Eliminar(1);
        //    Assert.AreEqual(true, estado);
        //}
        internal class EstudianteBLL<T>
        {
        }
    }
}
