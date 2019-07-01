﻿using SegundoParcial.BLL;
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
    public partial class rAsignaturas : Form
    {
        public rAsignaturas()
        {
            InitializeComponent();
        }

        private Asignaturas LlenaClase()
        {
            Asignaturas asig = new Asignaturas();

            asig.AsignaturaId = Convert.ToInt32(IdnumericUpDown.Value);
            asig.Descripcion = DescripciontextBox.Text;
            asig.Creditos = Convert.ToInt32(CreditosTextBox.Text);

            return asig;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CreditosTextBox.Clear();
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

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox,
                    "No puede estar vacio");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(CreditosTextBox.Text))
            {
                MyErrorProvider.SetError(IdnumericUpDown,
                    "No es un credito válido");
                estado = true;
            }

            return estado;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Asignaturas asig = AsignaturasBLL.Buscar(id);

            if (asig != null)
            {
                DescripciontextBox.Text = asig.Descripcion;
                CreditosTextBox.Text = asig.Creditos.ToString();
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
            Asignaturas asig = new Asignaturas();

            if (Validar())
            {
                MessageBox.Show("Llene los campos correctamente", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                asig = LlenaClase();

                if (Convert.ToInt32(IdnumericUpDown.Value) == 0)
                {
                    estado = AsignaturasBLL.Guardar(asig);
                    MessageBox.Show("Guardado", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {

                    int id = Convert.ToInt32(IdnumericUpDown.Value);
                    Asignaturas asignaturas = new Asignaturas();
                    asignaturas = AsignaturasBLL.Buscar(id);

                    if (asignaturas != null)
                    {
                        estado = AsignaturasBLL.Modificar(LlenaClase());
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

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            Asignaturas asig = AsignaturasBLL.Buscar(id);

            if (asig != null)
            {
                if (AsignaturasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CreditosTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede digitar Números", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DescripciontextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se escribir Letras", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se escribir Letras", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }
    }
  }






