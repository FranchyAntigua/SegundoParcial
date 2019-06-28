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
    public partial class rEstudiante : Form
    {
        public rEstudiante()
        {
            InitializeComponent();
            BalanceTextBox.Text = "0";
        }

        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();

            estudiante.EstudianteId = Convert.ToInt32(IdnumericUpDown.Value);
            estudiante.Fecha= FechaDateTimePicker.Value;
            estudiante.Nombres = NombrestextBox.Text;
            estudiante.Balance = 0;

            return estudiante;
        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            NombrestextBox.Clear();
            BalanceTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool estado = false;

            if (IdnumericUpDown.Value < 0)
            {
                MyErrorProvider.SetError(IdnumericUpDown,
                    "No es un id válido");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox,
                    "No puede estar vacio");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                MyErrorProvider.SetError(BalanceTextBox,
                    "No puede estar vacio");
                estado = true;
            }
            return estado;
        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Estudiante estudiante = EstudianteBLL.Buscar(id);

            if (estudiante != null)
            {
                FechaDateTimePicker.Value = estudiante.Fecha;
                NombrestextBox.Text = estudiante.Nombres;
                BalanceTextBox.Text = estudiante.Balance.ToString();
            }
            else
                MessageBox.Show("No se encontró", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool estado = false;
            Estudiante estudiante = new Estudiante();

            if (Validar())
            {
                MessageBox.Show("Llene los campos correctamente", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                estudiante = LlenaClase();

                if (Convert.ToInt32(IdnumericUpDown.Value) == 0)
                {
                    estado = EstudianteBLL.Guardar(estudiante);
                    MessageBox.Show("Guardado", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {

                    int id = Convert.ToInt32(IdnumericUpDown.Value);
                    Estudiante usu = new Estudiante();
                    usu = EstudianteBLL.Buscar(id);

                    if (usu != null)
                    {
                        estado = EstudianteBLL.Modificar(LlenaClase());
                        MessageBox.Show("Modificado", "Exito",
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
                    MessageBox.Show("No se pudo guardar", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void REstudiante_Load(object sender, EventArgs e)
        {

        }
    }
}
