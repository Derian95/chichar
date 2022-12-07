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
using pry04.View.Idiomas_v2.Principal;

namespace pry04.View.Idiomas_v2.Individuo
{
    public partial class frmAdministracionDocente : Form
    {
        public frmAdministracionDocente() { InitializeComponent(); }

        controller_Idi_Docente controller_Idi_Docente = new controller_Idi_Docente();

        model_Idi_Docente model_Idi_Docente = new model_Idi_Docente();

        List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id> lstDocente = new List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>();
        List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id> lstFiltroDocente = new List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_ObtenerConvenioIndividual()
        {
            try
            {
                model_Idi_Docente = new model_Idi_Docente(idIdi_Docente: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "IdIdi_Docente"))
                    , idEsc_TrabajadorDatosPersonales: Convert.ToInt64(mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "Idi_IdEsc_TrabajadorDatosPersonales"))
                    , numeroDocumento: mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "NumeroDocumento").ToString()
                    , apellidoPaterno: mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "ApellidoPaterno").ToString()
                    , apellidoMaterno: mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "ApellidoMaterno").ToString()
                    , nombres: mtdObtenerCeldaDataGridViewRow(dgvDocente.CurrentRow, "Nombres").ToString());

                txtDocumento.Text = model_Idi_Docente.NumeroDocumento;
                txtApellidoPaterno.Text = model_Idi_Docente.ApellidoPaterno;
                txtApellidoMaterno.Text = model_Idi_Docente.ApellidoMaterno;
                txtNombres.Text = model_Idi_Docente.Nombres;
                txtIdDocente.Text = model_Idi_Docente.IdIdi_Docente.ToString();
                txtIdEscalafon.Text = model_Idi_Docente.IdEsc_TrabajadorDatosPersonales.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                txtDocumento.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtNombres.Text = "";
                txtIdDocente.Text = "0";
                txtIdDocente .Text = "0";
                txtFiltroNombre.Text = "";

                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                        btnGuardar.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        btnGuardar.Text = "   Guardar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnCancelar.Enabled = false;
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                        btnGuardar.Text = "   Guardar";
                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        break;
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        btnGuardar.Text = "   Modificar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void mtd_AjustarDocente()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvDocente);

                List<string> lstColumnasOcultar = new List<string> { "Idi_IdEsc_TrabajadorDatosPersonales" };
                mtdFormatearDataGridView(dgvDocente, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Docente = new List<customDataGridViewRow> {
                    new customDataGridViewRow("Esc_IdEsc_TrabajadorDatosPersonales", "ESCALAFÓN", width: 80)
                    , new customDataGridViewRow("NumeroDocumento", "DOCUMENTO", width: 80)
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
                    , new customDataGridViewRow("IdIdi_Docente", "IDIOMAS", width: 70)
                };

                mtdAjustarDataGridView(dgvDocente, lstAjuste_Docente);
                mtdSeleccionarRegistro(dgvDocente, "Esc_IdEsc_TrabajadorDatosPersonales");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarDocente()
        {
            try
            {
                lstFiltroDocente = lstDocente;
                lstFiltroDocente = lstDocente.Where(c =>
                    c.ApellidoPaterno.ToUpper().Contains(txtFiltroNombre.Text.ToUpper())
                        || c.ApellidoMaterno.ToUpper().Contains(txtFiltroNombre.Text.ToUpper())
                        || c.Nombres.ToUpper().Contains(txtFiltroNombre.Text.ToUpper()))
                    .ToList();

                dgvDocente.DataSource = lstFiltroDocente;

                dgvDocente.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarDocente()
        {
            try
            {
                Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>> data_Idi_Docente = controller_Idi_Docente.fncCON_RelacionDocentesEnEscalafon();
                if (_validarRespuesta(data_Idi_Docente))
                {
                    lstDocente = data_Idi_Docente.Data;
                    if (lstDocente.Count > 0)
                    {
                        dgvDocente.DataSource = lstDocente;
                        mtd_FiltrarDocente();
                        mtd_AjustarDocente();
                    }
                    else { dgvDocente.DataSource = null; }
                }

                dgvDocente.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion



        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarDocente()
        {
            EsquemaValidacion stuValidacion = new EsquemaValidacion();
            try
            {
                stuValidacion = fncValidarDato(txtDocumento.Text, "Deberá ingresar correctamente el documento del docente", enm_G_TipoValidacionRegex.AlfaNumerico);
                if (!stuValidacion.Validado)
                {
                    mtdMostrarMensaje(stuValidacion.Mensaje);
                    return false;
                }

                stuValidacion = fncValidarDato(txtApellidoPaterno.Text, "Es necesario que consigne el primer apellido", enm_G_TipoValidacionRegex.Letras);
                if (!stuValidacion.Validado)
                {
                    mtdMostrarMensaje(stuValidacion.Mensaje);
                    return false;
                }
                
                stuValidacion = fncValidarDato(txtNombres.Text, "Olvidó colocar los nombres del docente", enm_G_TipoValidacionRegex.Letras);
                if (!stuValidacion.Validado)
                {
                    mtdMostrarMensaje(stuValidacion.Mensaje);
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

        private void frmAdministracionDocente_Load(object sender, EventArgs e)
        {
            try { mtd_ListarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            model_Idi_Docente = new model_Idi_Docente();
            mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
        }

        private void dgvDocente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                if (dgvDocente.SelectedRows.Count > 0) { mtd_ObtenerConvenioIndividual(); }
                else { btnNuevo.PerformClick(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            model_Idi_Docente = new model_Idi_Docente();
            mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarDocente())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        model_Idi_Docente.NumeroDocumento = txtDocumento.Text;
                        model_Idi_Docente.ApellidoMaterno = txtApellidoPaterno.Text;
                        model_Idi_Docente.ApellidoMaterno = txtApellidoMaterno.Text;
                        model_Idi_Docente.Nombres = txtNombres.Text;

                        if (model_Idi_Docente.IdIdi_Docente == 0)
                        {
                            Response<EsquemaRespuestaRegistro> registroIdi_Docente = controller_Idi_Docente.fncCON_RegistrarDocente(model_Idi_Docente);

                            if (!registroIdi_Docente.Success)
                            {
                                mtdMostrarMensaje(registroIdi_Docente.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            Response<bool> actualizacionIdi_Docente = controller_Idi_Docente.fncCON_ModificarDocente(model_Idi_Docente);

                            if (!actualizacionIdi_Docente.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_Docente.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                        mtd_ListarDocente();
                        btnNuevo.PerformClick();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarDocente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnSincronizarDocentes_Click(object sender, EventArgs e)
        {
            try
            {
                byte cantidadError = new byte();
                Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>> data_Idi_Docente = controller_Idi_Docente.fncCON_RelacionDocentesEnEscalafon_NoSincronizado();

                if (_validarRespuesta(data_Idi_Docente))
                {
                    List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento> lstDocenteNoSincronizado = data_Idi_Docente.Data;

                    foreach (model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento reg in lstDocenteNoSincronizado)
                    {
                        model_Idi_Docente _model_Idi_Docente = new model_Idi_Docente(idIdi_Docente: reg.IdIdi_Docente
                            , idEsc_TrabajadorDatosPersonales: reg.TrabajadorDatosPersonalesId
                            , numeroDocumento: reg.NumeroDocumentoIdentidad
                            , apellidoPaterno: reg.ApellidoPaterno
                            , apellidoMaterno: reg.ApellidoMaterno
                            , nombres: reg.Nombres);

                        Response<bool> actualizacionIdi_Docente = controller_Idi_Docente.fncCON_ModificarDocente(_model_Idi_Docente);

                        if (!actualizacionIdi_Docente.Success) { cantidadError++; }
                    }
                }

                if (cantidadError == 0) { mtdMostrarMensaje("Se sincronizó la información satisfactoriamente"); }
                else { mtdMostrarMensaje("Hubo un inconveniente al intentar sincronizar " + cantidadError + " docentes"); }

                mtd_ListarDocente();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionDocente_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}
