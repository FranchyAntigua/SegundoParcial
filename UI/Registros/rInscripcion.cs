using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.UI.Registros
{
    public partial class rInscripcion : Form
    {
        public rInscripcion()
        {
            InitializeComponent();
        }

        private void LlenarCampos(Inscripcion inscripcion)
        {
            IdNumericUpDown.Value = inscripcion.InscripcionId;
            FechaDateTimePicker.Value = inscripcion.Fecha;
            MontoTextBox.Text = inscripcion.Monto.ToString();
            DetalleDataGridView.DataSource = inscripcion.Detalle;

            DetalleDataGridView.Columns["Id"].Visible = false;
            DetalleDataGridView.Columns["InscripcionId"].Visible = false;
        }

        private void LlenarComboBox()
        {
            Repositorio<Estudiante> repositorioE = new Repositorio<Estudiante>();
            Repositorio<Asignaturas> repositorioA = new Repositorio<Asignaturas>();

            EstudianteComboBox.DataSource = repositorioE.GetList(c => true);
            EstudianteComboBox.ValueMember = "EstudianteId";
            EstudianteComboBox.DisplayMember = "Nombres";

            AsignaturaComboBox.DataSource = repositorioA.GetList(c => true);
            AsignaturaComboBox.ValueMember = "AsignaturaId";
            AsignaturaComboBox.DisplayMember = "Descripcion";

        }

        private Inscripcion LlenaClase()
        {
            Inscripcion inscripcion = new Inscripcion();

            inscripcion.InscripcionId = Convert.ToInt32(IdNumericUpDown.Value);
            inscripcion.Fecha = FechaDateTimePicker.Value;
            inscripcion.Monto = Convert.ToInt32(MontoTextBox.Text);

            foreach (DataGridViewRow item in DetalleDataGridView.Rows)
            {
                inscripcion.AgregarDetalle(
                    Convert.ToInt32(item.Cells["Id"].Value),
                    Convert.ToInt32(item.Cells["InscripcionId"].Value),
                    Convert.ToInt32(item.Cells["EstudianteId"].Value),
                    Convert.ToInt32(item.Cells["AsignaturaId"].Value),
                    Convert.ToInt32(item.Cells["PrecioCredito"].Value),
                    Convert.ToInt32(item.Cells["Monto"].Value)
                );
            }

            return inscripcion;
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            EstudianteComboBox.SelectedIndex = 0;
            AsignaturaComboBox.SelectedIndex = 0;
            MontoTextBox.Clear();
            DetalleDataGridView.DataSource = null;
            MyErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool estado = false;

            if (AnalisisDataGridView.RowCount == 0)
            {
                MyErrorProvider.SetError(ResultadotextBox,
                    "No puede estar vacio");
                estado = true;
            }

            return estado;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EstudianteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
