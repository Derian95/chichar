using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
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

namespace pry04.View.Idiomas_v2.Horario
{
    public partial class frmAdministracionAmbiente : Form
    {
        public frmAdministracionAmbiente() { InitializeComponent(); }

        private controller_Idi_Ambiente controller_Idi_Ambiente = new controller_Idi_Ambiente();
        private model_Idi_Ambiente model_Idi_Ambiente = new model_Idi_Ambiente();

        private List<model_dto_Ambiente> lstAmbiente = new List<model_dto_Ambiente>();
        private List<model_dto_Ambiente> lstFiltroAmbiente = new List<model_dto_Ambiente>();

        //Falta que cuando filtres y hagas doble click en algún registro filtrado, NO SE BUSQUE TODO NUEVAMENTE

        #region ========================================================= MÉTODOS =========================================================

        private void mtd_ObtenerAmbienteIndividual()
        {
            try
            {
                model_Idi_Ambiente = new model_Idi_Ambiente(idIdi_Ambiente: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvAmbiente.CurrentRow, "IdIdi_Ambiente"))
                    , codigo: mtdObtenerCeldaDataGridViewRow(dgvAmbiente.CurrentRow, "Codigo").ToString()
                    , descripcion: mtdObtenerCeldaDataGridViewRow(dgvAmbiente.CurrentRow, "Descripcion").ToString()
                    , tipo: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvAmbiente.CurrentRow, "Tipo"))
                    , capacidad: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvAmbiente.CurrentRow, "Capacidad")));

                txtCodigo.Text = model_Idi_Ambiente.Codigo;
                txtDescripcion.Text = model_Idi_Ambiente.Descripcion;
                cmbTipo.SelectedValue = Convert.ToInt64(model_Idi_Ambiente.Tipo);
                txtCapacidad.Text = model_Idi_Ambiente.Capacidad.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarTipoAula()
        {
            try
            {
                List<customComboBox> lstTipoAula = new List<customComboBox> { 
                    new customComboBox(1, "Laboratorio")
                    , new customComboBox(2, "Salón de clases")
                };

                mtdLlenarComboBoxManual(cmbTipo, lstTipoAula);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void mtd_ListarAmbiente()
        {
            try
            {
                Response<List<model_dto_Ambiente>> data_Idi_Ambiente = controller_Idi_Ambiente.fncCON_VisualListaAmbiente();
                if (_validarRespuesta(data_Idi_Ambiente))
                {
                    lstAmbiente = data_Idi_Ambiente.Data;
                    if (lstAmbiente.Count > 0)
                    {
                        dgvAmbiente.DataSource = lstAmbiente;
                        mtd_FiltrarAmbiente();
                        mtd_AjustarHorarioBase();
                    }
                    else
                    {
                        dgvAmbiente.DataSource = null;
                        mtdMostrarMensaje("No se encontraron ambientes");
                    }

                    dgvAmbiente.Refresh();
                    lblCantidadRegistros.Text = lstAmbiente.Count.ToString();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarAmbiente()
        {
            try
            {
                lstFiltroAmbiente = lstAmbiente;
                lstFiltroAmbiente = lstAmbiente.Where(c => c.Descripcion.ToUpper().Contains(txtFiltroNombre.Text.ToUpper())).ToList();

                dgvAmbiente.DataSource = lstFiltroAmbiente;

                dgvAmbiente.Refresh();
                lblCantidadRegistros.Text = lstFiltroAmbiente.Count.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarHorarioBase()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvAmbiente);

                List<string> lstColumnasOcultar = new List<string> { "_IdAula", "Tipo" };
                mtdFormatearDataGridView(dgvAmbiente, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Ambiente = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_Ambiente", "ID", width: 40)
                    , new customDataGridViewRow("Codigo", "CÓDIGO", width: 80)
                    , new customDataGridViewRow("NombreTipo", "TIPO", autoSize: true, width: 100)
                    , new customDataGridViewRow("Descripcion", "DESCRIPCIÓN", autoSize: true, width: 100)
                    , new customDataGridViewRow("Capacidad", "CAPACIDAD", width: 120)
                };
                mtdAjustarDataGridView(dgvAmbiente, lstAjuste_Ambiente);
                mtdSeleccionarRegistro(dgvAmbiente, "IdIdi_Ambiente");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion

        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtCapacidad.Text = "0";

                cmbTipo.SelectedValue = Convert.ToInt64(-1);

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

        #region ======================================================== FUNCIONES ========================================================
        private bool fncValidarAmbiente()
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    mtdMostrarMensaje("Olvidó ingresar el código del horario");
                    return false;
                }

                if (txtDescripcion.Text.Trim() == "")
                {
                    mtdMostrarMensaje("Es necesario que ingrese una descripción al ambiente");
                    return false;
                }

                if (Convert.ToInt64(cmbTipo.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Necesita seleccionar un tipo de ambiente");
                    return false;
                }

                //Crear forzar valores
                if (txtCapacidad.Text.Trim() == "")
                {
                    mtdMostrarMensaje("Ingrese la capacidad del ambiente");
                    return false;
                }
                else
                {
                    if (Convert.ToByte(txtCapacidad.Text) <= 0)
                    {
                        mtdMostrarMensaje("La capacidad del ambiente deberá ser mayor que 0");
                        return false;
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

        private void frmAdministracionAmbiente_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarTipoAula();
                mtd_ListarAmbiente();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarAmbiente(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvAmbiente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                if (dgvAmbiente.SelectedRows.Count > 0 && lstFiltroAmbiente.Count > 0) { mtd_ObtenerAmbienteIndividual(); }
                else { btnNuevo.PerformClick(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Ambiente = new model_Idi_Ambiente();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Ambiente = new model_Idi_Ambiente();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarAmbiente())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        model_Idi_Ambiente.Codigo = txtCodigo.Text;
                        model_Idi_Ambiente.Descripcion = txtDescripcion.Text;
                        model_Idi_Ambiente.Tipo = Convert.ToByte(cmbTipo.SelectedValue);
                        model_Idi_Ambiente.Capacidad = Convert.ToByte(txtCapacidad.Text);

                        if (model_Idi_Ambiente.IdIdi_Ambiente == 0)
                        {
                            Response<EsquemaRespuestaRegistro> registroIdi_Ambiente = controller_Idi_Ambiente.fncCON_RegistrarAmbiente(model_Idi_Ambiente);

                            if (!registroIdi_Ambiente.Success)
                            {
                                mtdMostrarMensaje(registroIdi_Ambiente.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            Response<bool> actualizacionIdi_Ambiente = controller_Idi_Ambiente.fncCON_ModificarAmbiente(model_Idi_Ambiente);

                            if (!actualizacionIdi_Ambiente.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_Ambiente.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar); 
                        mtd_ListarAmbiente();
                        btnNuevo.PerformClick();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionAmbiente_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}
