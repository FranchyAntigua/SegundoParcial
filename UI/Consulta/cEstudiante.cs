﻿using SegundoParcial.BLL;
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
    public partial class cEstudiante : Form
    {
        public cEstudiante()
        {
            InitializeComponent();
            CriterioTextBox.ReadOnly = true;
            FiltroComboBox.SelectedIndex = 0;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Estudiante, bool>> filtro = a => true;
            int id;
            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.ReadOnly = false;
                if (String.IsNullOrWhiteSpace(CriterioTextBox.Text))
                {
                    MyErrorProvider.SetError(CriterioTextBox, "No puede estar vacio");
                    return;
                }
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo.
                        break;
                    case 1://Id. 
                        id = Convert.ToInt32(CriterioTextBox.Text);
                        filtro = a => a.EstudianteId == id;
                        break;

                }
            }

            EstudianteConsultaDataGridView.DataSource = EstudianteBLL.GetList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.ReadOnly = false;
            }
        }

        private void CriterioTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
