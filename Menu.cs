﻿using SegundoParcial.Entidades;
using SegundoParcial.UI.Consulta;
using SegundoParcial.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void AsignaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rAsignaturas().ShowDialog();
            //rAsignaturas rAsignaturas = new rAsignaturas();
            //rAsignaturas.Show();
        }

        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rEstudiante().ShowDialog();
            //rEstudiante rEstudiante = new rEstudiante();
            //rEstudiante.Show();
        }

        private void AsignaturaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new cAsignaturas().ShowDialog();
        }

        private void EstudianteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           new cEstudiante().ShowDialog();
        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rInscripcion().ShowDialog();
        }

        //private void TipoAnalisisToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    rTipoAnalisis rTipoAnalisis = new rTipoAnalisis();
        //    rTipoAnalisis.Show();
        //}
    }
}