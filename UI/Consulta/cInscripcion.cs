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
            CriterioTextBox.ReadOnly = true;
            FiltroComboBox.SelectedIndex = 0;
        }

        private List<Inscripcion> Buscar()
        {
            List<Inscripcion> lista = new List<Inscripcion>();
            Expression<Func<Inscripcion, bool>> filtro = f => true;
            int id = Convert.ToInt32(FiltroComboBox.SelectedIndex);
            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.ReadOnly = false;
                if (String.IsNullOrWhiteSpace(CriterioTextBox.Text))
                {
                    MyErrorProvider.SetError(CriterioTextBox, "No puede estar vacio");
                }
            }
            switch (id)
            {
                case 0://Todo.
                    break;
                case 1://InscripcionId.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = f => f.InscripcionId == id;
                    break;
                case 2://Fecha.
                    filtro = f => f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date;
                    break;
                case 3://EstudianteId.
                    filtro = f => f.EstudianteId.ToString().Contains(CriterioTextBox.Text);
                    break;
                case 4://Monto.
                    filtro = f => f.Monto.ToString().Contains(CriterioTextBox.Text);
                    break;
            }

            lista = InscripcionBLL.GetList(filtro);
            return lista;
        }

        private List<Inscripcion> BuscarRangoFecha()
        {
            List<Inscripcion> lista = new List<Inscripcion>();
            Expression<Func<Inscripcion, bool>> filtro = f => true;
            int id = Convert.ToInt32(FiltroComboBox.SelectedIndex);
            if (FiltroComboBox.SelectedIndex != 0 && FiltroComboBox.SelectedIndex != 2)
            {
                CriterioTextBox.ReadOnly = false;
                if (String.IsNullOrWhiteSpace(CriterioTextBox.Text))
                {
                    MyErrorProvider.SetError(CriterioTextBox, "No puede estar vacio");
                }
            }
            switch (id)
            {
                case 0://Todo.
                    filtro = f => f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date;
                    break;
                case 1://InscripcionId.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = f => f.InscripcionId == id && (f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date);
                    break;
                case 2://Fecha.
                    filtro = f => f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date;
                    break;
                case 3://EstudianteId.
                    filtro = f => f.EstudianteId.ToString().Contains(CriterioTextBox.Text) && f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date;
                    break;
                case 4://Monto.
                    filtro = f => f.Monto.ToString().Contains(CriterioTextBox.Text) && (f.Fecha >= FechaDesdeDateTimePicker.Value.Date && f.Fecha <= FechaHastaDateTimePicker.Value.Date);
                    break;
            }
            lista = InscripcionBLL.GetList(filtro);
            return lista;
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 2)
            {
                CriterioTextBox.ReadOnly = true;
            }
            else
            {
                CriterioTextBox.ReadOnly = false;
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (RangoFechaCheckBox.Checked == true)
                ConsultaDataGridView.DataSource = BuscarRangoFecha();
            else
                ConsultaDataGridView.DataSource = Buscar();
        }
    }
}
