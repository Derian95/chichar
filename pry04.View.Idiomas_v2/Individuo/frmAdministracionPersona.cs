using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry02.Model.Idiomas_v2.ServiciosWeb;
using pry03.Controller.Idiomas_v2;

using pry04.View.Idiomas_v2.Principal;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;
using static pry100.Utilitario.Idiomas_v2.Clases.clsComboBox;

namespace pry04.View.Idiomas_v2.Individuo
{
    public partial class frmAdministracionPersona : Form
    {
        public frmAdministracionPersona() { InitializeComponent(); }

        #region DATOS RECIBIDOS
        int rec_CodigoPersona = new int();
        #endregion

        private controller_PERSONA controller_PERSONA = new controller_PERSONA();
        private controller_Ad_LugarNacimiento controller_Ad_LugarNacimiento = new controller_Ad_LugarNacimiento();
        private controller_WS_RENIEC controller_WS_RENIEC = new controller_WS_RENIEC();

        private model_PERSONA model_PERSONA = new model_PERSONA();
        private model_Ad_LugarNacimiento model_Ad_LugarNacimiento = new model_Ad_LugarNacimiento();

        private List<model_Usp_Adm_S_ListarNacionalidades> lstPais = new List<model_Usp_Adm_S_ListarNacionalidades>();
        private List<model_ciudad> lstDepartamento = new List<model_ciudad>();
        private List<model_Usp_Adm_S_ListarProvincias> lstProvincia = new List<model_Usp_Adm_S_ListarProvincias>();
        private List<model_Usp_Adm_S_ListarDistritos> lstDistrito = new List<model_Usp_Adm_S_ListarDistritos>();

        private List<EsquemaError> lstError = new List<EsquemaError>();

        enm_G_ValidacionRENIEC enmValidacionRENIEC = new enm_G_ValidacionRENIEC();

        #region ========================================================= MÉTODOS =========================================================

