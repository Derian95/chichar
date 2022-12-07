using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

using pry04.View.Idiomas_v2.Individuo;
using pry04.View.Idiomas_v2.PlanEstudio;
using pry04.View.Idiomas_v2.Semestre;
using pry04.View.Idiomas_v2.Principal;

namespace pry04.View.Idiomas_v2.Matricula
{
    public partial class frmAdministracionExamen : Form
    {
        public frmAdministracionExamen() { InitializeComponent(); }

        #region DATOS RECIBIDOS
        int rec_CodigoUniversitario = new int();
        short rec_IdIdi_Docente = new short();
        short rec_IdIdi_Curso = new short();
        short rec_IdIdi_Semestre = new short();
        #endregion

        private controller_ESTADOCURSO controller_ESTADOCURSO = new controller_ESTADOCURSO();
        private controller_Idi_Examen controller_Idi_Examen = new controller_Idi_Examen();
        
        private controller_ESTUDIANTE controller_ESTUDIANTE = new controller_ESTUDIANTE();
        private controller_Idi_Docente controller_Idi_Docente = new controller_Idi_Docente();
        private controller_Idi_Curso controller_Idi_Curso = new controller_Idi_Curso();
        private controller_Idi_Semestre controller_Idi_Semestre = new controller_Idi_Semestre();

        private List<model_ESTADOCURSO> lstESTADOCURSO = new List<model_ESTADOCURSO>();
        private List<model_dto_Examen> lstExamen = new List<model_dto_Examen>();
        private List<model_dto_Examen> lstFiltroExamen = new List<model_dto_Examen>();

        private model_Idi_Examen model_Idi_Examen = new model_Idi_Examen();

        #region ========================================================= MÉTODOS =========================================================

