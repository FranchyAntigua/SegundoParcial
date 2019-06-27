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
            LlenarComboBox();
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
                    item.Cells["Nombres"].Value.ToString(),
                    Convert.ToInt32(item.Cells["AsignaturaId"].Value),
                    item.Cells["Descripcion"].Value.ToString(),
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

            if (DetalleDataGridView.RowCount == 0)
            {
                MyErrorProvider.SetError(DetalleDataGridView,
                    "No puede estar vacio");
                estado = true;
            }

            return estado;
        }

        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<InscripcionDetalle> detalle = new List<InscripcionDetalle>();
            if (String.IsNullOrWhiteSpace(PrecioCreditoTextBox.Text))
            {
                MyErrorProvider.SetError(PrecioCreditoTextBox,
                    "No puede estar vacio");
                return;
            }
            if (DetalleDataGridView.DataSource != null)
            {
                detalle = (List<InscripcionDetalle>)DetalleDataGridView.DataSource;
            }
            detalle.Add(
               new InscripcionDetalle(
                   id: 0,
                   inscripcionId: (int)IdNumericUpDown.Value,
                   estudianteId: (int)EstudianteComboBox.SelectedValue,
                   nombres: EstudianteComboBox.Text,
                   asignaturaId: (int)AsignaturaComboBox.SelectedValue,
                   descripcion: AsignaturaComboBox.Text,
                   precioCredito: ToInt(PrecioCreditoTextBox.Text),
                   monto: ToInt(MontoTextBox.Text)
               ));

            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = detalle;
            DetalleDataGridView.Columns["Id"].Visible = false;
            DetalleDataGridView.Columns["InscripcionId"].Visible = false;
            DetalleDataGridView.Columns["Estudiante"].Visible = false;
            DetalleDataGridView.Columns["Asignatura"].Visible = false;
            DetalleDataGridView.Columns["EstudianteId"].Visible = false;
            DetalleDataGridView.Columns["AsignaturaId"].Visible = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EstudianteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