        private void mtd_ReemplazarDatosPersona(DataGridView control)
        {
            try
            {
                if (control.Rows.Count > 0)
                {
                    if (control.SelectedRows.Count > 0)
                    {
                        if (MessageBox.Show("Este mecanismo reemplazará los datos de la persona con el registro que seleccionó ¿Está seguro de continuar?"
                            , Constantes.TextoMessageBoxQuestion
                            , MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rec_CodigoPersona = Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(control.CurrentRow, "CodPer"));

                            if (rec_CodigoPersona > 0)
                            {
                                mtd_ObtenerDatosPersonaIndividual(rec_CodigoPersona);
                                mtd_MostrarPanelCoindicenciaDatosPersona(false);
                            }
                            else
                            {
                                model_PERSONA = new model_PERSONA();
                                mtd_RestaurarFormulario();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ValidarRENIEC(string dni)
        {
            bool consultar = new bool();
            try
            {
                mtd_MostrarPanelValidacionRENIEC(true);

                List<model_PERSONA> lstPERSONAUPT = new List<model_PERSONA> { new model_PERSONA(codigoPersona: model_PERSONA.CodigoPersona
                    , apellidoPaterno: model_PERSONA.ApellidoPaterno
                    , apellidoMaterno: model_PERSONA.ApellidoMaterno
                    , nombre: model_PERSONA.Nombre
                    , numeroDocumento: model_PERSONA.NumeroDocumento
                    , sexo: model_PERSONA.Sexo) };
                lstPERSONAUPT[0].FechaNacimiento = model_PERSONA.FechaNacimiento;

                List<model_PERSONA> lstPERSONARENIEC = new List<model_PERSONA>();

                dgvDatosRENIEC.DataSource = null;
                dgvDatosUPT.DataSource = null;
                lblEstadoConsultaRENIEC.Text = "Procesando...";

                consultar = model_PERSONA.TipoDocumento == Convert.ToByte(enm_G_TipoDocumento.DNI) ? true : false;
                
                if (model_PERSONA.FechaNacimiento.Value <= DateTime.Today.AddYears(-18)) { consultar = true; }
                else
                {
                    consultar = false;
                    enmValidacionRENIEC = enm_G_ValidacionRENIEC.MenorEdad;
                }

                if (consultar)
                {
                    txtDNIRENIEC.Text = dni;
                    Response<SW_RENIECResult> data_ResultRENIEC = controller_WS_RENIEC.fncCON_ConsultarDNI(dni);
                    
                    if (_validarRespuesta(data_ResultRENIEC))
                    {
                        string _sexo = data_ResultRENIEC.Data.Genero == "MASCULINO" ? "M" : data_ResultRENIEC.Data.Genero == "FEMENINO" ? "F" : "";

                        lstPERSONARENIEC.Add(new model_PERSONA(apellidoPaterno: data_ResultRENIEC.Data.ApellidoPaterno
                            , apellidoMaterno: data_ResultRENIEC.Data.ApellidoMaterno
                            , nombre: data_ResultRENIEC.Data.Nombres
                            , numeroDocumento: data_ResultRENIEC.Data.NumeroDocumento
                            , sexo: _sexo));                        
                        lstPERSONARENIEC[0].FechaNacimiento = data_ResultRENIEC.Data.FechaNacimiento;
                        
                        dgvDatosRENIEC.DataSource = lstPERSONARENIEC;
                        mtd_AjustarRegistroPersona(dgvDatosRENIEC);

                        if (model_PERSONA.NumeroDocumento == data_ResultRENIEC.Data.NumeroDocumento
                            && model_PERSONA.ApellidoPaterno.ToUpper() == data_ResultRENIEC.Data.ApellidoPaterno.ToUpper()
                            && model_PERSONA.ApellidoMaterno.ToUpper() == data_ResultRENIEC.Data.ApellidoMaterno.ToUpper()
                            && model_PERSONA.Nombre.ToUpper() == data_ResultRENIEC.Data.Nombres.ToUpper()
                            && model_PERSONA.FechaNacimiento == data_ResultRENIEC.Data.FechaNacimiento
                            && model_PERSONA.Sexo == _sexo)
                        { enmValidacionRENIEC = enm_G_ValidacionRENIEC.DatosIdenticos; }
                        else { enmValidacionRENIEC = enm_G_ValidacionRENIEC.DatosCorregidos; }

                        model_PERSONA.NumeroDocumento = data_ResultRENIEC.Data.NumeroDocumento;
                        model_PERSONA.ApellidoPaterno = data_ResultRENIEC.Data.ApellidoPaterno;
                        model_PERSONA.ApellidoMaterno = data_ResultRENIEC.Data.ApellidoMaterno;
                        model_PERSONA.Nombre = data_ResultRENIEC.Data.Nombres;
                        model_PERSONA.Sexo = _sexo;
                        model_PERSONA.FechaNacimiento = data_ResultRENIEC.Data.FechaNacimiento;

                        txtNroDocumento.Text = model_PERSONA.NumeroDocumento;
                        txtApellidoPaterno.Text = model_PERSONA.ApellidoPaterno;
                        txtApellidoMaterno.Text = model_PERSONA.ApellidoMaterno;
                        txtNombres.Text = model_PERSONA.Nombre;
                        rbtMasculino.Checked = model_PERSONA.Sexo == "M" ? true : false;
                        rbtFemenino.Checked = model_PERSONA.Sexo == "F" ? true : false;
                        dtpFechaNacimiento.Value = Convert.ToDateTime(model_PERSONA.FechaNacimiento);
                    }
                    else
                    {
                        dgvDatosRENIEC.DataSource = null;
                        enmValidacionRENIEC = enm_G_ValidacionRENIEC.SinResultado;
                        mtdMostrarMensaje(data_ResultRENIEC.MensajeError.ToList()[0].Mensaje);
                    }
                }
                else { mtdMostrarMensaje("No se utilizará el servidor RENIEC, válido solo para mayores de edad y/o con DNI"); }

                lblEstadoConsultaRENIEC.Text = _obtenerEstadoValidacionRENIEC(enmValidacionRENIEC);
                dgvDatosUPT.DataSource = lstPERSONAUPT;
                mtd_AjustarRegistroPersona(dgvDatosUPT);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_MostrarPanelCoindicenciaDatosPersona(bool mostrar)
        {
            try
            {
                pnlCoincidencia.Visible = mostrar;
                pnlCoincidencia.Enabled = mostrar;
                pnlDatosPersonales.Enabled = !mostrar;
                pnlUbigeo.Enabled = !mostrar;
                mtdMostrarCentrado(pnlPrincipal, pnlCoincidencia);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_MostrarPanelError(bool mostrar)
        {
            try
            {
                pnlError.Height = 114;
                pnlError.Visible = mostrar;

                pnlDatosPersonales.Enabled = !mostrar;
                pnlUbigeo.Enabled = !mostrar;

                if (lstError.Count > 2) { pnlError.Height = pnlError.Height + ((lstError.Count - 2) * 25); }

                mtdMostrarCentrado(pnlPrincipal, pnlError);

                dgvError.DataSource = lstError;
                mtd_AjustarErrores();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_MostrarPanelValidacionRENIEC(bool mostrar)
        {
            try
            {
                txtDNIRENIEC.Text = "";
                pnlRENIEC.Visible = mostrar;
                pnlRENIEC.Enabled = mostrar;
                pnlDatosPersonales.Enabled = !mostrar;
                pnlUbigeo.Enabled = !mostrar;
                mtdMostrarCentrado(pnlPrincipal, pnlRENIEC);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarErrores()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvError);
                List<customDataGridViewRow> lstAjuste = new List<customDataGridViewRow> {
                    new customDataGridViewRow("Valor", "VALOR"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 200)
                    , new customDataGridViewRow("Observacion", "OBSERVACIÓN"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 400)
                };

                mtdAjustarDataGridView(dgvError, lstAjuste);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarRegistroPersona(DataGridView target)
        {
            try
            {
                mtdNoOrdenarDataGridView(target);
                List<string> lstColumnasOcultar = new List<string> { "CodEstamento", "Estamento", "CodLugNac", "RucPer", "LmPer", "Direccion"
                    , "TelefFijo", "TelefCelular", "Usuario", "Fecha", "Email", "GrupoSang", "IndMedica", "Activo", "EstadoCivil", "TipoDocum"
                    , "DescripcionTipoDocumento", "perobs", "LugNac", "Foto" };

                mtdFormatearDataGridView(target, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste = new List<customDataGridViewRow> {
                    new customDataGridViewRow("CodPer", "ID", width: 60)
                    , new customDataGridViewRow("DniPer", "DOC", width: 70)
                    , new customDataGridViewRow("ApepPer", "A. PATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 100)
                    , new customDataGridViewRow("ApemPer", "A. MATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 100)
                    , new customDataGridViewRow("NomPer", "NOMBRES"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left, width: 140)
                    , new customDataGridViewRow("FechaNac", "F. NAC.", width: 100)
                    , new customDataGridViewRow("Sexo", "SEXO", width: 50)
                };

                mtdAjustarDataGridView(target, lstAjuste);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarUBIGEOPais()
        {
            List<customComboBox> lstComboPais = new List<customComboBox>();
            try
            {
                Response<List<model_Usp_Adm_S_ListarNacionalidades>> data_Nacionalidad = controller_PERSONA.fncCON_ListaNacionalidad();
                if (_validarRespuesta(data_Nacionalidad))
                {
                    lstPais = data_Nacionalidad.Data;
                    foreach (model_Usp_Adm_S_ListarNacionalidades reg in lstPais) { lstComboPais.Add(new customComboBox(Convert.ToInt64(reg.CodNac), reg.Descripcion)); }
                    mtdLlenarComboBoxManual(cmbPais, lstComboPais);
                }
                else { mtdMostrarMensaje(data_Nacionalidad.MensajeError.ToList()[0].Mensaje); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarUBIGEODepartamento(short idNacionalidad, short idDepartamento = -1)
        {
            lstDepartamento = new List<model_ciudad>();
            List<customComboBox> lstComboDepartamento = new List<customComboBox>();
            short _idDepartamento = idDepartamento >= 1 && idDepartamento <= 25 ? Convert.ToInt16(idDepartamento + 2896) : idDepartamento;
            try
            {
                Response<List<model_ciudad>> data_Departamento = controller_PERSONA.fncCON_Lista_ciudad(idNacionalidad);
                if (_validarRespuesta(data_Departamento))
                {
                    lstDepartamento = data_Departamento.Data;
                    foreach (model_ciudad reg in lstDepartamento) { lstComboDepartamento.Add(new customComboBox(Convert.ToInt64(reg.CodigoCiudad), reg.Descripcion)); }

                    mtdLlenarComboBoxManual(controlComboBox: cmbDepartamento
                        , objComboContenido: lstComboDepartamento
                        , seleccionar: true
                        , valorSeleccion: _idDepartamento);
                }
                else { mtdLimpiarComboBox(cmbDepartamento); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarUBIGEOProvincia(short idDepartamento, short idProvincia = -1)
        {
            lstProvincia = new List<model_Usp_Adm_S_ListarProvincias>();
            List<customComboBox> lstComboProvincia = new List<customComboBox>();
            short _idDepartamento = idDepartamento >= 2897 && idDepartamento <= 2921 ? Convert.ToInt16(idDepartamento - 2896) : idDepartamento;
            try
            {
                Response<List<model_Usp_Adm_S_ListarProvincias>> data_Provincia = controller_PERSONA.fncCON_ListaProvincia(_idDepartamento);
                if (_validarRespuesta(data_Provincia))
                {
                    lstProvincia = data_Provincia.Data;
                    foreach (model_Usp_Adm_S_ListarProvincias reg in lstProvincia) { lstComboProvincia.Add(new customComboBox(Convert.ToInt64(reg.CodProv), reg.Descripcion)); }
                    mtdLlenarComboBoxManual(controlComboBox: cmbProvincia
                        , objComboContenido: lstComboProvincia
                        , seleccionar: true
                        , valorSeleccion: idProvincia);
                }
                else { mtdLimpiarComboBox(cmbProvincia); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarUBIGEODistrito(short idProvincia, int idDistrito = -1)
        {
            lstDistrito = new List<model_Usp_Adm_S_ListarDistritos>();
            List<customComboBox> lstComboDistrito = new List<customComboBox>();
            try
            {
                Response<List<model_Usp_Adm_S_ListarDistritos>> data_Distrito = controller_PERSONA.fncCON_ListaDistrito(idProvincia);
                if (_validarRespuesta(data_Distrito))
                {
                    lstDistrito = data_Distrito.Data;
                    foreach (model_Usp_Adm_S_ListarDistritos reg in lstDistrito) { lstComboDistrito.Add(new customComboBox(Convert.ToInt64(reg.CodDist), reg.Descripcion)); }
                    mtdLlenarComboBoxManual(controlComboBox: cmbDistrito
                        , objComboContenido: lstComboDistrito
                        , seleccionar: true
                        , valorSeleccion: idDistrito);
                }
                else { mtdLimpiarComboBox(cmbDistrito); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ObtenerDatosPersonaIndividual(int codigoPersona)
        {
            try
            {
                Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> data_PERSONA = controller_PERSONA.fncCON_RelacionPersonas(codigoPersona: codigoPersona);
                Response<List<model_Ad_LugarNacimiento>> data_UBIGEO = controller_Ad_LugarNacimiento.fncCON_ListaLugarNacimientoPersona(codigoPersona: codigoPersona);

                if (_validarRespuesta(data_PERSONA))
                {
                    mtd_LlenarDatosPersona(data_PERSONA.Data[0]);
                    if (_validarRespuesta(data_UBIGEO))
                    {
                        if (data_UBIGEO.Data.Count == 1) { mtd_LlenarDatosUBIGEO(data_UBIGEO.Data[0]); }
                        else { mtdMostrarMensaje("Se encontró mas de un registro de UBIGEO, comuníquese con su administrador"); }
                    }
                    else { model_Ad_LugarNacimiento = new model_Ad_LugarNacimiento(codigoPersona: data_PERSONA.Data[0].CodPer, estado: 1); }
                }
                else { mtdMostrarMensaje(data_PERSONA.MensajeError.ToList()[0].Mensaje); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }


        private void mtd_LlenarDatosPersona(model_Usp_Idi_S_ListarPersonaParaIdiomas target)
        {
            try
            {
                model_PERSONA = new model_PERSONA(target.CodPer
                    , target.ApepPer
                    , target.ApemPer
                    , target.NomPer
                    , target.DniPer
                    , target.Direccion
                    , target.TelefFijo
                    , target.TelefCelular
                    , target.Sexo
                    , target.Usuario
                    , target.Fecha
                    , target.Email);

                model_PERSONA.CodigoEstamento = target.CodEstamento;
                model_PERSONA.FechaNacimiento = target.FechaNac;
                model_PERSONA.CodigoLugarNacimiento = target.CodLugNac;
                model_PERSONA.Activo = target.Activo;
                model_PERSONA.TipoDocumento = target.TipoDocum;

                cmbTipoDocumento.SelectedValue = Convert.ToInt64(model_PERSONA.TipoDocumento);

                rbtMasculino.Checked = model_PERSONA.Sexo == "M" ? true : false;
                rbtFemenino.Checked = model_PERSONA.Sexo == "F" ? true : false;
                txtNroDocumento.Text = model_PERSONA.NumeroDocumento;
                txtApellidoPaterno.Text = model_PERSONA.ApellidoPaterno;
                txtApellidoMaterno.Text = model_PERSONA.ApellidoMaterno;
                txtNombres.Text = model_PERSONA.Nombre;
                dtpFechaNacimiento.Value = Convert.ToDateTime(model_PERSONA.FechaNacimiento);

                if (model_PERSONA.Sexo == "M" || model_PERSONA.Sexo == "F")
                {
                    rbtMasculino.Enabled = false;
                    rbtFemenino.Enabled = false;
                }
                else
                {
                    rbtMasculino.Enabled = true;
                    rbtFemenino.Enabled = true;
                }

                txtNroDocumento.Enabled = model_PERSONA.NumeroDocumento.Trim() != "" ? false : true;
                txtApellidoPaterno.Enabled = model_PERSONA.ApellidoPaterno.Trim() != "" ? false : true;
                txtApellidoMaterno.Enabled = model_PERSONA.ApellidoMaterno.Trim() != "" ? false : true;
                txtNombres.Enabled = model_PERSONA.Nombre.Trim() != "" ? false : true;
                dtpFechaNacimiento.Enabled = Convert.ToDateTime(model_PERSONA.FechaNacimiento) != new DateTime(1900, 1, 1) ? false : true;

                txtDireccion.Text = model_PERSONA.Direccion;
                txtCelular.Text = model_PERSONA.TelefonoCelular;
                txtCelularRef.Text = model_PERSONA.TelefonoFijo;
                txtEmail.Text = model_PERSONA.Email;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LlenarDatosUBIGEO(model_Ad_LugarNacimiento target)
        {
            try
            {
                model_Ad_LugarNacimiento = new model_Ad_LugarNacimiento(target.IdLugarNacimiento
                    , target.CodigoPersona
                    , target.CodigoNacionalidad
                    , target.CodigoDepartamento
                    , target.CodigoProvincia
                    , target.CodigoDistrito
                    , target.Estado);
                
                cmbPais.SelectedValue = Convert.ToInt64(model_Ad_LugarNacimiento.CodigoNacionalidad);

                Response<List<model_ciudad>> data_Departamento = controller_PERSONA.fncCON_Lista_ciudad(Convert.ToInt16(model_Ad_LugarNacimiento.CodigoNacionalidad));
                if (_validarRespuesta(data_Departamento))
                {
                    cmbDepartamento.Enabled = true;
                    mtd_ListarUBIGEODepartamento(Convert.ToInt16(model_Ad_LugarNacimiento.CodigoNacionalidad), Convert.ToInt16(model_Ad_LugarNacimiento.CodigoDepartamento));

                    if (lstDepartamento.Count > 0)
                    {
                        cmbProvincia.Enabled = true;
                        mtd_ListarUBIGEOProvincia(Convert.ToInt16(model_Ad_LugarNacimiento.CodigoDepartamento), Convert.ToInt16(model_Ad_LugarNacimiento.CodigoProvincia));
                        if (lstProvincia.Count > 0)
                        {
                            cmbDistrito.Enabled = true;
                            mtd_ListarUBIGEODistrito(Convert.ToInt16(model_Ad_LugarNacimiento.CodigoProvincia), Convert.ToInt32(model_Ad_LugarNacimiento.CodigoDistrito));
                        }
                        else
                        {
                            mtdLimpiarComboBox(cmbDistrito);
                            cmbDistrito.Enabled = false;
                        }
                    }
                    else
                    {
                        mtdLimpiarComboBox(cmbProvincia);
                        mtdLimpiarComboBox(cmbDistrito);

                        cmbProvincia.Enabled = false;
                        cmbDistrito.Enabled = false;
                    }
                }
                else { mtdMostrarMensaje(data_Departamento.MensajeError.ToList()[0].Mensaje); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarTipoDocumento()
        {
            try
            {
                List<customComboBox> lstTipoDocumento = new List<customComboBox> {
                    new customComboBox(1, "DNI")
                    , new customComboBox(4, "CE")
                    , new customComboBox(7, "PASAPORTE")
                };
                mtdLlenarComboBoxManual(cmbTipoDocumento, lstTipoDocumento);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void mtd_EstadoPanelPersonas(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                switch (tipo)
                {
                    case enm_G_TipoAccionMantenimiento.Ninguno:
                    case enm_G_TipoAccionMantenimiento.Nuevo:
                        pnlDatosPersonales.Enabled = true;
                        pnlUbigeo.Enabled = true;

                        btnGuardar.Enabled = true;
                        btnGuardar.Text = "   Guardar";
                        break;
                    case enm_G_TipoAccionMantenimiento.Modificar:
                        break;
                    case enm_G_TipoAccionMantenimiento.Cancelar:
                        break;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarFormulario()
        {
            model_PERSONA = new model_PERSONA();
            mtd_EstadoPanelPersonas(enm_G_TipoAccionMantenimiento.Ninguno);
            try
            {
                txtNroDocumento.Enabled = true;
                txtApellidoPaterno.Enabled = true;
                txtApellidoMaterno.Enabled = true;
                txtNombres.Enabled = true;
                dtpFechaNacimiento.Enabled = true;
                rbtMasculino.Enabled = true;
                rbtMasculino.Enabled = true;


                cmbTipoDocumento.SelectedValue = Convert.ToInt64(-1);
                rbtMasculino.Checked = false;
                rbtFemenino.Checked = false;
                txtNroDocumento.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtNombres.Text = "";
                dtpFechaNacimiento.Value = DateTime.Now;
                txtDireccion.Text = "";
                txtCelular.Text = "";
                txtCelularRef.Text = "";
                txtEmail.Text = "";

                cmbPais.SelectedValue = Convert.ToInt64(-1);

                cmbDepartamento.DataSource = null;
                cmbProvincia.DataSource = null;
                cmbDistrito.DataSource = null;

                cmbDepartamento.Enabled = false;
                cmbProvincia.Enabled = false;
                cmbDistrito.Enabled = false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion

        #region ======================================================== FUNCIONES ========================================================

        private bool fncValidarInformacionParaGuardado()
        {
            lstError = new List<EsquemaError>();
            enm_G_TipoValidacionRegex tipoRegex = new enm_G_TipoValidacionRegex();
            EsquemaValidacion stuValidacion = new EsquemaValidacion();

            try
            {
                if (Convert.ToInt64(cmbTipoDocumento.SelectedValue) == -1) { lstError.Add(new EsquemaError("TIPO DE DOC.", "Debe seleccionar el tipo de documento")); }
                switch ((enm_G_TipoDocumento)(Convert.ToInt64(cmbTipoDocumento.SelectedValue)))
                {
                    case enm_G_TipoDocumento.DNI:
                        tipoRegex = enm_G_TipoValidacionRegex.Numeros;
                        break;
                    
                    case enm_G_TipoDocumento.CE:
                    case enm_G_TipoDocumento.Pasaporte:
                        tipoRegex = enm_G_TipoValidacionRegex.AlfaNumerico;
                        break;
                }
                
                stuValidacion = fncValidarDato(txtNroDocumento.Text, "", tipoRegex);
                if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("NUMERO DE DOCUMENTO", "Ingrese correctamente el número de documento")); }

                stuValidacion = fncValidarDato(txtApellidoPaterno.Text, "", enm_G_TipoValidacionRegex.Letras);
                if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("APELLIDO PATERNO", "Consigne adecuadamente el apellido paterno de la persona")); }

                if (txtApellidoMaterno.Text.Trim() == "")
                {
                    stuValidacion = fncValidarDato(txtApellidoMaterno.Text, "", enm_G_TipoValidacionRegex.Letras);
                    if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("APELLIDO MATERNO", "Escriba correctamente el apellido materno de la persona")); }
                }

                stuValidacion = fncValidarDato(txtNombres.Text, "", enm_G_TipoValidacionRegex.Letras);
                if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("NOMBRES", "Ingrese correctamente los nombres de la persona")); }

                stuValidacion = fncValidarDato(txtCelular.Text, "", enm_G_TipoValidacionRegex.Numeros);
                if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("CELULAR", "Digite correctamente el número de contacto")); }

                if (txtCelularRef.Text.Trim() != "")
                {
                    stuValidacion = fncValidarDato(txtCelularRef.Text, "", enm_G_TipoValidacionRegex.Numeros);
                    if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("CELULAR REF. / TEL.", "Ingrese correctamente el número de referencia o teléfono")); }
                }

                //Aprox no mayores de 60 años
                //No menores de 8 años, solo es un aproximado, no hay regla existente
                if (dtpFechaNacimiento.Value <= DateTime.Today.AddYears(-60) || dtpFechaNacimiento.Value >= DateTime.Today.AddYears(-8))
                {
                    lstError.Add(new EsquemaError("FECHA DE NAC.", "Registre una fecha de nacimiento válida"));
                }

                stuValidacion = fncValidarDato(txtEmail.Text, "", enm_G_TipoValidacionRegex.Mail);
                if (!stuValidacion.Validado) { lstError.Add(new EsquemaError("EMAIL", "Debe ingresar el correo electrónico correctamente")); }

                if (Convert.ToInt64(cmbPais.SelectedValue) == -1) { lstError.Add(new EsquemaError("UBIGEO - PAIS", "Es necesario consignar el pais de nacimiento")); }

                if (Convert.ToInt64(cmbDepartamento.SelectedValue) == -1 || cmbDepartamento.SelectedValue == null)
                { lstError.Add(new EsquemaError("UBIGEO - DEP.", "Debe seleccionar la ciudad de nacimiento")); }

                if (Convert.ToInt64(cmbPais.SelectedValue) == 9589) //Perú
                {
                    if (Convert.ToInt64(cmbProvincia.SelectedValue) == -1 || cmbProvincia.SelectedValue == null)
                    { lstError.Add(new EsquemaError("UBIGEO - PROV.", "Tendrá que escoger una provincia")); }
                    if (Convert.ToInt64(cmbDistrito.SelectedValue) == -1 || cmbDistrito.SelectedValue == null)
                    { lstError.Add(new EsquemaError("UBIGEO - DIST.", "Seleccione un distrito")); }
                }

                if (lstError.Count == 0) { return true; }
                else
                {
                    mtd_MostrarPanelError(true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }

        private bool fncMostrarCoincidencia(List<model_Usp_Idi_S_ListarPersonaParaIdiomas> coincidenciaDNI
            , List<model_Usp_Idi_S_ListarPersonaParaIdiomas> coindicenciaNombres)
        {
            bool existeDNI = new bool();
            bool existeNombres = new bool();
            try
            {
                existeDNI = coincidenciaDNI.Count > 0 ? true: false;
                existeNombres = coindicenciaNombres.Count > 0 ? true : false;

                if (!existeDNI && !existeNombres) { return false; }
                else
                {
                    mtd_MostrarPanelCoindicenciaDatosPersona(true);
                    if (existeDNI)
                    {
                        dgvCoincidenciaNDocumento.DataSource = coincidenciaDNI;
                        mtd_AjustarRegistroPersona(dgvCoincidenciaNDocumento);
                    }
                    else { dgvCoincidenciaNDocumento = null; }
                    
                    if (existeNombres)
                    {
                        dgvCoincidenciaNombreCompleto.DataSource = coindicenciaNombres;
                        mtd_AjustarRegistroPersona(dgvCoincidenciaNombreCompleto);
                    }
                    else { dgvCoincidenciaNombreCompleto.DataSource= null; }

                    pnlDatosPersonales.Enabled = false;
                    pnlUbigeo.Enabled = false;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return true;
        }

        private bool fncVerificarCambioDatosImportantes()
        {
            bool resultado = true;
            try
            {
                if (model_PERSONA.NumeroDocumento != txtNroDocumento.Text
                    || model_PERSONA.ApellidoPaterno.ToUpper() != txtApellidoPaterno.Text.ToUpper()
                    || model_PERSONA.ApellidoMaterno.ToUpper() != txtApellidoMaterno.Text.ToUpper()
                    || model_PERSONA.Nombre.ToUpper() != txtNombres.Text.ToUpper())
                { return false; }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            return resultado;
        }

        #endregion

        private void frmAdministracionPersona_Load(object sender, EventArgs e)
        {
            try
            {
                mtd_ListarTipoDocumento();
                mtd_ListarUBIGEOPais();

                btnNuevo.PerformClick();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_PERSONA = new model_PERSONA();
                rec_CodigoPersona = 0;

                mtd_RestaurarFormulario();
                mtd_EstadoPanelPersonas(enm_G_TipoAccionMantenimiento.Nuevo);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaPersona FrmBuscar = new frmBusquedaPersona();
                if (FrmBuscar.ShowDialog(this) == DialogResult.OK)
                {
                    rec_CodigoPersona = FrmBuscar.env_CodigoPersona;

                    if (rec_CodigoPersona > 0)
                    {
                        btnGuardar.Text = "   Modificar";
                        mtd_ObtenerDatosPersonaIndividual(rec_CodigoPersona);
                    }
                    else
                    {
                        btnGuardar.Text = "   Guardar";
                        model_PERSONA = new model_PERSONA();
                        mtd_RestaurarFormulario();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbDepartamento.Enabled = true;
                mtd_ListarUBIGEODepartamento(Convert.ToInt16(cmbPais.SelectedValue));

                if (lstDepartamento.Count == 0)
                {
                    mtdLimpiarComboBox(cmbDepartamento);
                    cmbDepartamento.Enabled = false;
                }

                mtdLimpiarComboBox(cmbProvincia);
                mtdLimpiarComboBox(cmbDistrito);
                cmbProvincia.Enabled = false;
                cmbDistrito.Enabled = false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbProvincia.Enabled = true;
                mtd_ListarUBIGEOProvincia(Convert.ToInt16(cmbDepartamento.SelectedValue));

                if (lstProvincia.Count == 0)
                {
                    mtdLimpiarComboBox(cmbProvincia);
                    cmbProvincia.Enabled = false;
                }

                mtdLimpiarComboBox(cmbDistrito);
                cmbDistrito.Enabled = false;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbDistrito.Enabled = true;
                mtd_ListarUBIGEODistrito(Convert.ToInt16(cmbProvincia.SelectedValue));

                if (lstDistrito.Count == 0)
                {
                    mtdLimpiarComboBox(cmbDistrito);
                    cmbDistrito.Enabled = false;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar datos para guardar

            enmValidacionRENIEC = new enm_G_ValidacionRENIEC();
            try
            {
                if (fncValidarInformacionParaGuardado())
                {
                    model_PERSONA.TipoDocumento = Convert.ToByte(cmbTipoDocumento.SelectedValue);
                    model_PERSONA.Sexo = rbtMasculino.Checked ? "M" : rbtFemenino.Checked ? "F" : "";
                    model_PERSONA.NumeroDocumento = txtNroDocumento.Text;
                    model_PERSONA.ApellidoPaterno = txtApellidoPaterno.Text;
                    model_PERSONA.ApellidoMaterno = txtApellidoMaterno.Text;
                    model_PERSONA.Nombre = txtNombres.Text;
                    model_PERSONA.FechaNacimiento = dtpFechaNacimiento.Value;
                    model_PERSONA.Direccion = txtDireccion.Text;
                    model_PERSONA.TelefonoCelular = txtCelular.Text;
                    model_PERSONA.TelefonoFijo = txtCelularRef.Text;
                    model_PERSONA.Email = txtEmail.Text;

                    model_Ad_LugarNacimiento.CodigoNacionalidad = Convert.ToInt16(cmbPais.SelectedValue);

                    model_Ad_LugarNacimiento.CodigoDepartamento = cmbDepartamento.Enabled == true && Convert.ToInt32(cmbDepartamento.SelectedValue) > 0
                        ? Convert.ToInt32(cmbDepartamento.SelectedValue)
                        : 0;

                    model_Ad_LugarNacimiento.CodigoProvincia = cmbProvincia.Enabled == true && Convert.ToInt32(cmbProvincia.SelectedValue) > 0
                        ? Convert.ToInt32(cmbProvincia.SelectedValue)
                        : 0;

                    model_Ad_LugarNacimiento.CodigoDistrito = cmbDistrito.Enabled == true && Convert.ToInt32(cmbDistrito.SelectedValue) > 0
                        ? Convert.ToInt32(cmbDistrito.SelectedValue)
                        : 0;


                    if (model_PERSONA.CodigoPersona == 0)
                    {
                        model_PERSONA.CodigoEstamento = 10;
                        model_PERSONA.CodigoLugarNacimiento = 0;

                        Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> data_PERSONA_DNI = controller_PERSONA.fncCON_RelacionPersonas(numeroDocumento: model_PERSONA.NumeroDocumento);
                        Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> data_PERSONA_Nombres = controller_PERSONA.fncCON_RelacionPersonas(apellidoPaterno: model_PERSONA.ApellidoPaterno
                            , apellidoMaterno: model_PERSONA.ApellidoMaterno
                            , nombres: model_PERSONA.Nombre);

                        if (fncMostrarCoincidencia(data_PERSONA_DNI.Data, data_PERSONA_Nombres.Data))
                        { mtdMostrarMensaje("Ya existe una persona registrada con los datos ingresados"); }
                        else { mtd_ValidarRENIEC(model_PERSONA.NumeroDocumento); }
                    }
                    else { mtd_ValidarRENIEC(model_PERSONA.NumeroDocumento); }
                }
                //mtd_RestaurarFormulario();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarEnReniec_Click(object sender, EventArgs e)
        {
            try { mtd_ValidarRENIEC(txtDNIRENIEC.Text); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnContinuarValidacionRENIEC_Click(object sender, EventArgs e)
        {
            bool actualizacionExitosa = true;
            try
            {
                //Aqui creo que no va la validación
                if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mtd_MostrarPanelValidacionRENIEC(false);

                    if (model_PERSONA.CodigoPersona == 0)
                    {
                        Response<EsquemaRespuestaRegistro> registroPERSONA = controller_PERSONA.fncCON_RegistrarPERSONA(model_PERSONA);
                        if (!registroPERSONA.Success)
                        {
                            mtdMostrarMensaje(registroPERSONA.MensajeError.ToList()[0].Mensaje);
                            actualizacionExitosa = false;
                        }
                    }
                    else
                    {
                        Response<bool> actualizacionPERSONA = controller_PERSONA.fncCON_ModificarPERSONA(model_PERSONA);
                        if (!actualizacionPERSONA.Success)
                        {
                            mtdMostrarMensaje(actualizacionPERSONA.MensajeError.ToList()[0].Mensaje);
                            actualizacionExitosa = false;
                        }
                    }

                    if (model_Ad_LugarNacimiento.IdLugarNacimiento == 0)
                    {
                        Response<EsquemaRespuestaRegistro> registroAd_LugarNacimiento = controller_Ad_LugarNacimiento.fncCON_RegistrarAd_LugarNacimiento(model_Ad_LugarNacimiento);
                        if (!registroAd_LugarNacimiento.Success)
                        {
                            mtdMostrarMensaje(registroAd_LugarNacimiento.MensajeError.ToList()[0].Mensaje);
                            actualizacionExitosa = false;
                        }
                    }
                    else
                    {
                        Response<bool> actualizacionAd_LugarNacimiento = controller_Ad_LugarNacimiento.fncCON_ModificarAd_LugarNacimiento(model_Ad_LugarNacimiento);
                        if (!actualizacionAd_LugarNacimiento.Success)
                        {
                            mtdMostrarMensaje(actualizacionAd_LugarNacimiento.MensajeError.ToList()[0].Mensaje);
                            actualizacionExitosa = false;
                        }
                    }

                    if (actualizacionExitosa) { mtdMostrarMensaje("Registro actualizado satisfactoriamente"); }

                    model_PERSONA = new model_PERSONA();
                    rec_CodigoPersona = 0;

                    mtd_RestaurarFormulario();
                    btnNuevo.PerformClick();
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void lblCerrarPanelValidacionRENIEC_Click(object sender, EventArgs e)
        {
            try { mtd_MostrarPanelValidacionRENIEC(false); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCoincidenciaNombreCompleto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { mtd_ReemplazarDatosPersona(dgvCoincidenciaNombreCompleto); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvCoincidenciaNDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { mtd_ReemplazarDatosPersona(dgvCoincidenciaNDocumento); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscarRENIEC_Click(object sender, EventArgs e)
        {
            try { mtd_ValidarRENIEC(txtDNIRENIEC.Text); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void lblCerrarPanelError_Click(object sender, EventArgs e)
        {
            try { mtd_MostrarPanelError(false); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void cmbTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try { txtNroDocumento.MaxLength = _obtenerExtensionTipoDocumento((enm_G_TipoDocumento)Convert.ToInt16(cmbTipoDocumento.SelectedValue)); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (model_PERSONA.CodigoPersona > 0 || rec_CodigoPersona > 0)
                {
                    if (MessageBox.Show("Está por restaurar todo el formulario, ¿seguro que desea continuar?, los cambios sin guardar se perderán"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        model_PERSONA = new model_PERSONA();
                        rec_CodigoPersona = 0;

                        mtd_RestaurarFormulario();
                        mtd_EstadoPanelPersonas(enm_G_TipoAccionMantenimiento.Nuevo);
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}