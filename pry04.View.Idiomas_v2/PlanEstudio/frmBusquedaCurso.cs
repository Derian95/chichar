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


namespace pry04.View.Idiomas_v2.PlanEstudio
{
    public partial class frmBusquedaCurso : Form
    {
        public frmBusquedaCurso() { InitializeComponent(); }

        #region DATOS ENVIADOS
        public short env_IdIdi_Curso = new short();
        #endregion

        private controller_Idi_Curso controller_Idi_Curso = new controller_Idi_Curso();
        private controller_Pta_Dependencia controller_Pta_Dependencia = new controller_Pta_Dependencia();
        private controller_Idi_PlanEstudio controller_Idi_PlanEstudio = new controller_Idi_PlanEstudio();

        private List<model_dto_Curso> lstCurso = new List<model_dto_Curso>();
        private List<model_dto_Curso> lstFiltroCurso = new List<model_dto_Curso>();
        private List<model_viwIdi_Dependencia> lstDependencia = new List<model_viwIdi_Dependencia>();
        private List<model_dto_PlanEstudio> lstPlan = new List<model_dto_PlanEstudio>();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_CargarPlan(int idDepe)
        {
            dgvCursos.DataSource = null;
            lstCurso = new List<model_dto_Curso>();

            List<customComboBox> lstComboPlan = new List<customComboBox>();
            try
            {
                Response<List<model_dto_PlanEstudio>> data_Idi_Plan = controller_Idi_PlanEstudio.fncCON_VisualListaPlanEstudio(idDepe);

                if (_validarRespuesta(data_Idi_Plan))
                {
                    cmbPlan.Enabled = true;
                    lstPlan = data_Idi_Plan.Data;
                    foreach (model_dto_PlanEstudio reg in lstPlan)
                    {
                        lstComboPlan.Add(new customComboBox(
                            Convert.ToInt64(reg.IdIdi_PlanEstudio)
                            , reg.IdIdi_PlanEstudio + " - " + reg.Semestre + " - " + reg.Item)
                        );
                    }

                    mtdLlenarComboBoxManual(controlComboBox: cmbPlan, objComboContenido: lstComboPlan);
                }
                else { mtdLimpiarComboBox(cmbPlan); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarIdioma()
        {
            List<customComboBox> lstComboIdioma = new List<customComboBox>();
            try
            {
                Response<List<model_viwIdi_Dependencia>> data_Pta_Dependencia = controller_Pta_Dependencia.fncCON_ListaIdioma();

                if (_validarRespuesta(data_Pta_Dependencia))
                {
                    lstDependencia = data_Pta_Dependencia.Data;
                    foreach (model_viwIdi_Dependencia reg in lstDependencia) { lstComboIdioma.Add(new customComboBox(Convert.ToInt64(reg.IdDependencia), reg.Descripcion)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbIdioma, objComboContenido: lstComboIdioma);
                }
                else { mtdLimpiarComboBox(cmbIdioma); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarCursos(short idIdi_PlanEstudio)
        {
            dgvCursos.DataSource = null;
            lstCurso = new List<model_dto_Curso>();

            try
            {
                Response<List<model_dto_Curso>> data_Idi_Curso = controller_Idi_Curso.fncCON_VisualListaCurso(idIdi_PlanEstudio);

                if (_validarRespuesta(data_Idi_Curso))
                {
                    lstCurso = data_Idi_Curso.Data;
                    dgvCursos.DataSource = lstCurso;
                    mtd_FiltrarCursos();
                    mtd_AjustarCursos();
                }
                else { dgvCursos.DataSource = null; }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarCursos()
        {
            try
            {
                lstFiltroCurso = lstCurso;
                lstFiltroCurso = lstCurso.Where(c => c.Asignatura.ToUpper().Contains(txtAsignatura.Text.ToUpper())).ToList();

                dgvCursos.DataSource = lstFiltroCurso;

                dgvCursos.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarCursos()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvCursos);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_PlanEstudio", "IdIdi_NivelCurso", "IdIdi_TipoCurso", "Activo", "Estado"
                    , "Electivo", "Ofertado", "UsuarioCreacion", "FechaCreacion", "_IdCurso", "_PreReq", "_IdNivel", "_IdTipoCurso", "_auxiliarEmpadronamiento" };
                mtdFormatearDataGridView(dgvCursos, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_PlanEstudio = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Curso", "ID", width: 60)
                    , new customDataGridViewRow("CodigoCurso", "COD.", width: 80)
                    , new customDataGridViewRow("Asignatura", "ASIGNATURA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 180)
                    , new customDataGridViewRow("Ciclo", "CICLO", width: 70)
                    , new customDataGridViewRow("HorasTeoricas", "HT", width: 40)
                    , new customDataGridViewRow("HorasPracticas", "HP", width: 40)
                    , new customDataGridViewRow("HorasLectivas", "HL", width: 40)
                    , new customDataGridViewRow("Creditos", "CRÉDITOS", width: 80)
                    , new customDataGridViewRow("esElectivo", "¿ELECTIVO?", width: 100)
                    , new customDataGridViewRow("Orden", "ORDEN", width: 60)
                    , new customDataGridViewRow("esOfertado", "¿OFERTADO?", width: 100)
                };

                mtdAjustarDataGridView(dgvCursos, lstAjuste_PlanEstudio);
                mtdSeleccionarRegistro(dgvCursos, "IdIdi_Curso");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        #endregion

        #region ======================================================== FUNCIONES ========================================================
        #endregion

        private void frmBusquedaCurso_Load(object sender, EventArgs e)
        {
            try { mtd_CargarIdioma(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try { mtd_CargarPlan(Convert.ToInt32(cmbIdioma.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { mtd_ListarCursos(Convert.ToInt16(cmbPlan.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                env_IdIdi_Curso = 0;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCursos.Rows.Count > 0)
                {
                    if (dgvCursos.SelectedRows.Count > 0)
                    {
                        env_IdIdi_Curso = Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_Curso"));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbPlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try { mtd_ListarCursos(Convert.ToInt16(cmbPlan.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtAsignatura_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarCursos(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { btnSeleccionar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
