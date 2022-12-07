using Microsoft.Data.SqlClient;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Prerrequisito
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Prerrequisito> _model_Idi_Prerrequisito = new rep_Matrix<model_Idi_Prerrequisito>();

        public Response<List<model_Idi_Prerrequisito>> fncACC_ListaPrerrequisito()
        {
            try { return _respuesta.AddData(_model_Idi_Prerrequisito.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Prerrequisito>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Prerrequisito> fncACC_PrerrequisitoIndividual(short idIdi_Prerrequisito)
        {
            try { return _respuesta.AddData(_model_Idi_Prerrequisito.Obtener(c => c.IdIdi_Prerrequisito == idIdi_Prerrequisito)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Prerrequisito>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarPrerrequisito(model_Idi_Prerrequisito entidad)
        {
            try
            {
                _model_Idi_Prerrequisito.Agregar(entidad);
                _model_Idi_Prerrequisito.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Prerrequisito);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarPrerrequisito(model_Idi_Prerrequisito entidad)
        {
            try
            {
                _model_Idi_Prerrequisito.Modificar(entidad);
                _model_Idi_Prerrequisito.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Prerrequisito);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        //public Response<List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>> fncACC_RelacionCursosYPrerrequisitos(int idDepe, short idIdi_PlanEstudio)
        //{
        //    List<SqlParameter> Parametros = new List<SqlParameter>() { 
        //        new SqlParameter("@IdDepe", idDepe)
        //        , new SqlParameter("@IdIdi_PlanEstudio", idIdi_PlanEstudio) };
        //    try
        //    {
        //        return _respuesta.AddData(
        //            _model_Idi_Prerrequisito.ExecuteStoredProcedureList<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>("dbo.Usp_Idi_S_Idi_ListarCursosYPrerrequisitos", Parametros)
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>>(new[] {
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
        //            , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
        //        });
        //    }
        //}
    }
}
