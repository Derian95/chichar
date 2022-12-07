using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Enumerables;
using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.Individuo
{
    public partial class frmBusquedaDocente : Form
    {
        public frmBusquedaDocente() { InitializeComponent(); }

        #region DATOS ENVIADOS
        public short env_IdIdi_Docente = new short();
        #endregion

        private controller_Idi_Docente controller_Idi_Docente = new controller_Idi_Docente();
        private List<model_dto_Docente> lstDocente = new List<model_dto_Docente>();
        private List<model_dto_Docente> lstFiltroDocente = new List<model_dto_Docente>();
        //private List

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_AjustarDocentes()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvDocentes);

                List<string> lstColumnasOcultar = new List<string> { "IdEsc_TrabajadorDatosPersonales", "Estado", "Activo" };
                mtdFormatearDataGridView(dgvDocentes, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Docente = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Docente", "ID", width: 80)
                    , new customDataGridViewRow("NumeroDocumento", "DOCUMENTO", width: 100)
                    , new customDataGridViewRow("ApellidoPaterno", "A. PATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 110)
                    , new customDataGridViewRow("ApellidoMaterno", "A. MATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 110)
                    , new customDataGridViewRow("Nombres", "NOMBRES"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 190)
                };

                mtdAjustarDataGridView(dgvDocentes, lstAjuste_Docente);
                mtdSeleccionarRegistro(dgvDocentes, "IdIdi_Docente");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarDocentes()
        {
            try
            {
                Response<List<model_dto_Docente>> data_Idi_Docente = controller_Idi_Docente.fncCON_VisualListaDocente();
                if (_validarRespuesta(data_Idi_Docente))
                {
                    lstDocente = data_Idi_Docente.Data;
                    
                    dgvDocentes.DataSource = lstDocente;
                    mtd_FiltrarDocente();
                    mtd_AjustarDocentes();
                    
                } else { dgvDocentes.DataSource = null; }

                dgvDocentes.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarDocente()
        {
            try
            {
                lstFiltroDocente = lstDocente;
                lstFiltroDocente = lstDocente.Where(c =>
                        c.NumeroDocumento.Contains(txtNroDocumento.Text)
                        && c.ApellidoPaterno.ToUpper().Contains(txtApellidoPaterno.Text.ToUpper())
                        && c.ApellidoMaterno.ToUpper().Contains(txtApellidoMaterno.Text.ToUpper())
                        && c.Nombres.ToUpper().Contains(txtNombres.Text.ToUpper())
                    ).ToList();

                dgvDocentes.DataSource = lstFiltroDocente;
                dgvDocentes.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                env_IdIdi_Docente = 0;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocentes.Rows.Count > 0)
                {
                    if (dgvDocentes.SelectedRows.Count > 0)
                    {
                        env_IdIdi_Docente = Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvDocentes.CurrentRow, "IdIdi_Docente"));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvDocentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { btnSeleccionar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmBusquedaDocente_Load(object sender, EventArgs e)
        {
            try { mtd_ListarDocentes(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
