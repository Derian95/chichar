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
    public class access_SEMESTRE
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_SEMESTRE> _model_SEMESTRE = new rep_Matrix<model_SEMESTRE>();

        public Response<List<model_SEMESTRE>> fncACC_ListaSEMESTRE()
        {
            try { return _respuesta.AddData(_model_SEMESTRE.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_SEMESTRE>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_SEMESTRE> fncACC_SEMESTREIndividual(int idSemestre)
        {
            try { return _respuesta.AddData(_model_SEMESTRE.Obtener(where: c => c.IdSemestre == idSemestre)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_SEMESTRE>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarSEMESTRE(model_SEMESTRE entidad)
        {
            try
            {
                _model_SEMESTRE.Agregar(entidad);
                _model_SEMESTRE.GuardarCambios();
                return _respuesta.AddData(entidad.IdSemestre);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarSEMESTRE(model_SEMESTRE entidad)
        {
            try
            {
                _model_SEMESTRE.Modificar(entidad);
                _model_SEMESTRE.GuardarCambios();
                return _respuesta.AddData(entidad.IdSemestre);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Idi_S_ObtenerModalidadSemestre>> fncACC_ObtenerModalidadSemestre(string mesRomano, int claseSemestre)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() {
                new SqlParameter("@MesRomano", mesRomano)
                , new SqlParameter("@ClaseSemestre", claseSemestre)
            };
            try
            {
                return _respuesta.AddData(
                    _model_SEMESTRE.ExecuteStoredProcedureList<model_Usp_Idi_S_ObtenerModalidadSemestre>("dbo.Usp_Idi_S_ObtenerModalidadSemestre", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_ObtenerModalidadSemestre>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Idi_S_ObtenerMaximoIdSem>> fncACC_ObtenerMaximoIdSem(short anio, byte mes)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>() {
                new SqlParameter("@Anio", anio)
                , new SqlParameter("@Mes", mes)
            };
            try
            {
                return _respuesta.AddData(
                    _model_SEMESTRE.ExecuteStoredProcedureList<model_Usp_Idi_S_ObtenerMaximoIdSem>("dbo.Usp_Idi_S_ObtenerMaximoIdSem", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_ObtenerMaximoIdSem>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
