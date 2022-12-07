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
    public class access_PERSONA
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_PERSONA> _model_PERSONA = new rep_Matrix<model_PERSONA>();
        private readonly rep_Matrix<model_ciudad> _model_ciudad = new rep_Matrix<model_ciudad>();

        public Response<List<model_PERSONA>> fncACC_ListaPERSONA()
        {
            try { return _respuesta.AddData(_model_PERSONA.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_PERSONA>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_PERSONA> fncACC_PERSONAIndividual(int codigoPersona)
        {
            try { return _respuesta.AddData(_model_PERSONA.Obtener(c => c.CodigoPersona == codigoPersona)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_PERSONA>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarPERSONA(model_PERSONA entidad)
        {
            try
            {
                _model_PERSONA.Agregar(entidad);
                _model_PERSONA.GuardarCambios();
                return _respuesta.AddData(entidad.CodigoPersona);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarPERSONA(model_PERSONA entidad)
        {
            try
            {
                _model_PERSONA.Modificar(entidad);
                _model_PERSONA.GuardarCambios();
                return _respuesta.AddData(entidad.CodigoPersona);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        public Response<List<model_ciudad>> fncACC_Lista_ciudad(short idNacionalidad)
        {
            try { return _respuesta.AddData(_model_ciudad.ObtenerListado(where: c => c.Relacion == idNacionalidad).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_ciudad>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }



        public Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> fncACC_RelacionPersonas(int codigoPersona = -1
            , string numeroDocumento = _defaultString
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , string nombres = _defaultString)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() { 
                new SqlParameter("@CodPer", codigoPersona)
                , new SqlParameter("@DniPer", numeroDocumento)
                , new SqlParameter("@ApepPer", apellidoPaterno)
                , new SqlParameter("@ApemPer", apellidoMaterno)
                , new SqlParameter("@NomPer", nombres)
            };
            try
            {
                return _respuesta.AddData(
                    _model_PERSONA.ExecuteStoredProcedureList<model_Usp_Idi_S_ListarPersonaParaIdiomas>("dbo.Usp_Idi_S_ListarPersonaParaIdiomas", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }








        public Response<List<model_Usp_Adm_S_ListarNacionalidades>> fncACC_ListaNacionalidad()
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            try
            {
                return _respuesta.AddData(
                    _model_PERSONA.ExecuteStoredProcedureList<model_Usp_Adm_S_ListarNacionalidades>("dbo.Usp_Adm_S_ListarNacionalidades", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Adm_S_ListarNacionalidades>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        //public Response<List<model_Usp_Adm_S_ListarCiudades>> fncACC_ListaCiudad(short idNacionalidad)
        //{
        //    List<SqlParameter> Parametros = new List<SqlParameter>() { new SqlParameter("@IdNacionalidad", idNacionalidad) };
        //    try
        //    {
        //        return _respuesta.AddData(
        //            _model_PERSONA.ExecuteStoredProcedureList<model_Usp_Adm_S_ListarCiudades>("dbo.Usp_Adm_S_ListarCiudades", Parametros)
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        return _respuesta.AddError<List<model_Usp_Adm_S_ListarCiudades>>(new[] {
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
        //            , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
        //        });
        //    }
        //}

        public Response<List<model_Usp_Adm_S_ListarProvincias>> fncACC_ListaProvincia(short idCiudad)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() { new SqlParameter("@IdCiudad", idCiudad) };
            try
            {
                return _respuesta.AddData(
                    _model_PERSONA.ExecuteStoredProcedureList<model_Usp_Adm_S_ListarProvincias>("dbo.Usp_Adm_S_ListarProvincias", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Adm_S_ListarProvincias>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Adm_S_ListarDistritos>> fncACC_ListaDistrito(short idProvincia)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() { new SqlParameter("@IdProvincia", idProvincia) };
            try
            {
                return _respuesta.AddData(
                    _model_PERSONA.ExecuteStoredProcedureList<model_Usp_Adm_S_ListarDistritos>("dbo.Usp_Adm_S_ListarDistritos", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Adm_S_ListarDistritos>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
