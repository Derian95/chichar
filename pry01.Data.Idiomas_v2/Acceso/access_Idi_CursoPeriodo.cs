using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_CursoPeriodo
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_CursoPeriodo> _model_Idi_CursoPeriodo = new rep_Matrix<model_Idi_CursoPeriodo>();

        public Response<List<model_Idi_CursoPeriodo>> fncACC_ListaCursoPeriodo(int idIdi_PeriodoEnsenianza)
        {
            try { return _respuesta.AddData(_model_Idi_CursoPeriodo.ObtenerListado(where: c => c.IdIdi_PeriodoEnsenianza == idIdi_PeriodoEnsenianza).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_CursoPeriodo>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_CursoPeriodo> fncACC_CursoPeriodoIndividual(int idIdi_CursoPeriodo)
        {
            try { return _respuesta.AddData(_model_Idi_CursoPeriodo.Obtener(c => c.IdIdi_CursoPeriodo == idIdi_CursoPeriodo)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_CursoPeriodo>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarCursoPeriodo(model_Idi_CursoPeriodo entidad)
        {
            try
            {
                _model_Idi_CursoPeriodo.Agregar(entidad);
                _model_Idi_CursoPeriodo.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_CursoPeriodo);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarCursoPeriodo(model_Idi_CursoPeriodo entidad)
        {
            try
            {
                _model_Idi_CursoPeriodo.Modificar(entidad);
                _model_Idi_CursoPeriodo.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_CursoPeriodo);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }
    }
}
