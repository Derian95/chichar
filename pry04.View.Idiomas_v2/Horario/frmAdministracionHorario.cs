using pry04.View.Idiomas_v2.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pry04.View.Idiomas_v2.Horario
{
    public partial class frmAdministracionHorario : Form
    {
        public frmAdministracionHorario()
        {
            InitializeComponent();
        }

        private void frmAdministracionHorario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}
