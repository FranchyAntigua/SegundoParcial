using Microsoft.VisualStudio.TestTools.UnitTesting;
using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.BLL
{
    [TestClass()]
    public class InscripcionTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool estado = false;
            Inscripcion i = new Inscripcion();
            i.InscripcionId = 6;
            i.Fecha = DateTime.Now;
            i.EstudianteId = 3;
            i.Monto = 200;

            i.Detalle.Add(new InscripcionDetalle(0, 6, 2, "Matematicas", 50, 200));

            estado = InscripcionBLL.Guardar(i);
            Assert.AreEqual(true, estado);
        }

        [TestMethod()]
        public void Modificar()
        {
            bool estado = false;
            int id = 6;
            Inscripcion i = new Inscripcion();
            bool paso = i.Detalle.Count > 0;
            i = InscripcionBLL.Buscar(id);
            i.Monto = 300;
            estado = InscripcionBLL.Modificar(i);
            Assert.AreEqual(true, estado);
        }

        [TestMethod()]
        public void Buscar()
        {
            int id = 6;
            Inscripcion i = new Inscripcion();
            bool paso = i.Detalle.Count > 0;
            i = InscripcionBLL.Buscar(id);
            Assert.IsNotNull(i);
        }

        [TestMethod()]
        public void GetList()
        {
            List<Inscripcion> lista = new List<Inscripcion>();
            Expression<Func<Inscripcion, bool>> resultados = p => true;
            lista = InscripcionBLL.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void Eliminar()
        {
            int id = 6;
            bool paso = InscripcionBLL.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }
}
