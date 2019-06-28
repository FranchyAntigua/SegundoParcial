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
    public class AsignaturasTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Asignaturas a = new Asignaturas();
            a.AsignaturaId = 1;
            a.Descripcion = "Calculo";
            a.Creditos = 4;

            AsignaturasBLL<Asignaturas> asignaturas = new AsignaturasBLL<Asignaturas>();
            bool estado = false;
            estado = AsignaturasBLL.Guardar(a);
            Assert.AreEqual(true, estado);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            AsignaturasBLL<Asignaturas> asignaturas = new AsignaturasBLL<Asignaturas>();
            bool estado = false;
            Asignaturas a = AsignaturasBLL.Buscar(1);
            a.Descripcion = "Aplicada";
            estado = AsignaturasBLL.Modificar(a);
            Assert.AreEqual(true, estado);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            AsignaturasBLL<Asignaturas> asignaturas = new AsignaturasBLL<Asignaturas>();
            Asignaturas a = AsignaturasBLL.Buscar(1);
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void GetListTest()
        {
            AsignaturasBLL<Asignaturas> asignaturas = new AsignaturasBLL<Asignaturas>();
            List<Asignaturas> lista = new List<Asignaturas>();
            lista = AsignaturasBLL.GetList(c => true);
            Assert.IsNotNull(lista);
        }

        //[TestMethod()]
        //public void EliminarTest()
        //{
        //    AsignaturasBLL<Asignaturas> asignaturas = new AsignaturasBLL<Asignaturas>();
        //    bool estado = false;
        //    estado = AsignaturasBLL.Eliminar(1);
        //    Assert.AreEqual(true, estado);
        //}
    }
    internal class AsignaturasBLL<T>
    {
    }
}
