using System;
using System.Windows.Forms;

using pry04.View.Idiomas_v2.CargaHoraria;
using pry04.View.Idiomas_v2.Semestre;
using pry04.View.Idiomas_v2.Horario;
using pry04.View.Idiomas_v2.Individuo;
using pry04.View.Idiomas_v2.PlanEstudio;
using pry04.View.Idiomas_v2.Matricula;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;


namespace pry04.View.Idiomas_v2.Principal
{
    public partial class frmFormularioPadre : Form
    {
        public frmFormularioPadre()
        {
            InitializeComponent();
        }

        private void mtd_MostrarInformacionCronograma()
        {
            try
            {
                txtInfo.Text =
                    "IdSem: " + stuSistema.esquemaCronograma.IdSem
                    + " IdIdi_Semestre: " + stuSistema.esquemaCronograma.IdIdi_Semestre
                    + " Anio: " + stuSistema.esquemaCronograma.Anio
                    + " Mes: " + stuSistema.esquemaCronograma.Mes
                    + " Semestre: " + stuSistema.esquemaCronograma.Semestre;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarCronograma()
        {
            try
            {
                frmAdministracionSemestre Formulario = new frmAdministracionSemestre();
                if (Formulario.ShowDialog(this) == DialogResult.OK)
                {
                    stuSistema.esquemaCronograma = Formulario.env_stuCronogramaSeleccionado;
                    if (stuSistema.esquemaCronograma.IdSem > 0 && stuSistema.esquemaCronograma.IdIdi_Semestre > 0)
                    {
                        mtd_MostrarInformacionCronograma();
                        mtdMostrarMensaje("Selecionó el cronograma " + stuSistema.esquemaCronograma.Semestre);
                    }
                    else { mtdMostrarMensaje("Hubo un inconveniente al selecionar el cronograma"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmFomrularioPadre_Load(object sender, EventArgs e)
        {
            try
            {
                //Login
                EsquemaUsuario stuUsuario = new EsquemaUsuario(11, "ESLY YOEL CARBAJAL MINGOL", 12, "ADMINISTRADOR", -1, true);
                stuSistema.esquemaUsuario = stuUsuario;

                if (stuSistema.esquemaCronograma.IdIdi_Semestre == 0)
                {
                    mtd_CargarCronograma();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnSemestre_Click(object sender, EventArgs e)
        {
            try { mtd_CargarCronograma(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionTurno Formulario = new frmAdministracionTurno();
                Formulario.Show();
                Hide();
            } catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnAmbiente_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionAmbiente Formulario = new frmAdministracionAmbiente();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPersona Formulario = new frmAdministracionPersona();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPlanEstudio Formulario = new frmAdministracionPlanEstudio();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnPrerrequisito_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPrerrequisito Formulario = new frmAdministracionPrerrequisito();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnConvenio_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionConvenio Formulario = new frmAdministracionConvenio();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCargaHoraria_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionCargaHoraria Formulario = new frmAdministracionCargaHoraria();
                Formulario.Show();
                Hide();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            frmAdministracionHorario Formulario = new frmAdministracionHorario();
            Formulario.Show();
            Hide();
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            frmAdministracionDocente Formulario = new frmAdministracionDocente();
            Formulario.Show();
            Hide();
        }

        private void btnExamen_Click(object sender, EventArgs e)
        {
            frmAdministracionExamen Formulario = new frmAdministracionExamen();
            Formulario.Show();
            Hide();
        }

        private void btnPruebServicioWEB_Click(object sender, EventArgs e)
        {
            PruebaServicioWEB Formulario = new PruebaServicioWEB();
            Formulario.Show();
            Hide();
        }
    }
}
