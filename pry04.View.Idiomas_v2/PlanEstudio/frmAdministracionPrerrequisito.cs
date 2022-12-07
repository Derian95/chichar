using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry03.Controller.Idiomas_v2;

using pry04.View.Idiomas_v2.Principal;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.PlanEstudio
{
    public partial class frmAdministracionPrerrequisito : Form
    {
        public frmAdministracionPrerrequisito() { InitializeComponent(); }

        private controller_Pta_Dependencia controller_Pta_Dependencia = new controller_Pta_Dependencia();
        private controller_Idi_PlanEstudio controller_Idi_PlanEstudio = new controller_Idi_PlanEstudio();
        private controller_Idi_Prerrequisito controller_Idi_Prerrequisito = new controller_Idi_Prerrequisito();
        private controller_Idi_Curso controller_Idi_Curso = new controller_Idi_Curso();

        private List<model_viwIdi_Dependencia> lstDependencia = new List<model_viwIdi_Dependencia>();
        private List<model_dto_PlanEstudio> lstPlanEstudio = new List<model_dto_PlanEstudio>();
        private List<model_dto_Curso_Prerrequisito> lstCursoYPrerrequisito = new List<model_dto_Curso_Prerrequisito>();

        private List<model_dto_Curso> lstCurso = new List<model_dto_Curso>();
        private List<model_dto_Curso> lstPrerrequisito = new List<model_dto_Curso>();

        private model_Idi_Prerrequisito model_Idi_Prerrequisito = new model_Idi_Prerrequisito();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_MostrarInformacionIdioma()
        {
            try
            {
                lstPlanEstudio = new List<model_dto_PlanEstudio>();
                mtd_CargarPlan(Convert.ToInt32(cmbIdioma.SelectedValue));
                lstCursoYPrerrequisito = new List<model_dto_Curso_Prerrequisito>();
                model_Idi_Prerrequisito = new model_Idi_Prerrequisito();

                dgvCursos.DataSource = null;

                cmbPlan.Enabled = lstPlanEstudio.Count > 0 ? true : false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void mtd_EstadoPanel(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnCancelar.Enabled = false;

                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;

                        break;
                }

                btnGuardar.Text = tipo == enm_G_TipoAccionMantenimiento.Modificar ? "   Modificar" : "   Guardar";
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarPrerrequisitos(short idIdi_PlanEstudio, byte ciclo, short idIdi_CursoPrerrequisito)
        {
            List<customComboBox> lstComboPrerrequisito = new List<customComboBox>();
            idIdi_CursoPrerrequisito = idIdi_CursoPrerrequisito == 0 ? Convert.ToInt16(-1) : idIdi_CursoPrerrequisito;
            try
            {
                //Cargo los cursos del plan mayores al ciclo y los muestro en el combo y lo selecciono.
                Response<List<model_dto_Curso>> data_Idi_Curso = controller_Idi_Curso.fncCON_VisualListaCurso(idIdi_PlanEstudio);

                if (_validarRespuesta(data_Idi_Curso))
                {
                    lstPrerrequisito = ciclo > 1 ?
                        data_Idi_Curso.Data.Where(c => c.IdIdi_PlanEstudio == idIdi_PlanEstudio && c.Ciclo < ciclo).ToList() :
                        new List<model_dto_Curso>();

                    cmbPrerrequisito.Enabled = true;
                    foreach (model_dto_Curso reg in lstPrerrequisito) { lstComboPrerrequisito.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_Curso), reg.Asignatura)); }
                    mtdLlenarComboBoxManual(controlComboBox: cmbPrerrequisito
                        , objComboContenido: lstComboPrerrequisito
                        , seleccionar: true
                        , valorSeleccion: Convert.ToInt64(idIdi_CursoPrerrequisito));
                }
                else
                {
                    mtdLimpiarComboBox(cmbPrerrequisito);
                    cmbPrerrequisito.Enabled = false;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosPrerrequisitoIndividual()
        {
            try
            {
                if (Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_Prerrequisito")) == 0)
                {
                    mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Nuevo);
                    model_Idi_Prerrequisito = new model_Idi_Prerrequisito(idIdi_Curso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_Curso")));
                }
                else
                {
                    model_Idi_Prerrequisito = new model_Idi_Prerrequisito(idIdi_Prerrequisito: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_Prerrequisito"))
                    , idIdi_Curso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_Curso"))
                    , idIdi_CursoPrerrequisito: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "IdIdi_CursoPrerrequisito"))
                    , idTipo: Convert.ToByte(1));
                    mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Modificar);
                }

                cmbCurso.SelectedValue = Convert.ToInt64(model_Idi_Prerrequisito.IdIdi_Curso);
                
                mtd_CargarPrerrequisitos(Convert.ToInt16(cmbPlan.SelectedValue)
                    , Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "Ciclo"))
                    , model_Idi_Prerrequisito.IdIdi_CursoPrerrequisito);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarCursos()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvCursos);

                List<string> lstColumnasOcultar = new List<string> { "Descripcion", "Observacion", "IdIdi_Curso", "IdIdi_CursoPrerrequisito", "Electivo", "Ofertado", "Orden"};
                mtdFormatearDataGridView(dgvCursos, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Curso = new List<customDataGridViewRow> {
                    new customDataGridViewRow("CodigoCurso", "CODIGO", width: 70)
                    , new customDataGridViewRow("Asignatura", "ASIGNATURA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 180)
                    , new customDataGridViewRow("Ciclo", "CICLO", width: 40)
                    , new customDataGridViewRow("HorasTeoricas", "HT", width: 30)
                    , new customDataGridViewRow("HorasPracticas", "HP", width: 30)
                    , new customDataGridViewRow("HorasLectivas", "HL", width: 30)
                    , new customDataGridViewRow("Creditos", "CRÉDITOS", width: 60)
                    , new customDataGridViewRow("EsElectivo", "¿ELECTIVO?", width: 70)
                    , new customDataGridViewRow("EsOfertado", "¿OFERTADO?", width: 80)

                    , new customDataGridViewRow("IdIdi_Prerrequisito", "ID", width: 30)
                    , new customDataGridViewRow("Pre_CodigoCurso", "CODIGO", width: 70)
                    , new customDataGridViewRow("Pre_Asignatura", "ASIGNATURA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 180)
                    , new customDataGridViewRow("Pre_Ciclo", "CICLO", width: 40)
                    , new customDataGridViewRow("Pre_HorasTeoricas", "HT", width: 30)
                    , new customDataGridViewRow("Pre_HorasPracticas", "HP", width: 30)
                    , new customDataGridViewRow("Pre_HorasLectivas", "HL", width: 30)
                    , new customDataGridViewRow("Pre_Creditos", "CRÉDITOS", width: 60)
                    , new customDataGridViewRow("Pre_Electivo", "¿ELECTIVO?", width: 70)
                    , new customDataGridViewRow("Pre_Ofertado", "¿OFERTADO?", width: 80)
                };

                mtdAjustarDataGridView(dgvCursos, lstAjuste_Curso);
                mtdSeleccionarRegistro(dgvCursos, "CodigoCurso");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarCursos(short idIdi_PlanEstudio)
        {
            List<customComboBox> lstComboCurso = new List<customComboBox>();
            try
            {
                Response<List<model_dto_Curso>> data_Idi_Curso = controller_Idi_Curso.fncCON_VisualListaCurso(idIdi_PlanEstudio);
                if (_validarRespuesta(data_Idi_Curso))
                {
                    cmbCurso.Enabled = true;
                    
                    lstCurso = data_Idi_Curso.Data;
                    foreach (model_dto_Curso reg in lstCurso) { lstComboCurso.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_Curso), reg.Asignatura)); }
                    mtdLlenarComboBoxManual(controlComboBox: cmbCurso, objComboContenido: lstComboCurso);

                    cmbCurso.Enabled = false;
                }
                else { mtdLimpiarComboBox(cmbCurso); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarCursosYPrerrequisitos(int idDependencia, short idIdi_PlanEstudio)
        {
            try
            {
                Response<List<model_dto_Curso_Prerrequisito>> data_Idi_Curso = controller_Idi_Prerrequisito.fncCON_VisualListaCurso_Y_Prerrequisito(idDependencia, idIdi_PlanEstudio);

                if (_validarRespuesta(data_Idi_Curso))
                {
                    lstCursoYPrerrequisito = data_Idi_Curso.Data;
                    dgvCursos.DataSource = lstCursoYPrerrequisito;
                    mtd_AjustarCursos();
                }
                else { dgvCursos.DataSource = null; }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarPlan(int idDepe)
        {
            List<customComboBox> lstComboPlan = new List<customComboBox>();
            try
            {
                Response<List<model_dto_PlanEstudio>> data_IdiPlan = controller_Idi_PlanEstudio.fncCON_VisualListaPlanEstudio(idDepe);
                if (_validarRespuesta(data_IdiPlan))
                {
                    lstPlanEstudio = data_IdiPlan.Data;
                    foreach (model_dto_PlanEstudio reg in lstPlanEstudio)
                    {
                        lstComboPlan.Add(
                            new customComboBox(Convert.ToInt64(reg.IdIdi_PlanEstudio)
                            , reg.IdIdi_PlanEstudio
                                + " - " + reg.Semestre
                                + " - " + reg.Item)
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
        #endregion

        #region ======================================================== FUNCIONES ========================================================
        public bool fncValidarPrerrequisito()
        {
            try
            {
                if (Convert.ToInt16(cmbCurso.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Es necesario seleccionar un curso");
                    return false;
                }
                else
                {
                    if (dgvCursos.Rows.Count <= 0 || dgvCursos.SelectedRows.Count <= 0)
                    {
                        mtdMostrarMensaje("No se encontro información para registrar");
                        return false;
                    }
                    else
                    {
                        if (Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursos.CurrentRow, "Ciclo")) <= 1)
                        {
                            mtdMostrarMensaje("El curso seleccionado no puede tener prerrequisito por ser de primer ciclo");
                            return false;
                        }
                        else
                        {
                            if (Convert.ToInt64(cmbPrerrequisito.SelectedValue) == -1)
                            {
                                mtdMostrarMensaje("Es necesario seleccionar un prerrequisito");
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }
        #endregion

        private void frmAdministracionRequisitos_Load(object sender, EventArgs e)
        {
            try { mtd_CargarIdioma(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void cmbIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (lstCursoYPrerrequisito.Count > 0)
                {
                    if (MessageBox.Show("Está por listar los planes de un idioma nuevo, ¿seguro que desea continuar?, los cambios sin guardar se perderán"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    { mtd_MostrarInformacionIdioma(); }
                }
                else { mtd_MostrarInformacionIdioma(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbPlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(cmbPlan.SelectedValue) > 0)
                {
                    mtd_ListarCursosYPrerrequisitos(Convert.ToInt32(cmbIdioma.SelectedValue), Convert.ToInt16(cmbPlan.SelectedValue));
                    mtd_CargarCursos(Convert.ToInt16(cmbPlan.SelectedValue));

                    if (dgvCursos.Rows.Count > 0 && dgvCursos.SelectedRows.Count > 0)
                    {
                        mtd_ObtenerDatosPrerrequisitoIndividual();
                        mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Modificar);
                    }
                    else { mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Nuevo); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { if (dgvCursos.Rows.Count > 0 && dgvCursos.SelectedRows.Count > 0) { mtd_ObtenerDatosPrerrequisitoIndividual(); } }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Prerrequisito = new model_Idi_Prerrequisito();
                cmbPrerrequisito.Enabled = true;
                
                mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (model_Idi_Prerrequisito.IdIdi_Prerrequisito == 0)
                {
                    model_Idi_Prerrequisito = new model_Idi_Prerrequisito();
                    cmbPrerrequisito.Enabled = false;
                }
                else
                {
                    cmbPrerrequisito.Enabled = true;
                    mtd_ObtenerDatosPrerrequisitoIndividual();
                }

                mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Cancelar);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarPrerrequisito())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                       , Constantes.TextoMessageBoxQuestion
                       , MessageBoxButtons.YesNo
                       , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        model_Idi_Prerrequisito.IdIdi_Curso = Convert.ToInt16(cmbCurso.SelectedValue);
                        model_Idi_Prerrequisito.IdIdi_CursoPrerrequisito = Convert.ToInt16(cmbPrerrequisito.SelectedValue);

                        if (model_Idi_Prerrequisito.IdIdi_Prerrequisito == 0)
                        {
                            Response<EsquemaRespuestaRegistro> registroIdi_Prerrequisito = controller_Idi_Prerrequisito.fncCON_RegistrarPrerrequisito(model_Idi_Prerrequisito);

                            if (!registroIdi_Prerrequisito.Success)
                            {
                                mtdMostrarMensaje(registroIdi_Prerrequisito.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            Response<bool> actualizacionIdi_Prerrequisito = controller_Idi_Prerrequisito.fncCON_ModificarPrerrequisito(model_Idi_Prerrequisito);

                            if (!actualizacionIdi_Prerrequisito.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_Prerrequisito.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        
                        mtd_ListarCursosYPrerrequisitos(Convert.ToInt32(cmbIdioma.SelectedValue), Convert.ToInt16(cmbPlan.SelectedValue));
                        mtd_CargarCursos(Convert.ToInt16(cmbPlan.SelectedValue));

                        if (dgvCursos.Rows.Count > 0 && dgvCursos.SelectedRows.Count > 0) { mtd_ObtenerDatosPrerrequisitoIndividual(); }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionRequisitos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmFormularioPadre FrmPadre = new frmFormularioPadre();
                FrmPadre.Show();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
