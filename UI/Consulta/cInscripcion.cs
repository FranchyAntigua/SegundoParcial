using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.UI.Consulta
{
    public partial class cInscripcion : Form
    {
        public cInscripcion()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            Expression<Func<Inscripcion, bool>> filtro = f => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://InscripcionId.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = f => f.InscripcionId == id;
                    break;
                case 1://Fecha.
                    filtro = f => f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date;
                    break;
                case 2://EstudianteId.
                    filtro = f => f.EstudianteId.Equals(CriterioTextBox.Text) && (f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date);
                    break;
                case 6://Monto.
                    filtro = f => f.Monto.Equals(CriterioTextBox.Text) && (f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date);
                    break;
            }

            ConsultaDataGridView.DataSource = InscripcionBLL.GetList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
