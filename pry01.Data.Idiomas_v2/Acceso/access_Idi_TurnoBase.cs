using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_TurnoBase
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_TurnoBase> _model_Idi_TurnoBase = new rep_Matrix<model_Idi_TurnoBase>();

        public Response<List<model_Idi_TurnoBase>> fncACC_ListaTurnoBase()
        {
            try { return _respuesta.AddData(_model_Idi_TurnoBase.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_TurnoBase>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_TurnoBase> fncACC_TurnoBaseIndividual(short idIdi_TurnoBase)
        {
            try { return _respuesta.AddData(_model_Idi_TurnoBase.Obtener(c => c.IdIdi_TurnoBase == idIdi_TurnoBase)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_TurnoBase>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarTurnoBase(model_Idi_TurnoBase entidad)
        {
            try
            {
                _model_Idi_TurnoBase.Agregar(entidad);
                _model_Idi_TurnoBase.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TurnoBase);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarTurnoBase(model_Idi_TurnoBase entidad)
        {
            try
            {
                _model_Idi_TurnoBase.Modificar(entidad);
                _model_Idi_TurnoBase.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TurnoBase);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }
    }
}
