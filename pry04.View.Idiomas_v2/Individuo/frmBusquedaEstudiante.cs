using System;
using System.Collections.Generic;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Procedimiento;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Enumerables;
using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;

namespace pry04.View.Idiomas_v2.Individuo
{
    public partial class frmBusquedaEstudiante : Form
    {
        public frmBusquedaEstudiante() { InitializeComponent(); }

        #region DATOS ENVIADOS
        public int env_CodigoUniversitario = new int();
        #endregion

        private controller_ESTUDIANTE controller_ESTUDIANTE = new controller_ESTUDIANTE();
        private List<model_Usp_Idi_S_ListarEstudianteParaIdiomas> lstEstudiante = new List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_AjustarEstudiantes()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvEstudiantes);

                List<string> lstColumnasOcultar = new List<string> { "ItemEst", "iddepe", "CodEstamento", "FechIngreso", "Activo", "Observ"
                    , "Usuario", "Fecha", "ModIngreso", "IdPtaDependenciaFijo", "Estamento" };
                mtdFormatearDataGridView(dgvEstudiantes, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Estudiante = new List<customDataGridViewRow> {
                    new customDataGridViewRow("CodPer", "ID", width: 60)
                    , new customDataGridViewRow("DniPer", "DOC.", width: 80)
                    , new customDataGridViewRow("NombreCompleto", "NOMBRE"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 280)
                    , new customDataGridViewRow("CodUniv", "CÓDIGO", width: 80)
                    , new customDataGridViewRow("Descripcion", "IDIOMA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , width: 200)
                };

                mtdAjustarDataGridView(dgvEstudiantes, lstAjuste_Estudiante);
                mtdSeleccionarRegistro(dgvEstudiantes, "CodPer");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void mtd_ListarEstudiantes()
        {
            try
            {
                Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> data_ESTUDIANTE = controller_ESTUDIANTE.fncCON_RelacionEstudiantes(
                    codigoUniversitario: txtCodUniv.Text.Trim() == "" ?
                        -1 :
                        Convert.ToInt32(_obtenerEntero(txtCodUniv.Text))
                    , numeroDocumento: txtNroDocumento.Text
                    , apellidoPaterno: txtApellidoPaterno.Text
                    , apellidoMaterno: txtApellidoMaterno.Text
                    , nombres: txtNombres.Text);
                if (_validarRespuesta(data_ESTUDIANTE))
                {
                    lstEstudiante = data_ESTUDIANTE.Data;

                    dgvEstudiantes.DataSource = lstEstudiante;
                    //Al ajustar, como el grid aun no se ve por el showdialog, no puede formatear, creo
                    mtd_AjustarEstudiantes();
                } else { dgvEstudiantes.DataSource = null; }

                dgvEstudiantes.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion ========================================================================================================================

        #region ======================================================== FUNCIONES ========================================================
        #endregion ========================================================================================================================
        
        private void dgvEstudiantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { btnSeleccionar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { mtd_ListarEstudiantes(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            env_CodigoUniversitario = 0;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstudiantes.Rows.Count > 0)
                {
                    if (dgvEstudiantes.SelectedRows.Count > 0)
                    {
                        env_CodigoUniversitario = Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvEstudiantes.CurrentRow, "CodUniv"));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
