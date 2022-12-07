using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

using pry04.View.Idiomas_v2.Individuo;
using pry04.View.Idiomas_v2.PlanEstudio;
using pry04.View.Idiomas_v2.Principal;

namespace pry04.View.Idiomas_v2.CargaHoraria
{
    public partial class frmAdministracionCargaHoraria : Form
    {
        public frmAdministracionCargaHoraria() { InitializeComponent(); }

        #region DATOS RECIBIDOS
        short rec_IdIdi_Docente = new short();
        #endregion

        private controller_Idi_Docente controller_Idi_Docente = new controller_Idi_Docente();
        private controller_Idi_Curso controller_Idi_Curso = new controller_Idi_Curso();
        private controller_Idi_PeriodoEnsenianza controller_Idi_PeriodoEnsenianza = new controller_Idi_PeriodoEnsenianza();
        private controller_Idi_CursoPeriodo controller_Idi_CursoPeriodo = new controller_Idi_CursoPeriodo();

        private model_Idi_PeriodoEnsenianza model_Idi_PeriodoEnsenianza = new model_Idi_PeriodoEnsenianza();

        private List<model_dto_CursoPeriodo> lstCursosPeriodo = new List<model_dto_CursoPeriodo>();

        #region ========================================================= MÉTODOS =========================================================

