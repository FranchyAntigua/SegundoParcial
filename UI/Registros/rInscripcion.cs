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
            EstudianteComboBox.SelectedValue = inscripcion.EstudianteId;
            FechaDateTimePicker.Value = inscripcion.Fecha;
            MontoTextBox.Text = inscripcion.Monto.ToString();
            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = inscripcion.Detalle;
            DetalleDataGridView.Columns["Id"].Visible = false;
            DetalleDataGridView.Columns["InscripcionId"].Visible = false;
            DetalleDataGridView.Columns["Asignatura"].Visible = false;
            DetalleDataGridView.Columns["AsignaturaId"].Visible = false;
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
            inscripcion.EstudianteId = Convert.ToInt32(EstudianteComboBox.SelectedValue);
            inscripcion.Monto = Convert.ToInt32(MontoTextBox.Text);

            foreach (DataGridViewRow item in DetalleDataGridView.Rows)
            {
                inscripcion.AgregarDetalle(
                    Convert.ToInt32(item.Cells["Id"].Value),
                    Convert.ToInt32(item.Cells["InscripcionId"].Value),
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
            CreditosLabel.Text = "";
            PrecioCreditoTextBox.Text= string.Empty;
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

        private void CalcularMonto()
        {
            List<InscripcionDetalle> detalle = new List<InscripcionDetalle>();

            if (DetalleDataGridView.DataSource != null)
            {
                detalle = (List<InscripcionDetalle>)DetalleDataGridView.DataSource;
            }
            double Total = 0;
            foreach (var item in detalle)
            {
                Total += item.Monto;
            }
            MontoTextBox.Text = Total.ToString();
        }

        private void QuitarMontoFila()
        {
            List<InscripcionDetalle> detalle = new List<InscripcionDetalle>();

            if (DetalleDataGridView.DataSource != null)
            {
                detalle = (List<InscripcionDetalle>)DetalleDataGridView.DataSource;
            }
            double Total = 0;
            foreach (var item in detalle)
            {
                Total -= item.Monto;
            }
            Total *= (-1);
            MontoTextBox.Text = Total.ToString();
        }

        private void PrecioCreditos()
        {
            string descripcion = AsignaturaComboBox.Text;
            Repositorio<Asignaturas> repositorio = new Repositorio<Asignaturas>();
            List<Asignaturas> lista = repositorio.GetList(c => c.Descripcion == descripcion);
            foreach (var item in lista)
            {
                CreditosLabel.Text = item.Creditos.ToString();
            }
        }

        //ESTE ES EL EVENTO DE AGREGAR.
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

            int montoCre = 0;
            int precioCred = ToInt(PrecioCreditoTextBox.Text);
            int credi = ToInt(CreditosLabel.Text);
            montoCre = precioCred * credi;
            detalle.Add(
               new InscripcionDetalle(
                   id: 0,
                   inscripcionId: (int)IdNumericUpDown.Value,
                   asignaturaId: (int)AsignaturaComboBox.SelectedValue,
                   descripcion: AsignaturaComboBox.Text,
                   precioCredito: ToInt(PrecioCreditoTextBox.Text),
                   monto: montoCre
               ));

            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = detalle;
            DetalleDataGridView.Columns["Id"].Visible = false;
            DetalleDataGridView.Columns["InscripcionId"].Visible = false;
            DetalleDataGridView.Columns["Asignatura"].Visible = false;
            DetalleDataGridView.Columns["AsignaturaId"].Visible = false;

            CalcularMonto();
        }

        //ESTE ES EL EVENTO DE REMOVER.
        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (DetalleDataGridView.Rows.Count > 0 && DetalleDataGridView.CurrentRow != null)
            {
                List<InscripcionDetalle> detalle = (List<InscripcionDetalle>)DetalleDataGridView.DataSource;

                detalle.RemoveAt(DetalleDataGridView.CurrentRow.Index);

                DetalleDataGridView.DataSource = null;
                DetalleDataGridView.DataSource = detalle;
                DetalleDataGridView.Columns["Id"].Visible = false;
                DetalleDataGridView.Columns["InscripcionId"].Visible = false;
                DetalleDataGridView.Columns["Asignatura"].Visible = false;
                DetalleDataGridView.Columns["AsignaturaId"].Visible = false;
                QuitarMontoFila();
            }
        }     

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Inscripcion inscripcion = InscripcionBLL.Buscar(id);

            if (inscripcion != null)
            {
                LlenarCampos(inscripcion);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion;

            bool estado = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            if (IdNumericUpDown.Value == 0)
            {
                estado = InscripcionBLL.Guardar(LlenaClase());
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdNumericUpDown.Value);
                Inscripcion inscrip = InscripcionBLL.Buscar(id);

                if (inscrip != null)
                {
                  
                    inscrip = LlenaClase();
                    estado = InscripcionBLL.Modificar(inscrip);
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (estado)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);

            Inscripcion inscripcion = InscripcionBLL.Buscar(id);

            if (inscripcion != null)
            {
                if (InscripcionBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void AsignaturaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrecioCreditos();
        }

        private void PrecioCreditoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede digitar Números", "Falló",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se escribir Letras", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede digitar Números", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
