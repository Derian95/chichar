using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.Semestre
{
    public partial class frmBusquedaSemestre : Form
    {
        public frmBusquedaSemestre() { InitializeComponent(); }
        
        #region DATOS ENVIADOS
        public short env_IdIdi_Semestre = new short();
        #endregion

        private controller_Idi_Semestre controller_Idi_Semestre = new controller_Idi_Semestre();
        private List<model_dto_Semestre> lstSemestre = new List<model_dto_Semestre>();
        
        #region ========================================================= MÉTODOS =========================================================
        private void mtd_CargarAnioBusqueda()
        {
            try
            {
                List<customComboBox> lstAnio = new List<customComboBox>();
                for (int iAnio = DateTime.Now.Year; iAnio >= 2009; iAnio--) { lstAnio.Add(new customComboBox(iAnio, iAnio.ToString())); }
                mtdLlenarComboBoxManual(cmbAnio, lstAnio, contenidoDefault: "Todos...");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarSemestre()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvSemestre);

                List<string> lstColumnasOcultar = new List<string> { "Mes", "_IdSem" };
                mtdFormatearDataGridView(dgvSemestre, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Semestre = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Semestre", "ID", width: 50)
                    , new customDataGridViewRow("Anio", "AÑO", width: 80)
                    , new customDataGridViewRow("MesDescripcion", "MES", width: 100)
                    , new customDataGridViewRow("Semestre", "SEMESTRE", autoSize: true, width: 100)
                    , new customDataGridViewRow("InicioClases", "INICIO CLASES", width: 120)
                };
                mtdAjustarDataGridView(dgvSemestre, lstAjuste_Semestre);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarSemestre(short anio)
        {
            try
            {
                Response<List<model_dto_Semestre>> data_Idi_Semestre = controller_Idi_Semestre.fncCON_VisualListaSemestre(anio);
                if (_validarRespuesta(data_Idi_Semestre))
                {
                    lstSemestre = data_Idi_Semestre.Data;
                    dgvSemestre.DataSource = lstSemestre;
                    mtd_AjustarSemestre();

                    dgvSemestre.Refresh();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        #endregion



        private void cmbAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try { mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSemestre.Rows.Count > 0)
                {
                    if (dgvSemestre.SelectedRows.Count > 0)
                    {
                        env_IdIdi_Semestre = Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "IdIdi_Semestre"));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                env_IdIdi_Semestre = 0;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvSemestre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { btnSeleccionar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmBusquedaSemestre_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarAnioBusqueda();
                mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue));
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