        private void mtd_ObtenerDatosPeriodoEnsenianza()
        {
            try
            {
                Response<List<model_dto_PeriodoEnsenianza>> Idi_PeriodoEnsenianzaHistorial =
                                controller_Idi_PeriodoEnsenianza.fncCON_VisualPeriodoEnsenianza(rec_IdIdi_Docente);

                if (_validarRespuesta(Idi_PeriodoEnsenianzaHistorial))
                {
                    dgvPeriodoEnsenianza.DataSource = Idi_PeriodoEnsenianzaHistorial.Data;
                    mtd_AjustarPeriodoEnsenianza();
                    mtd_ListarCursosPeriodo();

                    Response<List<model_Idi_PeriodoEnsenianza>> Idi_PeriodoEnsenianzaActual = controller_Idi_PeriodoEnsenianza.
                        fncCON_ListaPeriodoEnsenianzaIndividualCompleto(rec_IdIdi_Docente, stuSistema.esquemaCronograma.IdIdi_Semestre);

                    if (_validarRespuesta(Idi_PeriodoEnsenianzaActual))
                    {
                        model_Idi_PeriodoEnsenianza = Idi_PeriodoEnsenianzaActual.Data[0];
                        Response<List<model_dto_CursoPeriodo>> Idi_CursoPeriodo = controller_Idi_CursoPeriodo
                            .fncCON_VisualListaCursoPeriodo(model_Idi_PeriodoEnsenianza.IdIdi_PeriodoEnsenianza);

                        if (_validarRespuesta(Idi_CursoPeriodo))
                        {
                            lstCursosPeriodo = Idi_CursoPeriodo.Data;
                            mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Modificar);
                            dgvCurso.DataSource = lstCursosPeriodo;
                            mtd_AjustarCursoPeriodo(dgvCurso);
                        }
                        else { dgvCursosPeriodo.DataSource = null; }
                    }
                    else
                    {
                        model_Idi_PeriodoEnsenianza = new model_Idi_PeriodoEnsenianza();
                        mtdMostrarMensaje("No se encontró carga horaria para el semestre actual");
                        mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Ninguno);
                    }
                }
                else
                {
                    mtdMostrarMensaje("No se encontró datos del docente");
                    mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Ninguno);
                    dgvPeriodoEnsenianza.DataSource = null;
                    dgvCursosPeriodo.DataSource = null;
                    dgvCurso.DataSource = null;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarSeccion()
        {
            try
            {
                //Letra A -> Z
                List<customComboBox> lstSeccion = new List<customComboBox>(); 
                for (byte i = 65; i <= 90; i++) { lstSeccion.Add(new customComboBox(i, Convert.ToChar(i).ToString())); }
                
                mtdLlenarComboBoxManual(cmbSeccion, lstSeccion);
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
                        btnGuardar.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        pnlCargaHoraria.Enabled = false;
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnCancelar.Enabled = false;

                        btnGuardar.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                        pnlCargaHoraria.Enabled = true;

                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;

                        btnGuardar.Text = "   Guardar";
                        break;
                    
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        pnlCargaHoraria.Enabled = true;

                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;

                        btnGuardar.Text = "   Modificar";
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void mtd_ListarCursosPeriodo()
        {
            try
            {
                if (dgvPeriodoEnsenianza.Rows.Count > 0 && dgvPeriodoEnsenianza.SelectedRows.Count > 0)
                {
                    int _IdIdi_PeriodoEnsenianza = Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvPeriodoEnsenianza.CurrentRow, "IdIdi_PeriodoEnsenianza"));
                    Response<List<model_dto_CursoPeriodo>> data_Idi_CursoPeriodo = controller_Idi_CursoPeriodo.fncCON_VisualListaCursoPeriodo(_IdIdi_PeriodoEnsenianza);

                    if (_validarRespuesta(data_Idi_CursoPeriodo))
                    {
                        dgvCursosPeriodo.DataSource = data_Idi_CursoPeriodo.Data;
                        mtd_AjustarCursoPeriodo(dgvCursosPeriodo);
                    }
                    else { dgvCursosPeriodo.DataSource = null; }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarCursoPeriodo(DataGridView target)
        {
            try
            {
                mtdNoOrdenarDataGridView(target);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_PeriodoEnsenianza", "IdIdi_Curso", "Estado", "Activo", "UsuarioCreacion", "FechaCreacion"
                , "_IdSem", "_IdTurno", "_Codigo"};

                mtdFormatearDataGridView(target, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_PlanEstudio = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_CursoPeriodo", "ID", width: 60)
                    , new customDataGridViewRow("Curso", "ASIGNATURA"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 120)
                    , new customDataGridViewRow("Seccion", "SECCION", width: 60)
                    , new customDataGridViewRow("Ciclo", "CICLO", width: 40)
                };

                mtdAjustarDataGridView(target, lstAjuste_PlanEstudio);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarPeriodoEnsenianza()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvPeriodoEnsenianza);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_Semestre", "Estado", "Activo", "UsuarioCreacion", "FechaCreacion", "_IdSem"
                , "_IdTurno", "_Codigo" };
                
                mtdFormatearDataGridView(dgvPeriodoEnsenianza, lstColumnasOcultar);

                List<string> lstColumnasFecha = new List<string> { "FechaInicio", "FechaFin" };
                mtdFormatearDataGridView(dgvPeriodoEnsenianza, lstColumnasFecha, enm_G_TipoFormatoDataGridView.Fecha);
                
                List<customDataGridViewRow> lstAjuste_PlanEstudio = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_PeriodoEnsenianza", "ID", width: 50)
                    , new customDataGridViewRow("Semestre", "SEMESTRE", width: 60, autoSize: true)
                    , new customDataGridViewRow("FechaInicio", "DESDE", width: 80, autoSize: true)
                    , new customDataGridViewRow("FechaFin", "HASTA", width: 80, autoSize: true)
                };

                mtdAjustarDataGridView(dgvPeriodoEnsenianza, lstAjuste_PlanEstudio);
                mtdSeleccionarRegistro(dgvPeriodoEnsenianza, "IdIdi_PeriodoEnsenianza");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RefrescarVisualCursos()
        {
            try
            {
                dgvCurso.DataSource = null;
                dgvCurso.DataSource = lstCursosPeriodo;
                mtd_AjustarCursoPeriodo(dgvCurso);
                dgvCurso.Refresh();

                if (lstCursosPeriodo.Count == 0)
                {
                    lstCursosPeriodo = new List<model_dto_CursoPeriodo>();
                    dgvCurso.DataSource = null;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AgregarCurso(short idIdi_Curso)
        {
            try
            {
                Response<model_Idi_Curso> data_Idi_Curso = controller_Idi_Curso.fncCON_IndividualCurso(idIdi_Curso);
                if (_validarRespuesta(data_Idi_Curso))
                {
                    lstCursosPeriodo.Add(new model_dto_CursoPeriodo(idIdi_PeriodoEnsenianza: model_Idi_PeriodoEnsenianza.IdIdi_PeriodoEnsenianza
                        , idIdi_Curso: data_Idi_Curso.Data.IdIdi_Curso
                        , curso: data_Idi_Curso.Data.CodigoCurso + " " + data_Idi_Curso.Data.Asignatura
                        , ciclo: data_Idi_Curso.Data.Ciclo
                        , seccion: cmbSeccion.Text
                    ));
                    mtd_RefrescarVisualCursos();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LimpiarDatosDocente()
        {
            try
            {
                rec_IdIdi_Docente = 0;
                txtIdIdi_Docente.Text = "";
                txtDocente.Text = "";
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
                    txtIdIdi_Docente.Text = data_Idi_Docente.Data.IdIdi_Docente.ToString();
                    txtDocente.Text = data_Idi_Docente.Data.ApellidoPaterno
                        + "" + data_Idi_Docente.Data.ApellidoMaterno
                        + ", " + data_Idi_Docente.Data.Nombres;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion ========================================================================================================================

        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarCursos()
        {
            try
            {
                if (lstCursosPeriodo.Count == 0)
                {
                    mtdMostrarMensaje("Necesita agregar cursos para ingresar la caraga horaria del semestre seleccionado");
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
        #endregion ========================================================================================================================

        private void btnSeleccionarDocente_Click(object sender, EventArgs e)
        {
            bool continuar = new bool();
            try
            {
                if (rec_IdIdi_Docente > 0)
                {
                    if (MessageBox.Show("Está por restaurar todo el formulario, ¿seguro que desea continuar?, los cambios sin guardar se perderán"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes) { continuar = true; }
                    else { continuar= false; }
                }
                else { continuar = true; }

                if (continuar)
                {
                    frmBusquedaDocente FrmBuscar = new frmBusquedaDocente();
                    if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                    {
                        lstCursosPeriodo = new List<model_dto_CursoPeriodo>();
                        mtd_RefrescarVisualCursos();
                        rec_IdIdi_Docente = FrmBuscar.env_IdIdi_Docente;

                        if (rec_IdIdi_Docente > 0)
                        {
                            mtd_ObtenerDatosDocente();
                            mtd_ObtenerDatosPeriodoEnsenianza();
                        }
                        else
                        {
                            mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Ninguno);
                            dgvPeriodoEnsenianza.DataSource = null;
                            dgvCursosPeriodo.DataSource = null;
                            dgvCurso.DataSource = null;
                            mtd_LimpiarDatosDocente();
                        }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(cmbSeccion.SelectedValue) != -1)
                {
                    frmBusquedaCurso FrmBuscar = new frmBusquedaCurso();
                    if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                    {
                        short _IdIdi_Curso = FrmBuscar.env_IdIdi_Curso;
                        int _index = lstCursosPeriodo.FindIndex(c => c.IdIdi_Curso == _IdIdi_Curso && c.Seccion == cmbSeccion.Text);
                        if (_IdIdi_Curso > 0)
                        {
                            if (_index > -1) { mtdMostrarMensaje("La sección y curso seleccionados ya fueron agregados anteriormente"); }
                            else { mtd_AgregarCurso(_IdIdi_Curso); }
                        }
                    }
                }
                else { mtdMostrarMensaje("Seleccione una sección antes de agregar un curso"); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCurso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lstCursosPeriodo.Count > 0 && dgvCurso.Rows.Count > 0)
                {
                    short _IdIdi_Curso = Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvCurso.CurrentRow, "IdIdi_Curso"));
                    string _Seccion = mtdObtenerCeldaDataGridViewRow(dgvCurso.CurrentRow, "Seccion").ToString();
                    int _index = lstCursosPeriodo.FindIndex(c => c.IdIdi_Curso == _IdIdi_Curso && c.Seccion == _Seccion);

                    if (2 == 2) //Validar si se puede eliminar este item de carga horaria
                    {
                        lstCursosPeriodo.RemoveAt(_index);
                    }
                    else { mtdMostrarMensaje("No se puede eliminar el registro por ... ... ... ... "); }

                    mtd_RefrescarVisualCursos();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvPeriodoEnsenianza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { mtd_ListarCursosPeriodo(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (rec_IdIdi_Docente <= 0) { mtdMostrarMensaje("Primero deberá seleccionar un docente"); }
                else
                {
                    model_Idi_PeriodoEnsenianza = new model_Idi_PeriodoEnsenianza();
                    mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Nuevo);
                    
                    lstCursosPeriodo = new List<model_dto_CursoPeriodo>();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int index = -1;
            try
            {
                if (fncValidarCursos())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        model_Idi_PeriodoEnsenianza.IdIdi_Docente = rec_IdIdi_Docente;
                        model_Idi_PeriodoEnsenianza.IdIdi_Semestre = stuSistema.esquemaCronograma.IdIdi_Semestre;
                        model_Idi_PeriodoEnsenianza.FechaInicio = new DateTime(stuSistema.esquemaCronograma.Anio, stuSistema.esquemaCronograma.Mes, 1);
                        model_Idi_PeriodoEnsenianza.FechaFin = model_Idi_PeriodoEnsenianza.FechaInicio.AddMonths(1).AddDays(-1);

                        //Verificar los datos cuando se registra y actualiza, xq se pasa de DTO a IDI y no siempre pasa datos de estado, activo, usuario registro, etc.
                        foreach (model_Idi_CursoPeriodo cursoPeriodo in model_Idi_PeriodoEnsenianza.Idi_CursoPeriodo)
                        {
                            index = lstCursosPeriodo.FindIndex(c => c.IdIdi_Curso == cursoPeriodo.IdIdi_Curso && c.Seccion == cursoPeriodo.Seccion);

                            if (index >= 0)
                            {
                                cursoPeriodo.IdIdi_PeriodoEnsenianza = lstCursosPeriodo[index].IdIdi_PeriodoEnsenianza;
                                cursoPeriodo.IdIdi_Curso = lstCursosPeriodo[index].IdIdi_Curso;
                                cursoPeriodo.Seccion = lstCursosPeriodo[index].Seccion;
                                cursoPeriodo.Estado = lstCursosPeriodo[index].Estado;
                                cursoPeriodo.Activo = lstCursosPeriodo[index].Activo;
                                cursoPeriodo.UsuarioCreacion = lstCursosPeriodo[index].UsuarioCreacion; 
                                cursoPeriodo.FechaCreacion= lstCursosPeriodo[index].FechaCreacion;
                                cursoPeriodo._IdSem = lstCursosPeriodo[index]._IdSem;
                                cursoPeriodo._IdTurno = lstCursosPeriodo[index]._IdTurno;
                                cursoPeriodo._Codigo = lstCursosPeriodo[index]._Codigo;
                            }
                        }

                        List<model_dto_CursoPeriodo> cursosAdicionales = lstCursosPeriodo.Where(c => c.IdIdi_CursoPeriodo == 0).ToList();
                        if (cursosAdicionales.Count > 0)
                        {
                            foreach (model_dto_CursoPeriodo cursoPeriodo in cursosAdicionales)
                            {
                                model_Idi_PeriodoEnsenianza.Idi_CursoPeriodo.Add(new model_Idi_CursoPeriodo(
                                    idIdi_PeriodoEnsenianza: model_Idi_PeriodoEnsenianza.IdIdi_PeriodoEnsenianza
                                    , idIdi_Curso: cursoPeriodo.IdIdi_Curso
                                    , seccion: cursoPeriodo.Seccion));
                            }
                        }

                        Response<bool> actualizacionIdi_PeriodoEnsenianza = controller_Idi_PeriodoEnsenianza.fncCON_ModificarPeriodoEnsenianzaCompleto(model_Idi_PeriodoEnsenianza);

                        if (actualizacionIdi_PeriodoEnsenianza.Success) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }
                        else { mtdMostrarMensaje(actualizacionIdi_PeriodoEnsenianza.MensajeError.ToList()[0].Mensaje); }
                    }

                    mtd_ObtenerDatosPeriodoEnsenianza();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bool continuar = new bool();
            try
            {
                if (lstCursosPeriodo.Count == 0)
                {
                    if (MessageBox.Show("Está por restaurar la información de la carga horaria en cuestión, ¿seguro que desea continuar?, los cambios sin guardar se perderán"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    { continuar = true; }
                    else { continuar = false; }
                }
                else { continuar = true; }

                if (continuar)
                {
                    model_Idi_PeriodoEnsenianza = new model_Idi_PeriodoEnsenianza();
                    lstCursosPeriodo = new List<model_dto_CursoPeriodo>();
                    mtd_EstadoPanel(enm_G_TipoAccionMantenimiento.Cancelar);

                    //mtd_RefrescarVisualCursos();
                }                
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionCargaHoraria_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }

        private void frmAdministracionCargaHoraria_Load(object sender, EventArgs e)
        {
            try { mtd_CargarSeccion(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
