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
    public partial class frmAdministracionPlanEstudio : Form
    {
        public frmAdministracionPlanEstudio() { InitializeComponent(); }

        //Para eliminar un curso de la grilla, primero preguntar, tiene ID, hacer en un menú contextual
        //Si -> poner estado = 0, activo = false
        //No -> eliminar el registro de la lista
        private enum _enmTipoModificacionCurso
        {
            Default,
            Restaurando,
            Asignando,
            ModificandoControl
        }

        private _enmTipoModificacionCurso enmEstadoCurso = new _enmTipoModificacionCurso();

        private controller_Pta_Dependencia controller_Pta_Dependencia = new controller_Pta_Dependencia();
        private controller_Idi_Semestre controller_Idi_Semestre = new controller_Idi_Semestre();
        private controller_Idi_PlanEstudio controller_Idi_PlanEstudio = new controller_Idi_PlanEstudio();
        private controller_Idi_Curso controller_Idi_Curso = new controller_Idi_Curso();

        private controller_Idi_NivelCurso controller_Idi_NivelCurso = new controller_Idi_NivelCurso();
        private controller_Idi_TipoCurso controller_Idi_TipoCurso = new controller_Idi_TipoCurso();

        //private model_Idi_Curso model_Idi_Curso = new model_Idi_Curso();
        private model_dto_Curso model_dto_Curso = new model_dto_Curso();
        private model_Idi_PlanEstudio model_Idi_PlanEstudio = new model_Idi_PlanEstudio();
        
        private List<model_viwIdi_Dependencia> lstDependencia = new List<model_viwIdi_Dependencia>();
        private List<model_dto_Semestre> lstSemestre = new List<model_dto_Semestre>();
        private List<model_dto_PlanEstudio> lstPlanEstudio = new List<model_dto_PlanEstudio>();
        private List<model_dto_Curso> lstCurso = new List<model_dto_Curso>();
        //private List<model_Idi_Curso> lstCurso = new List<model_Idi_Curso>();

        private List<model_Idi_NivelCurso> lstNivelCurso = new List<model_Idi_NivelCurso>();
        private List<model_dto_TipoCurso> lstTipoCurso = new List<model_dto_TipoCurso>();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                enmEstadoCurso = _enmTipoModificacionCurso.Restaurando;
                txtCodigo.Text = "";
                txtNombre.Text = "";
                cmbTipoCurso.SelectedValue = Convert.ToInt64(-1); 
                cmbNivelCurso.SelectedValue = Convert.ToInt64(-1);
                nudCiclo.Value = 0;
                nudCreditos.Value = 0;
                nudHT.Value = 0;
                nudHP.Value = 0;
                nudHL.Value = 0;
                chkElectivo.Checked = false;
                chkOfertado.Checked = false;

                mtd_EstadoPanelCurso(tipo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                cmbPlanAnterior.Enabled = lstPlanEstudio.Count > 0 ? true: false;

                txtPlan.Text = "";
                cmbSemestre.SelectedValue = Convert.ToInt64(-1);
                txtObservacion.Text = "";
                dtpFecha.Value = DateTime.Now;
                chkActivo.Checked = false;

                mtd_EstadoPanelPlan(tipo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarCursosPlan()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvCursosPlan);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_PlanEstudio", "IdIdi_NivelCurso", "IdIdi_TipoCurso", "Activo", "Estado"
                    , "Electivo", "Ofertado", "UsuarioCreacion", "FechaCreacion", "_IdCurso", "_PreReq", "_IdNivel", "_IdTipoCurso", "_auxiliarEmpadronamiento" };
                mtdFormatearDataGridView(dgvCursosPlan, lstColumnasOcultar);

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
                    , new customDataGridViewRow("esOfertado", "¿OFERTADO?", width: 100)
                    , new customDataGridViewRow("Orden", "ORDEN", width: 60)
                };

                mtdAjustarDataGridView(dgvCursosPlan, lstAjuste_PlanEstudio);
                mtdSeleccionarRegistro(dgvCursosPlan, "IdIdi_Curso");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        public void mtd_ObtenerDatosCursoIndividual()
        {
            try
            {
                model_dto_Curso = new model_dto_Curso(idIdi_Curso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "IdIdi_Curso"))
                    , idIdi_PlanEstudio: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "IdIdi_PlanEstudio"))
                    , idIdi_NivelCurso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "IdIdi_NivelCurso"))
                    , idIdi_TipoCurso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "IdIdi_TipoCurso"))
                    , codigoCurso: mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "CodigoCurso").ToString()
                    , asignatura: mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Asignatura").ToString()
                    , ciclo: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Ciclo"))
                    , horasTeoricas: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "HorasTeoricas"))
                    , horasPracticas: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "HorasPracticas"))
                    , horasLectivas: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "HorasLectivas"))
                    , creditos: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Creditos"))
                    , electivo: Convert.ToBoolean(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Electivo"))
                    , esElectivo: mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "esElectivo").ToString()
                    , orden: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Orden"))
                    , ofertado: Convert.ToBoolean(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Ofertado"))
                    , esOfertado: mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "esOfertado").ToString()
                    , estado: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Estado"))
                    , activo: Convert.ToBoolean(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "Activo"))
                    , usuarioCreacion: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "UsuarioCreacion"))
                    , fechaCreacion: Convert.ToDateTime(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "FechaCreacion"))
                    , idCurso: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "_Idcurso"))
                    , preReq: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "_PreReq"))
                    , idNivel: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "_IdNivel"))
                    , idTipoCurso: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "_IdTipoCurso"))
                    , auxiliarEmpadronamiento: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvCursosPlan.CurrentRow, "_auxiliarEmpadronamiento"))
                );

                enmEstadoCurso = _enmTipoModificacionCurso.Asignando;
                txtCodigo.Text = model_dto_Curso.CodigoCurso;
                txtNombre.Text = model_dto_Curso.Asignatura;
                cmbNivelCurso.SelectedValue = Convert.ToInt64(model_dto_Curso.IdIdi_NivelCurso);
                cmbTipoCurso.SelectedValue = Convert.ToInt64(model_dto_Curso.IdIdi_TipoCurso);
                nudCiclo.Value = model_dto_Curso.Ciclo;
                nudCreditos.Value = model_dto_Curso.Creditos;
                nudHT.Value = model_dto_Curso.HorasTeoricas;
                nudHP.Value = model_dto_Curso.HorasPracticas;
                nudHL.Value = model_dto_Curso.HorasLectivas;
                nudOrden.Value = model_dto_Curso.Orden;

                chkElectivo.Checked = model_dto_Curso.Electivo ? true : false;
                chkOfertado.Checked = model_dto_Curso.Ofertado ? true : false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosPlanIndividual()
        {
            try
            {
                if (dgvPlan.Rows.Count > 0)
                {
                    if (dgvPlan.SelectedRows.Count > 0)
                    {
                        mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento.Modificar);

                        short _IdIdi_PlanEstudio = Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvPlan.CurrentRow, "IdIdi_PlanEstudio"));

                        Response<model_Idi_PlanEstudio> _model_Idi_PlanEstudio = controller_Idi_PlanEstudio.fncCON_ListaPlanEstudioIndividualCompleto(_IdIdi_PlanEstudio);

                        if (_validarRespuesta(_model_Idi_PlanEstudio))
                        {
                            model_Idi_PlanEstudio = _model_Idi_PlanEstudio.Data;

                            txtPlan.Text = model_Idi_PlanEstudio.IdIdi_PlanEstudio
                                + " - " + model_Idi_PlanEstudio.Semestre
                                + " - " + model_Idi_PlanEstudio.Item;
                            txtObservacion.Text = model_Idi_PlanEstudio.Observacion;
                            dtpFecha.Value = model_Idi_PlanEstudio.Fecha;
                            chkActivo.Checked = model_Idi_PlanEstudio.Activo;

                            mtd_CargarPlanAnterior();

                            if (model_Idi_PlanEstudio.IdIdi_PlanEstudioPadre > 0) { cmbPlanAnterior.SelectedValue = Convert.ToInt64(model_Idi_PlanEstudio.IdIdi_PlanEstudioPadre); }
                            if (model_Idi_PlanEstudio.Semestre != "")
                            {
                                cmbSemestre.SelectedValue
                                    = Convert.ToInt64(
                                        lstSemestre
                                        .Where(c => c.Semestre == model_Idi_PlanEstudio.Semestre)
                                        .Select(c => c.IdIdi_Semestre)
                                        .Take(1)
                                        .SingleOrDefault()
                                    );
                            }

                            //Averiguar xq KRJOS tengo que reiniciar el controller para consultar data actualizada a pesar de que está en la base de datos
                            //controller_Idi_Curso = new controller_Idi_Curso();
                            Response<List<model_dto_Curso>> data_Idi_Curso = controller_Idi_Curso.fncCON_VisualListaCurso(model_Idi_PlanEstudio.IdIdi_PlanEstudio);                            

                            if (_validarRespuesta(data_Idi_Curso))
                            {
                                lstCurso = data_Idi_Curso.Data;
                                dgvCursosPlan.DataSource = lstCurso;
                                mtd_AjustarCursosPlan();
                            }
                            else
                            {
                                lstCurso = new List<model_dto_Curso>();
                                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno);
                            }
                        }
                    }
                    else
                    {
                        model_Idi_PlanEstudio = new model_Idi_PlanEstudio();
                        mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento.Nuevo);
                        lstCurso = new List<model_dto_Curso>();
                        dgvCursosPlan.DataSource = null;
                    }
                }
                else
                {
                    model_Idi_PlanEstudio = new model_Idi_PlanEstudio();
                    mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento.Nuevo);
                    lstCurso = new List<model_dto_Curso>();
                    dgvCursosPlan.DataSource = null;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_EstadoPanelPlan(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                        pnlAdminsitracionCurso.Enabled = false;
                        cmbSemestre.Enabled = false;
                        txtObservacion.Enabled = false;
                        dtpFecha.Enabled = false;
                        chkActivo.Enabled = false;

                        btnNuevoPlan.Enabled = true;
                        btnGuardarPlan.Enabled = false;
                        btnCancelarPlan.Enabled = false;

                        btnGuardarPlan.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                        pnlAdminsitracionCurso.Enabled = true; 
                        
                        cmbSemestre.Enabled = true;
                        txtObservacion.Enabled = true;
                        dtpFecha.Enabled = true;
                        chkActivo.Enabled = true;

                        btnNuevoPlan.Enabled = false;
                        btnGuardarPlan.Enabled = true;
                        btnCancelarPlan.Enabled = true;

                        btnGuardarPlan.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        pnlAdminsitracionCurso.Enabled = false; 
                        
                        cmbSemestre.Enabled = true; 
                        txtObservacion.Enabled = true;
                        dtpFecha.Enabled = true;
                        chkActivo.Enabled = true;

                        btnNuevoPlan.Enabled = true;
                        btnGuardarPlan.Enabled = false;
                        btnCancelarPlan.Enabled = false;

                        btnGuardarPlan.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        pnlAdminsitracionCurso.Enabled = true; 
                        
                        cmbSemestre.Enabled = true;
                        txtObservacion.Enabled = true;
                        dtpFecha.Enabled = true;
                        chkActivo.Enabled = true;

                        btnNuevoPlan.Enabled = false;
                        btnGuardarPlan.Enabled = true;
                        btnCancelarPlan.Enabled = true;

                        btnGuardarPlan.Text = "   Modificar";
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_EstadoPanelCurso(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                pnlCurso.Enabled = true;
                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        btnNuevoCurso.Enabled = true;
                        btnAgregarCurso.Enabled = false;
                        btnCancelarCurso.Enabled = false;

                        btnAgregarCurso.Text = "   Agregar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        btnNuevoCurso.Enabled = false;
                        btnAgregarCurso.Enabled = true;
                        btnCancelarCurso.Enabled = true;

                        btnAgregarCurso.Text = tipo == enm_G_TipoAccionMantenimiento.Nuevo ? "   Agregar" : "   Cambiar";
                        break;
                }
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

        private void mtd_CargarSemestre()
        {
            List<customComboBox> lstComboSemestre = new List<customComboBox>();
            try
            {
                Response<List<model_dto_Semestre>> data_Idi_Semestre = controller_Idi_Semestre.fncCON_VisualListaSemestre(-1);

                if (_validarRespuesta(data_Idi_Semestre))
                {
                    cmbSemestre.Enabled = true;
                    lstSemestre = data_Idi_Semestre.Data;
                    foreach (model_dto_Semestre reg in lstSemestre) { lstComboSemestre.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_Semestre), reg.Semestre)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbSemestre, objComboContenido: lstComboSemestre);
                }
                else
                {
                    cmbSemestre.Enabled = false; 
                    mtdLimpiarComboBox(cmbSemestre);
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarNivelCurso()
        {
            List<customComboBox> lstComboNivelCurso = new List<customComboBox>();
            try
            {
                Response<List<model_Idi_NivelCurso>> data_Idi_NivelCurso = controller_Idi_NivelCurso.fncCON_ListaNivelCurso();
                if (_validarRespuesta(data_Idi_NivelCurso))
                {
                    lstNivelCurso = data_Idi_NivelCurso.Data;
                    foreach (model_Idi_NivelCurso reg in lstNivelCurso)
                    { lstComboNivelCurso.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_NivelCurso), reg.Nombre)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbNivelCurso, objComboContenido: lstComboNivelCurso);
                }
                else { mtdLimpiarComboBox(cmbNivelCurso); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarTipoCurso()
        {
            List<customComboBox> lstComboTipoCurso = new List<customComboBox>();
            try
            {
                Response<List<model_dto_TipoCurso>> data_Idi_TipoCurso = controller_Idi_TipoCurso.fncCON_ListaTipoCurso();
                if (_validarRespuesta(data_Idi_TipoCurso))
                {
                    lstTipoCurso = data_Idi_TipoCurso.Data;
                    foreach (model_dto_TipoCurso reg in lstTipoCurso)
                    { lstComboTipoCurso.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_TipoCurso), reg.Nombre)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbTipoCurso, objComboContenido: lstComboTipoCurso);
                }
                else { mtdLimpiarComboBox(cmbTipoCurso); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarPlanAnterior()
        {
            List<customComboBox> lstComboPlanAnterior = new List<customComboBox>();
            List<model_dto_PlanEstudio> lstPlanAnterior 
                = lstPlanEstudio.Where(c => c.IdIdi_PlanEstudio != model_Idi_PlanEstudio.IdIdi_PlanEstudio).ToList();
            try
            {
                if (lstPlanAnterior.Count > 0)
                {
                    cmbPlanAnterior.Enabled = true;
                    foreach (model_dto_PlanEstudio reg in lstPlanAnterior)
                    {
                        lstComboPlanAnterior.Add(
                            new customComboBox(Convert.ToInt64(reg.IdIdi_PlanEstudio)
                            , reg.IdIdi_PlanEstudio
                                + " - " + reg.Semestre
                                + " - " + reg.Item)
                        );
                    }
                    mtdLlenarComboBoxManual(controlComboBox: cmbPlanAnterior, objComboContenido: lstComboPlanAnterior);
                }
                else
                {
                    mtdLimpiarComboBox(cmbPlanAnterior);
                    cmbPlanAnterior.Enabled = false;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarPlanes(int idDepe)
        {
            try
            {
                Response<List<model_dto_PlanEstudio>> data_Idi_Plan = controller_Idi_PlanEstudio.fncCON_VisualListaPlanEstudio(idDepe);
                if (_validarRespuesta(data_Idi_Plan))
                {
                    lstPlanEstudio = data_Idi_Plan.Data;
                    dgvPlan.DataSource = lstPlanEstudio;
                    mtd_AjustarPlan();
                }
                else { dgvPlan.DataSource = null; }

                dgvPlan.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarPlan()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvPlan);

                List<string> lstColumnasOcultar = new List<string> { "IdDepe", "IdPtaDependenciaFijo", "Observacion", "IdIdi_PlanEstudioPadre", "_IdPe", "IdDependencia"
                , "Estado", "Activo", "UsuarioCreacion", "FechaCreacion" };
                mtdFormatearDataGridView(dgvPlan, lstColumnasOcultar);

                List<string> lstColumnasFecha = new List<string> { "Fecha" };
                mtdFormatearDataGridView(dgvPlan, lstColumnasFecha, enm_G_TipoFormatoDataGridView.Fecha);

                List<customDataGridViewRow> lstAjuste_PlanEstudio = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_PlanEstudio", "ID", width: 60)
                    , new customDataGridViewRow("Idioma", "IDIOMA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 180)
                    , new customDataGridViewRow("Semestre", "SEMESTRE", width: 100)
                    , new customDataGridViewRow("Fecha", "FECHA", width: 100)
                    , new customDataGridViewRow("Item", "NÚMERO", width: 60)
                    , new customDataGridViewRow("EsActivo", "ACTIVO", width: 60)
                };

                mtdAjustarDataGridView(dgvPlan, lstAjuste_PlanEstudio);
                mtdSeleccionarRegistro(dgvPlan, "IdIdi_PlanEstudio");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion



        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarOrdenTotalCursos()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }


        private enm_G_TipoAccionMantenimiento fncTipoMovimientoCurso(model_dto_Curso _target)
        {
            try
            {
                return _target.IdIdi_Curso > 0 || _target._auxiliarEmpadronamiento > 0 ?
                    enm_G_TipoAccionMantenimiento.Modificar :
                    enm_G_TipoAccionMantenimiento.Nuevo;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return enm_G_TipoAccionMantenimiento.Ninguno;
            }
        }

        public string fncGenerarCodigoCurso()
        {
            //2 caracteres del nombre
            //-
            //numero ciclo
            //numero plan
            //numero orden cursos en ese ciclo
            try
            {
                switch (enmEstadoCurso)
                {
                    case _enmTipoModificacionCurso.Restaurando:
                        return "";
                    case _enmTipoModificacionCurso.Asignando:
                        return model_dto_Curso.CodigoCurso;
                    default:
                        return txtNombre.Text.Trim().Length <= 2 ? string.Empty : txtNombre.Text.Substring(0, 2) +
                            "-" + _obtenerEntero(nudCiclo.Value) + (
                                lstPlanEstudio.Count == 0 ?
                                    "1" :
                                    model_Idi_PlanEstudio.IdIdi_PlanEstudio == 0 ? (
                                            (lstPlanEstudio.Max(c => c.Item as byte?) ?? 0) + 1
                                        ).ToString() :
                                        model_Idi_PlanEstudio.Item.ToString()
                            ) + nudOrden.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return "";
            }
        }
        public bool fncValidarCurso()
        {
            try
            {
                if (!fncValidarOrdenTotalCursos())
                {
                    mtdMostrarMensaje("Debe especificar correctamente el orden de los cursos en todo el plan de estudio");
                    return false;
                }

                if (txtNombre.Text.Trim() == "")
                {
                    mtdMostrarMensaje("Ingrese el nombre de la asignatura");
                    return false;
                }

                if (nudCiclo.Value <= 0)
                {
                    mtdMostrarMensaje("Ingrese correctamente el ciclo");
                    return false;
                }

                if (nudOrden.Value <= 0)
                {
                    mtdMostrarMensaje("Ingrese correctamente el orden del curso en cuestión");
                    return false;
                }

                if (nudCreditos.Value <= 0)
                {
                    mtdMostrarMensaje("Ingrese correctamente los créditos");
                    return false;
                }

                if (Convert.ToInt64(cmbNivelCurso.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Deberá seleccionar un nivel para el curso");
                    return false;
                }
                
                if (Convert.ToInt64(cmbTipoCurso.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("El curso debe tener un tipo seleccionado");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }

        public bool fncValidarPlan()
        {
            try
            {
                if (lstPlanEstudio.Count > 0)
                {
                    if (Convert.ToInt64(cmbPlanAnterior.SelectedValue) == -1)
                    {
                        mtdMostrarMensaje("Debe seleccionar el plan que antecede al que creará");
                        return false;
                    }
                }

                if (Convert.ToInt64(cmbSemestre.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Es necesario seleccionar un semestre para el plan en cuestión");
                    return false;
                }

                if (dgvCursosPlan.Rows.Count <= 0)
                {
                    mtdMostrarMensaje("Debe agregar cursos para el plan de estudio que desea crear");
                    return false;
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



        private void frmAdministrarPlanEstudio_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarIdioma();
                mtd_CargarSemestre();
                mtd_CargarNivelCurso();
                mtd_CargarTipoCurso();

                pnlCurso.Enabled = false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Ver
            try
            {
                mtd_ListarPlanes(Convert.ToInt32(cmbIdioma.SelectedValue));

                mtd_ObtenerDatosPlanIndividual();
                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ver
            try
            {
                mtd_ObtenerDatosPlanIndividual();
                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCursosPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ver
            try
            {
                if (dgvCursosPlan.Rows.Count > 0)
                {
                    if (dgvCursosPlan.SelectedRows.Count > 0)
                    {
                        mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Modificar);
                        mtd_ObtenerDatosCursoIndividual();
                        enmEstadoCurso = _enmTipoModificacionCurso.ModificandoControl;
                    }
                    else { mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno); }
                }
                else { mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevoCurso_Click(object sender, EventArgs e)
        {
            //Ver
            try
            {
                model_dto_Curso = new model_dto_Curso();
                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Nuevo);
                enmEstadoCurso = _enmTipoModificacionCurso.ModificandoControl;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            //Ver
            try
            {
                model_dto_Curso = new model_dto_Curso();
                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Cancelar);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            //Ver
            try
            {
                model_Idi_PlanEstudio = new model_Idi_PlanEstudio();
                model_dto_Curso = new model_dto_Curso();
                mtd_CargarPlanAnterior();
                mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento.Nuevo);
                mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Nuevo);
                enmEstadoCurso = _enmTipoModificacionCurso.ModificandoControl;

                lstCurso = new List<model_dto_Curso>();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardarPlan_Click(object sender, EventArgs e)
        {
            int idPtaDependenciaFijo = new int();
            int index = -1;
            try
            {
                if (fncValidarPlan())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Response<List<model_viwIdi_Dependencia>> data_Idi_Dependencia = controller_Pta_Dependencia.fncCON_ListaIdioma(Convert.ToInt32(cmbIdioma.SelectedValue));
                        if (_validarRespuesta(data_Idi_Dependencia)) { idPtaDependenciaFijo = data_Idi_Dependencia.Data[0].IdPtaDependenciaFijo; }

                        model_Idi_PlanEstudio.IdDependencia = Convert.ToInt32(cmbIdioma.SelectedValue);
                        model_Idi_PlanEstudio.IdPtaDependenciaFijo = idPtaDependenciaFijo;
                        model_Idi_PlanEstudio.Fecha = dtpFecha.Value;
                        model_Idi_PlanEstudio.Semestre = cmbSemestre.Text.ToString();
                        model_Idi_PlanEstudio.Observacion = txtObservacion.Text;
                        
                        model_Idi_PlanEstudio.Item = 
                            model_Idi_PlanEstudio.IdIdi_PlanEstudio > 0 ?
                                model_Idi_PlanEstudio.Item :
                                Convert.ToByte(
                                    (lstPlanEstudio.Max(c => c.Item as byte ?) ?? 0) + 1
                                );
                        
                        model_Idi_PlanEstudio.IdIdi_PlanEstudioPadre =
                            lstPlanEstudio.Count == 0 ?
                                Convert.ToInt16(0) :
                                Convert.ToInt16(cmbPlanAnterior.SelectedValue);
                        model_Idi_PlanEstudio.Activo = chkActivo.Checked;

                        //Verificar los datos cuando se registra y actualiza, xq se pasa de DTO a IDI y no siempre pasa datos de estado, activo, usuario registro, etc.                        
                        foreach (model_Idi_Curso curso in model_Idi_PlanEstudio.Idi_Curso)
                        {
                            index = lstCurso.FindIndex(c => c.IdIdi_Curso == curso.IdIdi_Curso);
                            
                            if (index >= 0)
                            {
                                curso.IdIdi_NivelCurso = lstCurso[index].IdIdi_NivelCurso;
                                curso.IdIdi_TipoCurso = lstCurso[index].IdIdi_TipoCurso;
                                curso.CodigoCurso = lstCurso[index].CodigoCurso;
                                curso.Asignatura = lstCurso[index].Asignatura;
                                curso.Ciclo = lstCurso[index].Ciclo;
                                curso.HorasTeoricas = lstCurso[index].HorasTeoricas;
                                curso.HorasPracticas = lstCurso[index].HorasTeoricas;
                                curso.HorasLectivas = lstCurso[index].HorasLectivas;
                                curso.Creditos = lstCurso[index].Creditos;
                                curso.Electivo = lstCurso[index].Electivo;
                                curso.Orden = lstCurso[index].Orden;
                                curso.Ofertado = lstCurso[index].Ofertado;
                                curso.Estado = lstCurso[index].Estado;
                                curso.Activo = lstCurso[index].Activo;
                                curso.UsuarioCreacion = lstCurso[index].UsuarioCreacion;
                                curso.FechaCreacion = lstCurso[index].FechaCreacion;
                                curso._Idcurso = lstCurso[index]._Idcurso;
                                curso._PreReq = lstCurso[index]._PreReq;
                                curso._IdNivel = lstCurso[index]._IdNivel;
                                curso._IdTipoCurso = lstCurso[index]._IdTipoCurso;
                            }
                        }

                        List<model_dto_Curso> cursosAdicionales = lstCurso.Where(c => c._auxiliarEmpadronamiento > 0).ToList();
                        if (cursosAdicionales.Count > 0)
                        {
                            foreach (model_dto_Curso curso in cursosAdicionales)
                            {
                                model_Idi_PlanEstudio.Idi_Curso.Add(new model_Idi_Curso(idIdi_NivelCurso: curso.IdIdi_NivelCurso
                                    , idIdi_TipoCurso: curso.IdIdi_TipoCurso
                                    , codigoCurso: curso.CodigoCurso
                                    , asignatura: curso.Asignatura
                                    , ciclo: curso.Ciclo
                                    , horasTeoricas: curso.HorasTeoricas
                                    , horasPracticas: curso.HorasTeoricas
                                    , horasLectivas: curso.HorasLectivas
                                    , creditos: curso.Creditos
                                    , electivo: curso.Electivo
                                    , ofertado: curso.Ofertado
                                    , orden: curso.Orden
                                ));
                            }
                        }

                        Response<bool> actualizacionIdi_PlanEstudio = controller_Idi_PlanEstudio.fncCON_ModificarPlandeEstudioCompleto(model_Idi_PlanEstudio);

                        if (actualizacionIdi_PlanEstudio.Success) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }
                        else { mtdMostrarMensaje(actualizacionIdi_PlanEstudio.MensajeError.ToList()[0].Mensaje); }
                    }

                    mtd_ListarPlanes(Convert.ToInt32(cmbIdioma.SelectedValue));

                    //Ver
                    mtd_ObtenerDatosPlanIndividual();
                    if (dgvCursosPlan.SelectedRows.Count > 0 && lstCurso.Count > 0)
                    {
                        mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Modificar);
                    }
                    else { mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Ninguno); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelarPlan_Click(object sender, EventArgs e)
        {
            //Ver
            try
            {
                if (MessageBox.Show("Está por restaurar todo el formulario, ¿seguro que desea continuar?, los cambios sin guardar se perderán"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    model_Idi_PlanEstudio = new model_Idi_PlanEstudio();
                    model_dto_Curso = new model_dto_Curso();
                    mtd_RestaurarFormularioPlan(enm_G_TipoAccionMantenimiento.Cancelar);
                    mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Cancelar);

                    dgvCursosPlan.DataSource = null;
                }
                
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministrarPlanEstudio_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try { txtCodigo.Text = fncGenerarCodigoCurso(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void nudOrden_ValueChanged(object sender, EventArgs e)
        {
            try { txtCodigo.Text = fncGenerarCodigoCurso(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void nudCiclo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                switch (enmEstadoCurso)
                {
                    case _enmTipoModificacionCurso.Default:
                    case _enmTipoModificacionCurso.Restaurando:
                        nudOrden.Value = 0;
                        break;
                    case _enmTipoModificacionCurso.Asignando:
                        nudOrden.Value = model_dto_Curso.Orden;
                        break;
                    case _enmTipoModificacionCurso.ModificandoControl:
                        nudOrden.Value = (lstCurso.Where(c => c.Ciclo == Convert.ToByte(nudCiclo.Value)).Max(d => d.Orden as byte?) ?? 0);
                        nudOrden.Value = model_dto_Curso._auxiliarEmpadronamiento > 0 ? nudOrden.Value : nudOrden.Value + 1;
                        break;
                }

                txtCodigo.Text = fncGenerarCodigoCurso();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarCurso())
                {
                    dgvCursosPlan.DataSource = null;

                    if (fncTipoMovimientoCurso(model_dto_Curso) == enm_G_TipoAccionMantenimiento.Nuevo)
                    {
                        model_dto_Curso.IdIdi_NivelCurso = Convert.ToInt16(cmbNivelCurso.SelectedValue);
                        model_dto_Curso.IdIdi_TipoCurso = Convert.ToInt16(cmbTipoCurso.SelectedValue);
                        model_dto_Curso.CodigoCurso = txtCodigo.Text;
                        model_dto_Curso.Asignatura = txtNombre.Text;
                        model_dto_Curso.Ciclo = Convert.ToByte(nudCiclo.Value);
                        model_dto_Curso.HorasPracticas = Convert.ToByte(nudHP.Value);
                        model_dto_Curso.HorasTeoricas = Convert.ToByte(nudHT.Value);
                        model_dto_Curso.HorasLectivas = Convert.ToByte(nudHL.Value);
                        model_dto_Curso.Creditos = Convert.ToByte(nudCreditos.Value);
                        model_dto_Curso.Electivo = chkElectivo.Checked;
                        model_dto_Curso.EsElectivo = chkElectivo.Checked ? "SI" : "NO";
                        model_dto_Curso.Orden = Convert.ToByte(nudOrden.Value);
                        model_dto_Curso.Ofertado = chkOfertado.Checked;
                        model_dto_Curso.EsOfertado = chkOfertado.Checked ? "SI" : "NO";
                        model_dto_Curso._auxiliarEmpadronamiento = lstCurso.Select(c => c._auxiliarEmpadronamiento > 0).ToList().Count <= 0 ?
                            Convert.ToByte(1) :
                            Convert.ToByte(lstCurso.Max(c => c._auxiliarEmpadronamiento) + 1);

                        lstCurso.Add(model_dto_Curso);
                    }
                    else
                    {
                        int indexActualizar = model_dto_Curso.IdIdi_Curso == 0 && model_dto_Curso._auxiliarEmpadronamiento > 0 ?
                            lstCurso.FindIndex(c => c._auxiliarEmpadronamiento == model_dto_Curso._auxiliarEmpadronamiento) :
                                lstCurso.FindIndex(c => c.IdIdi_Curso == model_dto_Curso.IdIdi_Curso);

                        if (indexActualizar >= 0)
                        {
                            lstCurso[indexActualizar] = new model_dto_Curso(idIdi_Curso: model_dto_Curso.IdIdi_Curso
                                , idIdi_PlanEstudio: model_dto_Curso.IdIdi_PlanEstudio
                                , idIdi_NivelCurso: Convert.ToInt16(cmbNivelCurso.SelectedValue)
                                , idIdi_TipoCurso: Convert.ToInt16(cmbTipoCurso.SelectedValue)
                                , codigoCurso: txtCodigo.Text
                                , asignatura: txtNombre.Text
                                , ciclo: Convert.ToByte(nudCiclo.Value)
                                , horasTeoricas: Convert.ToByte(nudHT.Value)
                                , horasPracticas: Convert.ToByte(nudHP.Value)
                                , horasLectivas: Convert.ToByte(nudHL.Value)
                                , creditos: Convert.ToByte(nudCreditos.Value)
                                , electivo: chkElectivo.Checked
                                , esElectivo: chkElectivo.Checked ? "SI" : "NO"
                                , orden: Convert.ToByte(nudOrden.Value)
                                , ofertado: chkOfertado.Checked
                                , esOfertado: chkOfertado.Checked ? "SI" : "NO"
                                , estado: model_dto_Curso.Estado
                                , activo: model_dto_Curso.Activo
                                , usuarioCreacion: model_dto_Curso.UsuarioCreacion
                                , fechaCreacion: model_dto_Curso.FechaCreacion
                                , idCurso: model_dto_Curso._Idcurso
                                , preReq: model_dto_Curso._PreReq
                                , idNivel: model_dto_Curso._IdNivel
                                , idTipoCurso: model_dto_Curso._IdTipoCurso
                                , auxiliarEmpadronamiento: model_dto_Curso._auxiliarEmpadronamiento); ;
                        }
                    }

                    dgvCursosPlan.DataSource =
                        lstCurso.OrderBy(c => c.Ciclo)
                        .ThenByDescending(d => d._auxiliarEmpadronamiento)
                        .ThenBy(e => e.Orden)
                        .ToList();

                    mtd_AjustarCursosPlan();

                    dgvCursosPlan.Refresh();

                    model_dto_Curso = new model_dto_Curso();
                    mtd_RestaurarFormularioCurso(enm_G_TipoAccionMantenimiento.Nuevo);
                    enmEstadoCurso = _enmTipoModificacionCurso.ModificandoControl;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
