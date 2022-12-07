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

namespace pry04.View.Idiomas_v2.Horario
{
    public partial class frmAdministracionTurno: Form
    {
        public frmAdministracionTurno() { InitializeComponent(); }

        private controller_Idi_TurnoBase controller_Idi_TurnoBase = new controller_Idi_TurnoBase();
        private controller_Idi_TurnoDetalle controller_Idi_TurnoDetalle = new controller_Idi_TurnoDetalle();

        private model_Idi_TurnoBase model_Idi_TurnoBase = new model_Idi_TurnoBase();
        private model_Idi_TurnoDetalle model_Idi_TurnoDetalle = new model_Idi_TurnoDetalle();

        private List<model_Idi_TurnoBase> lstTurnoBase = new List<model_Idi_TurnoBase>();
        private List<model_Idi_TurnoBase> lstFiltroTurnoBase = new List<model_Idi_TurnoBase>();

        private List<EsquemaTurnoDetalle> lstDataTurnoDetalle = new List<EsquemaTurnoDetalle>();
        private List<EsquemaSemana> lstTurnoDetalleMostrar = new List<EsquemaSemana>();

        #region ========================================================= MÉTODOS =========================================================
        private void mtd_EnviarTurnoManual(bool reset)
        {
            try
            {
                if (dtpDesde.Value < dtpHasta.Value || reset)
                {
                    if (chkLunes.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Lunes, reset); }
                    if (chkMartes.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Martes, reset); }
                    if (chkMiercoles.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Miercoles, reset); }
                    if (chkJueves.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Jueves, reset); }
                    if (chkViernes.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Viernes, reset); }
                    if (chkSabado.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Sabado, reset); }
                    if (chkDomingo.Checked) { mtd_ReemplazarHora(enm_G_DiaSemana.Domingo, reset); }

                    mtd_ActualizarEsquemaMostrar();
                    dgvTurnoDetalle.Refresh();
                } else { mtdMostrarMensaje("La hora final deberá ser mayor a la hora inicial"); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarTurnoCompleto()
        {
            try
            {
                mtd_ListarTurnoBase();
                if (dgvTurnoBase.SelectedRows.Count > 0 && lstFiltroTurnoBase.Count > 0)
                {
                    model_Idi_TurnoBase = new model_Idi_TurnoBase(idIdi_TurnoBase: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvTurnoBase.CurrentRow, "IdIdi_TurnoBase"))
                        , descripcion: mtdObtenerCeldaDataGridViewRow(dgvTurnoBase.CurrentRow, "Descripcion").ToString());
                    mtd_ListarDetalleTurno(model_Idi_TurnoBase.IdIdi_TurnoBase);
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento tipo)
        {
            try
            {
                chkLunes.Checked = false;
                chkMartes.Checked = false;
                chkMiercoles.Checked = false;
                chkJueves.Checked = false;
                chkViernes.Checked = false;
                chkSabado.Checked = false;
                chkDomingo.Checked = false;

                txtRegistroNombre.Text = "";
                dtpDesde.Value = new DateTime(1900, 1, 1, 0, 0, 0);
                dtpHasta.Value = new DateTime(1900, 1, 1, 0, 0, 0);

                switch (tipo)
                {
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
        
        private void mtd_ReemplazarHora(enm_G_DiaSemana dia, bool reset = default)
        {
            TimeSpan horaCambiar = new TimeSpan(0, 0, 0);
            try
            {
                int indexEntrada = lstDataTurnoDetalle.FindIndex(c => c.NumeroDia == dia && c.Tipo == enm_G_TipoHoraTurno.Entrada);
                int indexSalida = lstDataTurnoDetalle.FindIndex(c => c.NumeroDia == dia && c.Tipo == enm_G_TipoHoraTurno.Salida);
                
                if (indexEntrada != -1)
                {
                    EsquemaTurnoDetalle target = lstDataTurnoDetalle[indexEntrada];
                    horaCambiar = reset? new TimeSpan(0, 0, 0): new TimeSpan(dtpDesde.Value.Hour, dtpDesde.Value.Minute, dtpDesde.Value.Second);

                    lstDataTurnoDetalle[indexEntrada] = new EsquemaTurnoDetalle(idIdi_TurnoDetalle: target.IdIdi_TurnoDetalle
                        , numeroDia: target.NumeroDia
                        , tipo: target.Tipo
                        , hora: horaCambiar
                        , estado: target.Estado);
                }
                if (indexSalida != -1)
                {
                    EsquemaTurnoDetalle target = lstDataTurnoDetalle[indexSalida];
                    horaCambiar = reset? new TimeSpan(0, 0, 0): new TimeSpan(dtpHasta.Value.Hour, dtpHasta.Value.Minute, dtpHasta.Value.Second);

                    lstDataTurnoDetalle[indexSalida] = new EsquemaTurnoDetalle(idIdi_TurnoDetalle: target.IdIdi_TurnoDetalle
                        , numeroDia: target.NumeroDia
                        , tipo: target.Tipo
                        , hora: horaCambiar
                        , estado: target.Estado);
                }

            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarDetalleTurno(short idIdi_TurnoBase)
        {
            try
            {
                Response<List<model_Idi_TurnoDetalle>> data_Idi_TurnoDetalle = controller_Idi_TurnoDetalle.fncCON_ListaTurnoDetalle(idIdi_TurnoBase);
                if (_validarRespuesta(data_Idi_TurnoDetalle))
                {
                    if (idIdi_TurnoBase > 0)
                    {
                        mtdMostrarMensaje("No se pudo encontrar el detalle del Turno");
                    }
                    else
                    {
                        mtd_LlenarEsquemaTurnoDetalle(data_Idi_TurnoDetalle.Data);
                        mtd_RestaurarEsquemaMostrar();
                        mtd_ActualizarEsquemaMostrar();

                        dgvTurnoDetalle.DataSource = lstTurnoDetalleMostrar;
                        mtd_AjustarTurnoDetalle();
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_RestaurarEsquemaMostrar()
        {
            lstTurnoDetalleMostrar = new List<EsquemaSemana>();
            try
            {
                lstTurnoDetalleMostrar.Add(new EsquemaSemana());
                lstTurnoDetalleMostrar.Add(new EsquemaSemana());
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ActualizarEsquemaMostrar()
        {
            List<TimeSpan> lstTurnoDesde = new List<TimeSpan>();
            List<TimeSpan> lstTurnoHasta = new List<TimeSpan>();
            try
            {
                for (enm_G_DiaSemana iDia = enm_G_DiaSemana.Lunes; iDia <= enm_G_DiaSemana.Domingo; iDia++)
                {
                    List<EsquemaTurnoDetalle> horaDia = lstDataTurnoDetalle.Where(c => c.NumeroDia == iDia).ToList();

                    if (horaDia.Count > 0)
                    {
                        lstTurnoDesde.Add(horaDia[0].Hora);
                        lstTurnoHasta.Add(horaDia[1].Hora);
                    }
                    else
                    {
                        lstTurnoDesde.Add(_obtenerDefaultTimeSpan());
                        lstTurnoHasta.Add(_obtenerDefaultTimeSpan());
                    }
                }

                lstTurnoDetalleMostrar[0] = new EsquemaSemana(lstTurnoDesde[0]
                    , lstTurnoDesde[1]
                    , lstTurnoDesde[2]
                    , lstTurnoDesde[3]
                    , lstTurnoDesde[4]
                    , lstTurnoDesde[5]
                    , lstTurnoDesde[6]);
                lstTurnoDetalleMostrar[1] = new EsquemaSemana(lstTurnoHasta[0]
                    , lstTurnoHasta[1]
                    , lstTurnoHasta[2]
                    , lstTurnoHasta[3]
                    , lstTurnoHasta[4]
                    , lstTurnoHasta[5]
                    , lstTurnoHasta[6]);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_LlenarEsquemaTurnoDetalle(List<model_Idi_TurnoDetalle> TurnoDetalle)
        {
            lstDataTurnoDetalle = new List<EsquemaTurnoDetalle>();
            EsquemaTurnoDetalle itemTurnoDesde = new EsquemaTurnoDetalle();
            EsquemaTurnoDetalle itemTurnoHasta = new EsquemaTurnoDetalle();
            try
            {
                for (enm_G_DiaSemana iDia = enm_G_DiaSemana.Lunes; iDia <= enm_G_DiaSemana.Domingo; iDia++)
                {
                    List<model_Idi_TurnoDetalle> TurnoFiltrado = TurnoDetalle
                        .Where(c => c.NumeroDia == Convert.ToByte(iDia))
                        .ToList();
                    if (TurnoFiltrado.Count > 0)
                    {
                            itemTurnoDesde = new EsquemaTurnoDetalle(idIdi_TurnoDetalle: TurnoFiltrado[0].IdIdi_TurnoDetalle
                                , numeroDia: (enm_G_DiaSemana)TurnoFiltrado[0].NumeroDia
                                , tipo: enm_G_TipoHoraTurno.Entrada
                                , hora: TurnoFiltrado[0].Desde
                                , estado: TurnoFiltrado[0].Estado);

                            itemTurnoHasta = new EsquemaTurnoDetalle(idIdi_TurnoDetalle: TurnoFiltrado[0].IdIdi_TurnoDetalle
                                , numeroDia: (enm_G_DiaSemana)TurnoFiltrado[0].NumeroDia
                                , tipo: enm_G_TipoHoraTurno.Salida
                                , hora: TurnoFiltrado[0].Hasta
                                , estado: TurnoFiltrado[0].Estado);
                    }
                    else
                    {
                        itemTurnoDesde = new EsquemaTurnoDetalle(numeroDia: iDia, tipo: enm_G_TipoHoraTurno.Entrada);
                        itemTurnoHasta = new EsquemaTurnoDetalle(numeroDia: iDia, tipo: enm_G_TipoHoraTurno.Salida);
                    }

                    lstDataTurnoDetalle.Add(itemTurnoDesde);
                    lstDataTurnoDetalle.Add(itemTurnoHasta);
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_ListarTurnoBase()
        {
            try
            {
                lstTurnoBase = controller_Idi_TurnoBase.fncCON_ListaTurnoBase().Data;

                if (lstTurnoBase.Count > 0)
                {
                    dgvTurnoBase.DataSource = lstTurnoBase;
                    mtd_FiltrarTurnoBase();
                    mtd_AjustarTurnoBase();
                }
                else
                {
                    dgvTurnoBase.DataSource = null;
                    mtdMostrarMensaje("No se encontraron Turnos base");
                }
                
                dgvTurnoBase.Refresh();
                lblCantidadRegistros.Text = lstTurnoBase.Count.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_FiltrarTurnoBase()
        {
            try
            {
                lstFiltroTurnoBase = lstTurnoBase;
                lstFiltroTurnoBase = lstFiltroTurnoBase.Where(c => c.Descripcion.ToUpper().Contains(txtFiltroNombre.Text.ToUpper())).ToList();
                
                dgvTurnoBase.DataSource = lstFiltroTurnoBase;

                dgvTurnoBase.Refresh();
                lblCantidadRegistros.Text = lstFiltroTurnoBase.Count.ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarTurnoDetalle()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvTurnoDetalle);

                List<customDataGridViewRow> lstAjuste_TurnoDetalle = new List<customDataGridViewRow> {
                    new customDataGridViewRow("Lunes", "LUNES", autoSize: true, width: 100)
                    , new customDataGridViewRow("Martes", "MARTES", autoSize: true, width: 100)
                    , new customDataGridViewRow("Miercoles", "MIERCOLES", autoSize: true, width: 100)
                    , new customDataGridViewRow("Jueves", "JUEVES", autoSize: true, width: 100)
                    , new customDataGridViewRow("Viernes", "VIERNES", autoSize: true, width: 100)
                    , new customDataGridViewRow("Sabado", "SÁBADO", autoSize: true, width: 100)
                    , new customDataGridViewRow("Domingo", "DOMINGO", autoSize: true, width: 100)
                };
                mtdAjustarDataGridView(dgvTurnoDetalle, lstAjuste_TurnoDetalle);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void mtd_AjustarTurnoBase()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvTurnoBase);

                List<customDataGridViewRow> lstAjuste_TurnoBase = new List<customDataGridViewRow> {
                    new customDataGridViewRow("IdIdi_TurnoBase", "ID", width: 50)
                    , new customDataGridViewRow("Descripcion", "DESCRIPCIÓN", autoSize: true, width: 120)
                };
                mtdAjustarDataGridView(dgvTurnoBase, lstAjuste_TurnoBase);
                mtdSeleccionarRegistro(dgvTurnoBase, "IdIdi_TurnoBase");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion

        

        #region ======================================================== FUNCIONES ========================================================
        private bool fncActualizarDetalleTurno(short IdIdi_TurnoBase)
        {
            bool resultado = true;
            try
            {
                for (enm_G_DiaSemana iDia = enm_G_DiaSemana.Lunes; iDia <= enm_G_DiaSemana.Domingo; iDia++)
                {
                    List<EsquemaTurnoDetalle> TurnoDia = lstDataTurnoDetalle.Where(c => c.NumeroDia == iDia).ToList();

                    if (TurnoDia.Count > 0)
                    {
                        if (TurnoDia[0].IdIdi_TurnoDetalle == 0)
                        {
                            if (TurnoDia[0].Hora > new TimeSpan(0, 0, 0) && TurnoDia[1].Hora > new TimeSpan(0, 0, 0))
                            {
                                model_Idi_TurnoDetalle = new model_Idi_TurnoDetalle(idIdi_TurnoBase: IdIdi_TurnoBase
                                    , numeroDia: Convert.ToByte(iDia)
                                    , desde: TurnoDia[0].Hora
                                    , hasta: TurnoDia[1].Hora);

                                Response<EsquemaRespuestaRegistro> registroIdI_TurnoDetalle = controller_Idi_TurnoDetalle.fncCON_RegistrarTurnoDetalle(model_Idi_TurnoDetalle);

                                if (!registroIdI_TurnoDetalle.Success)
                                {
                                    mtdMostrarMensaje(registroIdI_TurnoDetalle.MensajeError.ToList()[0].Mensaje);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            byte estado = TurnoDia[0].Hora == new TimeSpan(0, 0, 0) && TurnoDia[1].Hora == new TimeSpan(0, 0, 0)? Convert.ToByte(0): Convert.ToByte(1);
                            
                            model_Idi_TurnoDetalle = new model_Idi_TurnoDetalle(idIdi_TurnoDetalle: TurnoDia[0].IdIdi_TurnoDetalle
                                , idIdi_TurnoBase: IdIdi_TurnoBase
                                , numeroDia: Convert.ToByte(iDia)
                                , desde: TurnoDia[0].Hora
                                , hasta: TurnoDia[1].Hora
                                , estado: estado);

                            if (model_Idi_TurnoDetalle.IdIdi_TurnoDetalle == 0)
                            {
                                Response<EsquemaRespuestaRegistro> registroIdi_TurnoDetalle = controller_Idi_TurnoDetalle.fncCON_RegistrarTurnoDetalle(model_Idi_TurnoDetalle);
                                if (!registroIdi_TurnoDetalle.Success)
                                {
                                    mtdMostrarMensaje(registroIdi_TurnoDetalle.MensajeError.ToList()[0].Mensaje);
                                    return false;
                                }
                            }
                            else
                            {
                                Response<bool> actualizacionIdi_TurnoDetalle = controller_Idi_TurnoDetalle.fncCON_ModificarTurnoDetalle(model_Idi_TurnoDetalle);
                                if (!actualizacionIdi_TurnoDetalle.Success)
                                {
                                    mtdMostrarMensaje(actualizacionIdi_TurnoDetalle.MensajeError.ToList()[0].Mensaje);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return resultado;
        }

        private bool fncEncontrarRegistroDetalleTurno()
        {
            bool resultado = new bool();
            try
            {
                for (enm_G_DiaSemana iDia = enm_G_DiaSemana.Lunes; iDia <= enm_G_DiaSemana.Domingo; iDia++)
                {
                    List<EsquemaTurnoDetalle> TurnoDia = lstDataTurnoDetalle.Where(c => c.NumeroDia == iDia).ToList();

                    if (TurnoDia.Count > 0)
                    {
                        if (TurnoDia[0].Hora > new TimeSpan(0, 0, 0) && TurnoDia[1].Hora > new TimeSpan(0, 0, 0)) { return true; }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            return resultado;
        }

        private bool fncValidarTurno()
        {
            try
            {
                if (dtpHasta.Value < dtpDesde.Value)
                {
                    mtdMostrarMensaje("La hora final deberá ser mayor a la hora inicial");
                    return false;
                }
                if (txtRegistroNombre.Text.Trim() == "")
                {
                    mtdMostrarMensaje("No olvide asignar un nombre para el Turno");
                    return false;
                }

                if (!fncEncontrarRegistroDetalleTurno())
                {
                    mtdMostrarMensaje("Al menos debe ingresar el Turno para un día");
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



        private void frmAdministracionTurno_Load(object sender, EventArgs e)
        {
            try { mtd_ListarTurnoCompleto(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvTurnoBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Modificar);
                if (dgvTurnoBase.SelectedRows.Count > 0 && lstFiltroTurnoBase.Count > 0)
                {
                    model_Idi_TurnoBase = new model_Idi_TurnoBase(idIdi_TurnoBase: Convert.ToInt16(mtdObtenerCeldaDataGridViewRow(dgvTurnoBase.CurrentRow, "IdIdi_TurnoBase"))
                        , descripcion: mtdObtenerCeldaDataGridViewRow(dgvTurnoBase.CurrentRow, "Descripcion").ToString());
                    
                    txtRegistroNombre.Text = model_Idi_TurnoBase.Descripcion;

                    mtd_ListarDetalleTurno(model_Idi_TurnoBase.IdIdi_TurnoBase);
                }
                else { btnNuevo.PerformClick(); }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            try { mtd_EnviarTurnoManual(false); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnRestaurarSeleccion_Click(object sender, EventArgs e)
        {
            try { mtd_EnviarTurnoManual(true); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnRestaurarTodo_Click(object sender, EventArgs e)
        {
            try { btnCancelar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fncValidarTurno())
                {
                    if (MessageBox.Show("¿Está seguro de actualizar esta información?"
                        , Constantes.TextoMessageBoxQuestion
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool actualizacionExitosa = true;

                        if (model_Idi_TurnoBase.IdIdi_TurnoBase == 0)
                        {
                            model_Idi_TurnoBase = new model_Idi_TurnoBase(descripcion: txtRegistroNombre.Text);
                            Response<EsquemaRespuestaRegistro> registroIdi_TurnoBase = controller_Idi_TurnoBase.fncCON_RegistrarTurnoBase(model_Idi_TurnoBase);
                            
                            if (registroIdi_TurnoBase.Success) { model_Idi_TurnoBase.IdIdi_TurnoBase = Convert.ToInt16(registroIdi_TurnoBase.Data.Identificador); }
                            else
                            {
                                mtdMostrarMensaje(registroIdi_TurnoBase.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }
                        else
                        {
                            model_Idi_TurnoBase.Descripcion = txtRegistroNombre.Text;
                            Response<bool> actualizacionIdi_TurnoBase = controller_Idi_TurnoBase.fncCON_ModificarTurnoBase(model_Idi_TurnoBase);
                            
                            if (!actualizacionIdi_TurnoBase.Success)
                            {
                                mtdMostrarMensaje(actualizacionIdi_TurnoBase.MensajeError.ToList()[0].Mensaje);
                                actualizacionExitosa = false;
                            }
                        }

                        if (actualizacionExitosa)
                        {
                            if (fncActualizarDetalleTurno(model_Idi_TurnoBase.IdIdi_TurnoBase))
                            {
                                mtdMostrarMensaje("Registro actualizado satisfactoriamente");
                            }
                        }

                        mtd_ListarTurnoCompleto();
                        mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                        btnNuevo.PerformClick();
                    }
                }
            } catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                model_Idi_TurnoBase = new model_Idi_TurnoBase();
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Nuevo);
                mtd_ListarDetalleTurno(model_Idi_TurnoBase.IdIdi_TurnoBase);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                mtd_RestaurarFormulario(enm_G_TipoAccionMantenimiento.Cancelar);
                model_Idi_TurnoBase = new model_Idi_TurnoBase();
                mtd_ListarDetalleTurno(model_Idi_TurnoBase.IdIdi_TurnoBase);
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            try { mtd_FiltrarTurnoBase(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void frmAdministracionTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}
