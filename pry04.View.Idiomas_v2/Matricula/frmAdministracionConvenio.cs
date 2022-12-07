using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry03.Controller.Idiomas_v2;

using pry04.View.Idiomas_v2.Principal;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.Matricula
{
    public partial class frmAdministracionConvenio : Form
    {
        public frmAdministracionConvenio() { InitializeComponent(); }

        private controller_Idi_Convenio controller_Idi_Convenio = new controller_Idi_Convenio();
        private controller_Idi_EntidadConvenio controller_Idi_EntidadConvenio = new controller_Idi_EntidadConvenio();

        private model_Idi_Convenio model_Idi_Convenio = new model_Idi_Convenio();

        private List<model_dto_Convenio> lstConvenio = new List<model_dto_Convenio>();

        private List<model_dto_EntidadConvenio> lstEntidad = new List<model_dto_EntidadConvenio>();


        #region ========================================================= MÉTODOS =========================================================
        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                cmbEntidad.SelectedValue = Convert.ToInt64(-1);

                txtPension.Text = "0";
                txtDocumento .Text = "";
                dtpDesde.Value = DateTime.Now;
                dtpHasta.Value = DateTime.Now;

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

        private void mtd_AjustarConvenio()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvConvenio);

                List<string> lstColumnasOcultar = new List<string> { "IdIdi_EntidadConvenio" };
                mtdFormatearDataGridView(dgvConvenio, lstColumnasOcultar);

                List<string> lstColumnasDecimal = new List<string> { "Pension" };
                mtdFormatearDataGridView(dgvConvenio, lstColumnasDecimal, enm_G_TipoFormatoDataGridView.Decimal);

                List<customDataGridViewRow> lstAjuste_Convenio = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Convenio", "ID", width: 40)
                    , new customDataGridViewRow("EntidadConvenio", "ENTIDAD"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 280)
                    , new customDataGridViewRow("Documento", "DOCUMENTO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 180)
                    , new customDataGridViewRow("Pension", "PENSIÓN", width: 80)
                    , new customDataGridViewRow("FechaInicio", "DESDE", width: 80)
                    , new customDataGridViewRow("FechaFin", "HASTA", width: 80)
                };
                mtdAjustarDataGridView(dgvConvenio, lstAjuste_Convenio);
                mtdSeleccionarRegistro(dgvConvenio, "IdIdi_Convenio");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarEntidad()
        {
            List<customComboBox> lstComboEntidad = new List<customComboBox>();
            try
            {
                Response<List<model_dto_EntidadConvenio>> data_Idi_EntidadConvenio = controller_Idi_EntidadConvenio.fncCON_VisualListaEntidadConvenio();
                if (_validarRespuesta(data_Idi_EntidadConvenio))
                {
                    lstEntidad = data_Idi_EntidadConvenio.Data;
                    foreach (model_dto_EntidadConvenio reg in lstEntidad)
                    { lstComboEntidad.Add(new customComboBox(Convert.ToInt64(reg.IdIdi_EntidadConvenio), reg.Nombre)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbEntidad, objComboContenido: lstComboEntidad);
                } else { mtdLimpiarComboBox(cmbEntidad); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarConvenio()
        {
            try
            {
                lstConvenio = controller_Idi_Convenio.fncCON_VisualListaConvenio().Data;
                if (lstConvenio.Count > 0)
                {
                    dgvConvenio.DataSource = lstConvenio;
                    mtd_AjustarConvenio();
                }
                else
                {
                    dgvConvenio.DataSource = null;
                    mtdMostrarMensaje("No se encontraron convenios");
                }

                dgvConvenio.Refresh();
                lblCantidadRegistros.Text = lstConvenio.Count.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerConvenioIndividual()
        {
            try
            {
                model_Idi_Convenio = new model_Idi_Convenio(idIdi_Convenio: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "IdIdi_Convenio"))
                    , idIdi_EntidadConvenio: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "IdIdi_EntidadConvenio"))
                    , documento: mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "Documento").ToString()
                    , pension: Convert.ToDecimal(mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "Pension"))
                    , fechaInicio: Convert.ToDateTime(mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "FechaInicio"))
                    , fechaFin: Convert.ToDateTime(mtdObtenerCeldaDataGridViewRow(dgvConvenio.CurrentRow, "FechaFin")));

                cmbEntidad.SelectedValue = Convert.ToInt64(model_Idi_Convenio.IdIdi_EntidadConvenio);
                txtDocumento.Text = model_Idi_Convenio.Documento;
                txtPension.Text = model_Idi_Convenio.Pension.ToString();
                dtpDesde.Value = model_Idi_Convenio.FechaInicio;
                dtpHasta.Value = model_Idi_Convenio.FechaFin;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion

        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarConvenio()
        {
            try
            {
                if (Convert.ToInt64(cmbEntidad.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Es necesario seleccionar una entidad para el convenio");
                    return false;
                }
                
                if (txtDocumento.Text.Trim() == "")
                {
                    mtdMostrarMensaje("Olvidó ingresar el documento");
                    return false;
                }

                if (txtPension.Text.Trim() == "" || _obtenerDecimal(txtPension.Text) <= 0 )
                {
                    mtdMostrarMensaje("Es necesario que ingrese correctamente el valor de la pensión");
                    return false;
                }

                if (dtpDesde.Value > dtpHasta.Value)
                {
                    mtdMostrarMensaje("Necesita ingresar correctamente el rango de fechas válidas para el convenio");
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

        private void frmAdministracionConvenio_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarEntidad();
                mtd_ListarConvenio();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvConvenio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                if (dgvConvenio.SelectedRows.Count > 0) { mtd_ObtenerConvenioIndividual(); }
                else { btnNuevo.PerformClick(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Convenio = new model_Idi_Convenio();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Convenio = new model_Idi_Convenio();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionConvenio_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarConvenio())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        model_Idi_Convenio.IdIdi_EntidadConvenio = Convert.ToInt16(cmbEntidad.SelectedValue);
                        model_Idi_Convenio.Documento = txtDocumento.Text;
                        model_Idi_Convenio.Pension = _obtenerDecimal(txtPension.Text);
                        model_Idi_Convenio.FechaInicio = dtpDesde.Value;
                        model_Idi_Convenio.FechaFin = dtpHasta.Value;

                        if (model_Idi_Convenio.IdIdi_Convenio == 0)
                        {
                            Response<EsquemaRespuestaRegistro> registroIdi_Convenio = controller_Idi_Convenio.fncCON_RegistrarConvenio(model_Idi_Convenio);

                            if (!registroIdi_Convenio.Success)
                            {
                                mtdMostrarMensaje(registroIdi_Convenio.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            Response<bool> actualizacionIdi_Convenio = controller_Idi_Convenio.fncCON_ModificarConvenio(model_Idi_Convenio);

                            if (!actualizacionIdi_Convenio.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_Convenio.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                        mtd_ListarConvenio();
                        btnNuevo.PerformClick();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
