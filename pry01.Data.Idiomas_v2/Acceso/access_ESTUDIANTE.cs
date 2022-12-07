using Microsoft.Data.SqlClient;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;


namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_ESTUDIANTE
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_ESTUDIANTE> _model_ESTUDIANTE = new rep_Matrix<model_ESTUDIANTE>();

        public Response<List<model_ESTUDIANTE>> fncACC_ListaESTUDIANTE(int codigoUniversitario)
        {
            try { return _respuesta.AddData(_model_ESTUDIANTE.ObtenerListado(where: c => c.CodigoUniversitario == codigoUniversitario).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_ESTUDIANTE>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_ESTUDIANTE> fncACC_ESTUDIANTEIndividual(int codigoUniversitario)
        {
            try { return _respuesta.AddData(_model_ESTUDIANTE.Obtener(c => c.CodigoUniversitario == codigoUniversitario)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_ESTUDIANTE>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarESTUDIANTE(model_ESTUDIANTE entidad)
        {
            try
            {
                _model_ESTUDIANTE.Agregar(entidad);
                _model_ESTUDIANTE.GuardarCambios();
                return _respuesta.AddData(entidad.CodigoUniversitario);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarESTUDIANTE(model_ESTUDIANTE entidad)
        {
            try
            {
                _model_ESTUDIANTE.Modificar(entidad);
                _model_ESTUDIANTE.GuardarCambios();
                return _respuesta.AddData(entidad.CodigoUniversitario);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> fncACC_RelacionEstudiantes(int codigoUniversitario = -1
            , string numeroDocumento = _defaultString
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , string nombres = _defaultString)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() {
                new SqlParameter("@CodUniv", codigoUniversitario)
                , new SqlParameter("@DniPer", numeroDocumento)
                , new SqlParameter("@ApepPer", apellidoPaterno)
                , new SqlParameter("@ApemPer", apellidoMaterno)
                , new SqlParameter("@NomPer", nombres)
            };
            try
            {
                return _respuesta.AddData(
                    _model_ESTUDIANTE.ExecuteStoredProcedureList<model_Usp_Idi_S_ListarEstudianteParaIdiomas>("dbo.Usp_Idi_S_ListarEstudianteParaIdiomas", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

    }
}
