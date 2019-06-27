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
    public partial class cEstudiante : Form
    {
        public cEstudiante()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Estudiante, bool>> filtro = a => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID 
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => a.EstudianteId == id;
                    break;

            }
            EstudianteConsultaDataGridView.DataSource = EstudianteBLL.GetList(filtro);
        }

    }
}