        private void mtd_ObtenerExamenIndividual()
        {
            try
            {
                model_Idi_Examen = new model_Idi_Examen(idIdi_Examen: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "IdIdi_Examen"))
                    , idIdi_Docente: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "IdIdi_Docente"))
                    , idIdi_Curso: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "IdIdi_Curso"))
                    , idIdi_Semestre: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "IdIdi_Semestre"))
                    , idIdi_TipoCalificacion: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "IdIdi_TipoCalificacion"))
                    , codigoEstadoCurso: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "CodigoEstadoCurso"))
                    , tipoExamen: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "TipoExamen"))
                    , codigoUniversitario: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "CodigoUniversitario"))
                    , tema: mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "Tema").ToString()
                    , fecha: Convert.ToDateTime(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "Fecha"))
                    , nota: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "Nota"))
                    , estado: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "Estado"))
                    , activo: Convert.ToBoolean(mtdObtenerCeldaDataGridViewRow(dgvExamen.CurrentRow, "Activo"))
                );

                rec_CodigoUniversitario = model_Idi_Examen.CodigoUniversitario;
                rec_IdIdi_Curso = model_Idi_Examen.IdIdi_Curso;
                rec_IdIdi_Docente = model_Idi_Examen.IdIdi_Docente;
                rec_IdIdi_Semestre = model_Idi_Examen.IdIdi_Semestre;

                Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> data_ESTUDIANTE = controller_ESTUDIANTE.fncCON_RelacionEstudiantes(codigoUniversitario: rec_CodigoUniversitario);
                Response<model_Idi_Docente> data_Idi_Docente = controller_Idi_Docente.fncCON_IndividualDocente(rec_IdIdi_Docente);
                Response<model_Idi_Curso> data_Idi_Curso = controller_Idi_Curso.fncCON_IndividualCurso(rec_IdIdi_Curso);
                Response<model_Idi_Semestre> data_Idi_Semestre = controller_Idi_Semestre.fncCON_IndividualCurso(rec_IdIdi_Semestre);

                if (_validarRespuesta(data_ESTUDIANTE))
                {
                    txtCodigoUniversitario.Text = data_ESTUDIANTE.Data[0].CodUniv.ToString();
                    txtEstudiante.Text = data_ESTUDIANTE.Data[0].NombreCompleto;
                } else { txtCodigoUniversitario.Text = "0"; }

                if (_validarRespuesta(data_Idi_Docente))
                {
                    txtIdIdi_Docente.Text = data_Idi_Docente.Data.IdIdi_Docente.ToString();
                    txtDocente.Text = data_Idi_Docente.Data.ApellidoPaterno
                    + "" + data_Idi_Docente.Data.ApellidoMaterno
                    + ", " + data_Idi_Docente.Data.Nombres;
                } else { txtIdIdi_Docente.Text = "0"; }

                if (_validarRespuesta(data_Idi_Curso))
                {
                    txtIdIdi_Curso.Text = data_Idi_Curso.Data.IdIdi_Curso.ToString();
                    txtCurso.Text = data_Idi_Curso.Data.CodigoCurso + "-" + data_Idi_Curso.Data.Asignatura;
                } else { txtIdIdi_Curso.Text = "0"; }

                if (_validarRespuesta(data_Idi_Semestre))
                {
                    txtIdIdi_Semestre.Text = data_Idi_Semestre.Data.IdIdi_Semestre.ToString();
                    txtSemestre.Text = data_Idi_Semestre.Data.Semestre;                   
                } else { txtIdIdi_Semestre.Text = "0"; }

                rbtUbicacion.Checked = model_Idi_Examen.TipoExamen == Convert.ToByte(enmTipoExamen.Ubicacion) ? true : false;
                rbtAcreditacion.Checked = model_Idi_Examen.TipoExamen == Convert.ToByte(enmTipoExamen.Acreditacion) ? true : false;
                txtTema.Text = model_Idi_Examen.Tema;
                cmbEstado.SelectedValue = model_Idi_Examen.CodigoEstadoCurso == 0 ? -1: Convert.ToInt64(model_Idi_Examen.CodigoEstadoCurso);
                dtpFecha.Value = model_Idi_Examen.Fecha;
                nudNota.Value = model_Idi_Examen.Nota;

            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LimpiarDatosEstudiante()
        {
            try
            {
                rec_CodigoUniversitario = 0;
                txtCodigoUniversitario.Text = "";
                txtEstudiante.Text = "";
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LimpiarDatosDocente()
        {
            try
            {
                rec_IdIdi_Docente = 0;
                txtIdIdi_Docente .Text = "";
                txtDocente.Text = "";
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LimpiarDatosCurso()
        {
            try
            {
                rec_IdIdi_Curso = 0;
                txtIdIdi_Curso.Text = "";
                txtCurso.Text = "";
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LimpiarDatosSemestre()
        {
            try
            {
                rec_IdIdi_Semestre = 0;
                txtIdIdi_Semestre.Text = "";
                txtSemestre.Text = "";
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                rbtUbicacion.Checked = false;
                rbtAcreditacion.Checked = false;
                cmbEstado.SelectedValue = Convert.ToInt64(-1);
                mtd_LimpiarDatosEstudiante();
                mtd_LimpiarDatosDocente();
                mtd_LimpiarDatosCurso();
                mtd_LimpiarDatosSemestre();
                txtTema.Text = "";
                dtpFecha.Value = DateTime.Now;
                nudNota.Value = 0;

                mtd_EstadoPanelExamen(tipo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_EstadoPanelExamen(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        pnlDatosExamen.Enabled = false;
                        btnGuardar.Text = "   Guardar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnCancelar.Enabled = false;
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        pnlDatosExamen.Enabled = true;
                        btnGuardar.Text = "   Modificar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        
                        btnNuevo.Enabled = tipo == enm_G_TipoAccionMantenimiento.Nuevo ? false: true;
                        btnGuardar.Text = tipo == enm_G_TipoAccionMantenimiento.Nuevo ? "   Guardar" : "   Modificar";
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarExamen()
        {
            try
            {
                Response<List<model_dto_Examen>> data_Idi_Examen = controller_Idi_Examen.fncCON_VisualListaExamen();
                if (_validarRespuesta(data_Idi_Examen))
                {
                    lstExamen = data_Idi_Examen.Data;
                    dgvExamen.DataSource = lstExamen;
                    mtd_FiltrarExamen();
                    mtd_AjustarExamen();
                } else { dgvExamen.DataSource = null; }

                dgvExamen.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarExamen()
        {
            try
            {
                lstFiltroExamen = lstExamen;
                lstFiltroExamen = lstExamen.Where(c => c.CodigoUniversitario.ToString().Contains(txtFiltroCodigoUniversitario.Text)).ToList();

                dgvExamen.DataSource = lstFiltroExamen;

                dgvExamen.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarExamen()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvExamen);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_Docente", "IdIdi_Curso", "IdIdi_Semestre", "IdIdi_TipoCalificacion", "CodigoEstadoCurso"
                    , "TipoExamen", "Estado", "Activo", "AnioSemestre", "MesSemestre"
                };
                mtdFormatearDataGridView(dgvExamen, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Examen = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Examen", "ID", width: 40)
                    , new customDataGridViewRow("Semestre", "SEMESTRE", width: 80)
                    , new customDataGridViewRow("Tema", "TEMA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 280)
                    , new customDataGridViewRow("TipoCalificacion", "ESCALA", width: 80)
                    , new customDataGridViewRow("EstadoCurso", "ESTADO", width: 80)
                    , new customDataGridViewRow("TipoExamenDescripcion", "TIPO", width: 80)
                    , new customDataGridViewRow("CodigoUniversitario", "CÓDIGO", width: 100)
                    , new customDataGridViewRow("Fecha", "FECHA", width: 80)
                    , new customDataGridViewRow("Nota", "NOTA", width: 80)
                };
                mtdAjustarDataGridView(dgvExamen, lstAjuste_Examen);
                mtdSeleccionarRegistro(dgvExamen, "IdIdi_Examen");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosEstudiante()
        {
            try
            {
                Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> data_ESTUDIANTE = controller_ESTUDIANTE.fncCON_RelacionEstudiantes(codigoUniversitario: rec_CodigoUniversitario);

                if (_validarRespuesta(data_ESTUDIANTE))
                {
                    txtCodigoUniversitario.Text = data_ESTUDIANTE.Data[0].CodUniv.ToString();
                    txtEstudiante.Text = data_ESTUDIANTE.Data[0].NombreCompleto;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosDocente()
        {
            try
            {
                Response<model_Idi_Docente> data_Idi_Docente = controller_Idi_Docente.fncCON_IndividualDocente(rec_IdIdi_Docente);
                if (_validarRespuesta(data_Idi_Docente))
                {
                    if (data_Idi_Docente.Data != null)
                    {
                        txtIdIdi_Docente.Text = data_Idi_Docente.Data.IdIdi_Docente.ToString();
                        txtDocente.Text = data_Idi_Docente.Data.ApellidoPaterno
                            + "" + data_Idi_Docente.Data.ApellidoMaterno
                            + ", " + data_Idi_Docente.Data.Nombres;
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosCurso()
        {
            try
            {
                Response<model_Idi_Curso> data_Idi_Curso = controller_Idi_Curso.fncCON_IndividualCurso(rec_IdIdi_Curso);
                if (_validarRespuesta(data_Idi_Curso))
                {
                    txtIdIdi_Curso.Text = data_Idi_Curso.Data.IdIdi_Curso.ToString();
                    txtCurso.Text = data_Idi_Curso.Data.CodigoCurso + "-" + data_Idi_Curso.Data.Asignatura;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosSemestre()
        {
            try
            {
                Response<model_Idi_Semestre> data_Idi_Semestre = controller_Idi_Semestre.fncCON_IndividualCurso(rec_IdIdi_Semestre);
                if (_validarRespuesta(data_Idi_Semestre))
                {
                    txtIdIdi_Semestre.Text = data_Idi_Semestre.Data.IdIdi_Semestre.ToString();
                    txtSemestre.Text = data_Idi_Semestre.Data.Semestre;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarEstadoCurso()
        {
            List<customComboBox> lstComboEstadoCurso = new List<customComboBox>();
            try
            {
                Response<List<model_ESTADOCURSO>> data_ESTADOCURSO = controller_ESTADOCURSO.fncCON_VisualListaESTADOCURSO();

                if (_validarRespuesta(data_ESTADOCURSO))
                {
                    lstESTADOCURSO = data_ESTADOCURSO.Data;
                    foreach (model_ESTADOCURSO reg in lstESTADOCURSO) { lstComboEstadoCurso.Add(new customComboBox(Convert.ToInt64(reg.CodigoEstado), reg.NombreEstado)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbEstado, objComboContenido: lstComboEstadoCurso);
                }
                else { mtdLimpiarComboBox(cmbEstado); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion



        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarExamen()
        {
            try
            {
                if (!rbtAcreditacion.Checked && !rbtUbicacion.Checked)
                {
                    mtdMostrarMensaje("Es necesario seleccionar el tipo");
                    return false;
                }
                if (rec_CodigoUniversitario == 0)
                {
                    mtdMostrarMensaje("Debe identificar el estudiante al que se aplicará el examen");
                    return false;
                }
                if (Convert.ToInt64(cmbEstado.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Escoja el estado del examen en cuestión");
                    return false;
                }
                if (nudNota.Value == 0)
                {
                    mtdMostrarMensaje("Ingrese correctamente la nota");
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



        private void frmAdministracionExamen_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarEstadoCurso();
                mtd_ListarExamen();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaEstudiante FrmBuscar = new frmBusquedaEstudiante();
                if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                {
                    rec_CodigoUniversitario = FrmBuscar.env_CodigoUniversitario;

                    if (rec_CodigoUniversitario > 0) { mtd_ObtenerDatosEstudiante(); }
                    else { mtd_LimpiarDatosEstudiante(); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaCurso FrmBuscar = new frmBusquedaCurso();
                if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                {
                    rec_IdIdi_Curso = FrmBuscar.env_IdIdi_Curso;

                    if (rec_IdIdi_Curso > 0) { mtd_ObtenerDatosCurso(); }
                    else { mtd_LimpiarDatosCurso(); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaDocente FrmBuscar = new frmBusquedaDocente();
                if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                {
                    rec_IdIdi_Docente = FrmBuscar.env_IdIdi_Docente;

                    if (rec_IdIdi_Docente > 0) { mtd_ObtenerDatosDocente(); }
                    else { mtd_LimpiarDatosDocente(); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarSemestre_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaSemestre FrmBuscar = new frmBusquedaSemestre();
                
                if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                {
                    rec_IdIdi_Semestre = FrmBuscar.env_IdIdi_Semestre;

                    if (rec_IdIdi_Semestre > 0) { mtd_ObtenerDatosSemestre(); }
                    else { mtd_LimpiarDatosSemestre(); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvExamenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                if (dgvExamen.SelectedRows.Count > 0 && lstFiltroExamen.Count > 0) { mtd_ObtenerExamenIndividual(); }
                else { btnNuevo.PerformClick(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Examen = new model_Idi_Examen();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtFiltroCodigoUniversitario_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarExamen(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Examen = new model_Idi_Examen();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarExamen())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        model_Idi_Examen.TipoExamen =
                            rbtAcreditacion.Checked ?
                                Convert.ToByte(enmTipoExamen.Acreditacion):
                                    rbtUbicacion.Checked ?
                                        Convert.ToByte(enmTipoExamen.Ubicacion):
                                        Convert.ToByte(0);
                        
                        model_Idi_Examen.CodigoUniversitario = rec_CodigoUniversitario;
                        model_Idi_Examen.IdIdi_Curso = rec_IdIdi_Curso;
                        model_Idi_Examen.IdIdi_Docente = rec_IdIdi_Docente;
                        model_Idi_Examen.IdIdi_Semestre = rec_IdIdi_Semestre;
                        model_Idi_Examen.Tema = txtTema.Text;
                        model_Idi_Examen.CodigoEstadoCurso = Convert.ToByte(cmbEstado.SelectedValue);
                        model_Idi_Examen.Fecha = dtpFecha.Value;
                        model_Idi_Examen.Nota = Convert.ToInt16(nudNota.Value);

                        if (model_Idi_Examen.IdIdi_Examen == 0)
                        {
                            Response<EsquemaRespuestaRegistro> registroIdi_Convenio = controller_Idi_Examen.fncCON_RegistrarExamen(model_Idi_Examen);

                            if (!registroIdi_Convenio.Success)
                            {
                                mtdMostrarMensaje(registroIdi_Convenio.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            Response<bool> actualizacionIdi_Convenio = controller_Idi_Examen.fncCON_ModificarExamen(model_Idi_Examen);

                            if (!actualizacionIdi_Convenio.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_Convenio.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                        mtd_ListarExamen();
                        btnNuevo.PerformClick();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionExamen_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}