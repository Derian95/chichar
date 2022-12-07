using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using pry02.Model.Idiomas_v2.Procedimiento;
using pry03.Controller.Idiomas_v2;

using pry100.Utilitario.Idiomas_v2.Enumerables;
using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEsquemaRespuesta;
using static pry100.Utilitario.Idiomas_v2.Clases.clsDataGridView;

namespace pry04.View.Idiomas_v2.Individuo
{
    public partial class frmBusquedaPersona : Form
    {
        public frmBusquedaPersona() { InitializeComponent(); }

        #region DATOS ENVIADOS
        public int env_CodigoPersona = new int();
        #endregion

        private controller_PERSONA controller_PERSONA = new controller_PERSONA();
        private List<model_Usp_Idi_S_ListarPersonaParaIdiomas> lstPersona = new List<model_Usp_Idi_S_ListarPersonaParaIdiomas>();
        
        #region ========================================================= MÉTODOS =========================================================
        
        private void mtd_AjustarPersona()
        {
            try
            {
                mtdNoOrdenarDataGridView(dgvPersonas);

                List<string> lstColumnasOcultar = new List<string> { "CodEstamento", "CodLugNac", "RucPer", "LmPer", "Direccion", "Usuario"
                    , "Fecha", "GrupoSang", "IndMedica", "Activo", "EstadoCivil", "TipoDocum", "DescripcionTipoDocumento", "perobs", "LugNac" };
                mtdFormatearDataGridView(dgvPersonas, lstColumnasOcultar);

                List<customDataGridViewRow> lstAjuste_Persona = new List<customDataGridViewRow> {
                    new customDataGridViewRow("CodPer", "ID", width: 50)
                    , new customDataGridViewRow("Estamento", "ESTAMENTO", width: 100)
                    , new customDataGridViewRow("DniPer", "DOC.", width: 60)
                    , new customDataGridViewRow("Sexo", "SEXO", width: 40)
                    , new customDataGridViewRow("ApepPer", "A. PATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 95)
                    , new customDataGridViewRow("ApemPer", "A. MATERNO"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 95)
                    , new customDataGridViewRow("NomPer", "NOMBRES"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left, width: 140)
                    , new customDataGridViewRow("FechaNac", "F. NAC.", width: 80)
                    , new customDataGridViewRow("TelefCelular", "CELULAR", width: 80)
                    , new customDataGridViewRow("TelefFijo", "REF.", width: 80)
                    , new customDataGridViewRow("Email", "EMAIL"
                        , headerAlignment: enm_G_Alignment.Left
                        , valueAlignment: enm_G_Alignment.Left
                        , autoSize: true, width: 100)
                };

                mtdAjustarDataGridView(dgvPersonas, lstAjuste_Persona);
                mtdSeleccionarRegistro(dgvPersonas, "CodPer");
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        private void mtd_ListarPersonas()
        {
            try
            {
                //Ir al proc almacenado xq está validado el NULL
                Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> data_PERSONA = controller_PERSONA.fncCON_RelacionPersonas(numeroDocumento: txtNroDocumento.Text
                    , apellidoPaterno: txtApellidoPaterno.Text
                    , apellidoMaterno: txtApellidoMaterno.Text
                    , nombres: txtNombres.Text);
                if (_validarRespuesta(data_PERSONA))
                {
                    lstPersona = data_PERSONA.Data;

                    dgvPersonas.DataSource = lstPersona;
                    //Al ajustar, como el grid aun no se ve por el showdialog, no puede formatear, creo
                    mtd_AjustarPersona();
                }
                else { dgvPersonas.DataSource = null; }

                dgvPersonas.Refresh();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        #endregion



        #region ======================================================== FUNCIONES ========================================================

        #endregion

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPersonas.Rows.Count > 0)
                {
                    if (dgvPersonas.SelectedRows.Count > 0)
                    {
                        env_CodigoPersona = Convert.ToInt32(mtdObtenerCeldaDataGridViewRow(dgvPersonas.CurrentRow, "CodPer"));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else { mtdMostrarMensaje("Olvidó seleccionar un registro de la tabla"); }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void dgvPersonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { btnSeleccionar.PerformClick(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { mtd_ListarPersonas(); }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                env_CodigoPersona = 0;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
