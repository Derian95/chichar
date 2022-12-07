using Microsoft.Data.SqlClient;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_General
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Usp_Idi_S_FechaHoraServidor> _model_model_Usp_Idi_S_FechaHoraServidor = new rep_Matrix<model_Usp_Idi_S_FechaHoraServidor>();

        public Response<List<model_Usp_Idi_S_FechaHoraServidor>> fncACC_FechaHoraServidor()
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            try
            {
                return _respuesta.AddData(
                    _model_model_Usp_Idi_S_FechaHoraServidor.ExecuteStoredProcedureList<model_Usp_Idi_S_FechaHoraServidor>("dbo.Usp_Idi_S_FechaHoraServidor", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_FechaHoraServidor>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
