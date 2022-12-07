//using Microsoft.Data.SqlClient;

//using pry01.Data.Idiomas_v2.Repositorio;
//using pry02.Model.Idiomas_v2.Procedimiento;
//using pry100.Utilitario.Idiomas_v2.Clases;
//using pry100.Utilitario.Idiomas_v2.Enumerables;

//using System;
//using System.Collections.Generic;

//namespace pry01.Data.Idiomas_v2.Acceso
//{
//    public class access_Idi_SistemaEvaluacion
//    {
//        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
//        private readonly rep_Matrix<model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion> _model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion = new rep_Matrix<model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion>();

//        public Response<List<model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion>> fncACC_ListarSistemaEvaluacion()
//        {
//            List<SqlParameter> Parametros = new List<SqlParameter>();
//            try
//            {
//                return _respuesta.AddData(
//                    _model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion.ExecuteStoredProcedureList<model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion>("dbo.Usp_Idi_S_Idi_MostrarSistemaEvaluacion", Parametros)
//                );
//            }
//            catch (Exception ex)
//            {
//                return _respuesta.AddError<List<model_Usp_Idi_S_Idi_MostrarSistemaEvaluacion>>(new[] {
//                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
//                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
//                });
//            }
//        }
//    }
//}
