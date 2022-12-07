using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Globalization;

using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEnumerable;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.Semestre
{
    public partial class frmAdministracionSemestre: Form
    {
        private controller_Idi_Semestre controller_Idi_Semestre = new controller_Idi_Semestre();
        private controller_SEMESTRE controller_SEMESTRE = new controller_SEMESTRE();

        //Generar Anios y Meses permitidos para registrar y adaptarlo
        private List<model_dto_Semestre> lstSemestre = new List<model_dto_Semestre>();
        private model_Idi_Semestre model_Idi_Semestre = new model_Idi_Semestre();
        private model_SEMESTRE model_SEMESTRE = new model_SEMESTRE();

        public EsquemaCronograma env_stuCronogramaSeleccionado = new EsquemaCronograma();

        public frmAdministracionSemestre() { InitializeComponent(); }

        #region ========================================================= MÉTODOS =========================================================

        private void mtd_ObtenerSemestreIndividual()
        {
            try
            {
                model_SEMESTRE = new model_SEMESTRE(idSemestre: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "_IdSem")));

                model_Idi_Semestre = new model_Idi_Semestre(
                    idIdi_Semestre: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "IdIdi_Semestre"))
                    , anio: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Anio"))
                    , mes: Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Mes"))
                    , semestre: mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Semestre").ToString()
                    , inicioClases: Convert.ToDateTime(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "InicioClases"))
                    , idSem: Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "_IdSem")));

                mtd_CargarAnioInfo();

                cmbAnioInfo.SelectedValue = Convert.ToInt64(model_Idi_Semestre.Anio);

                cmbMesInfo.Enabled = true;

                mtd_CargarMes(model_Idi_Semestre.Anio);

                cmbMesInfo.SelectedValue = Convert.ToInt64(model_Idi_Semestre.Mes);

                dtpInicioClases.Value = model_Idi_Semestre.InicioClases;
                txtSemestre.Text = model_Idi_Semestre.Semestre;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                cmbAnioInfo.SelectedValue = Convert.ToInt64(-1);
                cmbMesInfo.SelectedValue = Convert.ToInt64(-1);
                dtpInicioClases.Value = DateTime.Now;
                txtSemestre.Text = "";

                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        pnlInformacion.Enabled = false;
                        
                        btnGuardar.Text = "   Guardar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnCancelar.Enabled = false;
                        break;
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                        pnlInformacion.Enabled = true;
                        
                        btnGuardar.Text = "   Guardar";
                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        break;
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        pnlInformacion.Enabled = true; 
                        
                        btnGuardar.Text = "   Modificar";
                        btnNuevo.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }


        private void mtd_CargarMes(short anio)
        {
            List<short> lstMostrar = new List<short>();
            List<customComboBox> lstMesCombo = new List<customComboBox>();
            try
            {
                //Validar luego si existe en combo en vez del año actual
                cmbAnio.SelectedValue = anio > DateTime.Now.Date.Year? Convert.ToInt64(DateTime.Now.Date.Year): Convert.ToInt64(anio);
                mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue));

                if (model_Idi_Semestre.IdIdi_Semestre == 0)
                {
                    List<short> lstMes = _obtenerListaIdMes();
                    List<short> lstSemestreMes = new List<short>();

                    Response<List<model_dto_Semestre>> data_Idi_Semestre = controller_Idi_Semestre.fncCON_VisualListaSemestre(anio);
                    foreach (model_dto_Semestre reg in data_Idi_Semestre.Data) { lstSemestreMes.Add(Convert.ToInt16(reg.Mes)); }

                    lstMostrar = lstMes.Except(lstSemestreMes).ToList();

                } else { lstMostrar = new List<short> { model_Idi_Semestre.Mes }; }

                foreach (short reg in lstMostrar)
                {
                    lstMesCombo.Add(new customComboBox(reg
                        , _getCustomPropertyEnum<customDescripcion>((enm_G_MesAnio)reg).Descripcion)
                    );
                }

                mtdLlenarComboBoxManual(cmbMesInfo, lstMesCombo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_CargarAnioInfo()
        {
            try
            {
                int AnioInfoHasta = model_Idi_Semestre.IdIdi_Semestre == 0 ? DateTime.Now.Year + 1: model_Idi_Semestre.Anio;
                int AnioInfoDesde = model_Idi_Semestre.IdIdi_Semestre == 0 ? DateTime.Now.Year: model_Idi_Semestre.Anio;

                List<customComboBox> lstAnioInfo = new List<customComboBox>();

                for (int iAnio = AnioInfoHasta; iAnio >= AnioInfoDesde; iAnio--) { lstAnioInfo.Add(new customComboBox(iAnio, iAnio.ToString())); }
                mtdLlenarComboBoxManual(cmbAnioInfo, lstAnioInfo, (model_Idi_Semestre.IdIdi_Semestre == 0 ? true : false));
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

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
                //Verificar si no es necesario "seleccionar" uno por default, para pasar el error del doble click en la cabecera del dgv
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
                    lstSemestre = controller_Idi_Semestre.fncCON_VisualListaSemestre(anio).Data;
                    dgvSemestre.DataSource = lstSemestre;
                    mtd_AjustarSemestre();

                    dgvSemestre.Refresh();
                    lblCantidadRegistros.Text = lstSemestre.Count.ToString();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion



        #region ======================================================== FUNCIONES ========================================================
        private string fncGenerarSemestreMesAnio()
        {
            string resultado = "";
            try { resultado = cmbAnioInfo.Text + "-" + _obtenerRomanoFromEntero(Convert.ToInt32(cmbMesInfo.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return resultado;
        }
        private bool fncValidaSemestre()
        {
            try
            {
                if (Convert.ToInt64(cmbAnioInfo.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Tiene que seleccionar el año para la creación del semestre");
                    return false;
                }

                if (Convert.ToInt64(cmbMesInfo.SelectedValue) == -1)
                {
                    mtdMostrarMensaje("Tiene que seleccionar el mes para la creación del semestre");
                    return false;
                }

                if (dtpInicioClases.Value.Year != Convert.ToInt32(cmbAnioInfo.SelectedValue))
                {
                    mtdMostrarMensaje("El año de inicio de clases deberá ser el mismo que seleccionó");
                    return false;
                }

                if (dtpInicioClases.Value.Month != Convert.ToInt32(cmbMesInfo.SelectedValue))
                {
                    mtdMostrarMensaje("El mes de inicio de clases deberá ser el mismo que ha seleccionado");
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



        private void frmAdministracionSemestre_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_CargarAnioBusqueda();
                mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue));
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try { mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_Semestre = new model_Idi_Semestre();
                model_SEMESTRE = new model_SEMESTRE();

                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
                mtd_CargarAnioInfo();
                
                cmbMesInfo.Enabled = false;
                dtpInicioClases.Value = DateTime.Now;
                txtSemestre.Text = "";
                    
                //mtd_HabilitarPanelInformacion();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbAnioInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbMesInfo.Enabled = true;
                mtd_CargarMes(Convert.ToInt16(cmbAnioInfo.SelectedValue));
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                model_SEMESTRE = new model_SEMESTRE();
                model_Idi_Semestre = new model_Idi_Semestre();

                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue));
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidaSemestre())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        if (model_Idi_Semestre.IdIdi_Semestre == 0)
                        {
                            int _ordenSemestre = new int();
                            int _idModalidadSemestre = new int();
                            int _idSem = new int();

                            Response<int> data_SEMESTRE = controller_SEMESTRE.fncCON_encontrarMaximoOrdenSEMESTRE();
                            Response<List<model_Usp_Idi_S_ObtenerModalidadSemestre>> data_ModalidadSemestre = controller_SEMESTRE.fncCON_ObtenerModalidadSemestre(
                                _obtenerRomanoFromEntero(Convert.ToInt32(cmbMesInfo.SelectedValue))
                                , Convert.ToInt32(enm_G_ClaseSemestre.Regular)
                            );
                            Response<List<model_Usp_Idi_S_ObtenerMaximoIdSem>> dataMaximoIdSem = controller_SEMESTRE.fncCON_ObtenerMaximoIdSem(
                                Convert.ToInt16(cmbAnioInfo.SelectedValue)
                                , Convert.ToByte(cmbMesInfo.SelectedValue)
                            );

                            if (data_SEMESTRE.Success && _validarRespuesta(data_ModalidadSemestre) && _validarRespuesta(dataMaximoIdSem))
                            {
                                _ordenSemestre = data_SEMESTRE.Data;
                                _idModalidadSemestre = data_ModalidadSemestre.Data[0].IdmodalidadSem;
                                _idSem = dataMaximoIdSem.Data[0].IdSem;

                                model_SEMESTRE = new model_SEMESTRE(idSemestre: _idSem
                                    , semestre: txtSemestre.Text
                                    , inicioClases: dtpInicioClases.Value
                                    , observacion: "CICLO IDIOMAS UPT"
                                    , descripcion: txtSemestre.Text);

                                model_SEMESTRE.Orden = _ordenSemestre;
                                model_SEMESTRE.IdModalidadSemestre = _idModalidadSemestre;

                                Response<EsquemaRespuestaRegistro> registroSEMESTRE = controller_SEMESTRE.fncCON_RegistrarSEMESTRE(model_SEMESTRE);

                                if (registroSEMESTRE.Success)
                                {
                                    model_Idi_Semestre = new model_Idi_Semestre(anio: Convert.ToInt16(cmbAnioInfo.SelectedValue)
                                    , mes: Convert.ToByte(cmbMesInfo.SelectedValue)
                                    , semestre: txtSemestre.Text
                                    , inicioClases: dtpInicioClases.Value
                                    , idSem: Convert.ToInt32(registroSEMESTRE.Data.Identificador));

                                    Response<EsquemaRespuestaRegistro> registroIdi_Semestre = controller_Idi_Semestre.fncCON_RegistrarSemestre(model_Idi_Semestre);

                                    if (!registroIdi_Semestre.Success)
                                    {
                                        mtdMostrarMensaje(registroIdi_Semestre.MensajeError.ToList()[0].Mensaje);
                                        actualizacionExitosa = false;
                                    }
                                }
                                else
                                {
                                    mtdMostrarMensaje(registroSEMESTRE.MensajeError.ToList()[0].Mensaje);
                                    actualizacionExitosa = false;
                                }
                            }
                            else
                            {
                                mtdMostrarMensaje(
                                    (data_SEMESTRE.MensajeError.Count > 0? data_SEMESTRE.MensajeError.ToList()[0].Mensaje: "")
                                    + (data_ModalidadSemestre.MensajeError.Count > 0? data_ModalidadSemestre.MensajeError.ToList()[0].Mensaje: "")
                                    + (dataMaximoIdSem.MensajeError.Count > 0? dataMaximoIdSem.MensajeError.ToList()[0].Mensaje: "")
                                );
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            model_SEMESTRE.InicioClases = dtpInicioClases.Value;
                            model_Idi_Semestre.InicioClases = dtpInicioClases.Value;

                            Response<bool> actualizacionSEMESTRE = controller_SEMESTRE.fncCON_ModificarSEMESTRE(model_SEMESTRE);

                            if (actualizacionSEMESTRE.Success)
                            {
                                Response<bool> actualizacionIdi_Semestre = controller_Idi_Semestre.fncCON_ModificarSemestre(model_Idi_Semestre);
                                if (!actualizacionIdi_Semestre.Success)
                                {
                                    mtdMostrarMensaje(actualizacionIdi_Semestre.MensajeError.ToList()[0].Mensaje);
                                    actualizacionExitosa = false;
                                }
                            }
                            else
                            {
                                mtdMostrarMensaje(actualizacionSEMESTRE.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Ninguno); 
                        
                        mtd_CargarAnioBusqueda();
                        mtd_ListarSemestre(Convert.ToInt16(cmbAnio.SelectedValue));
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void cmbMesInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dtpInicioClases.Value = new DateTime(Convert.ToInt32(cmbAnioInfo.SelectedValue)
                    , (Convert.ToSByte(cmbMesInfo.SelectedValue) == -1)? DateTime.Now.Month: Convert.ToSByte(cmbMesInfo.SelectedValue)
                    , DateTime.Now.Day);
                txtSemestre.Text = fncGenerarSemestreMesAnio();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvSemestre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                mtd_ObtenerSemestreIndividual();
            }
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
                        env_stuCronogramaSeleccionado = new EsquemaCronograma(
                            Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "_IdSem"))
                            , Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "IdIdi_Semestre"))
                            , Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Anio"))
                            , Convert.ToByte(mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Mes"))
                            , mtdObtenerCeldaDataGridViewRow(dgvSemestre.CurrentRow, "Semestre").ToString());
                        
                        DialogResult = DialogResult.OK;
                        Close();
                    } else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}