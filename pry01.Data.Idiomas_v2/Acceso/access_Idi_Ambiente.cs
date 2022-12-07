using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Ambiente
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Ambiente> _model_Idi_Ambiente = new rep_Matrix<model_Idi_Ambiente>();

        public Response<List<model_Idi_Ambiente>> fncACC_ListaAmbiente()
        {
            try { return _respuesta.AddData(_model_Idi_Ambiente.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Ambiente>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Ambiente> fncACC_AmbienteIndividual(short idIdi_Ambiente)
        {
            try { return _respuesta.AddData(_model_Idi_Ambiente.Obtener(c => c.IdIdi_Ambiente == idIdi_Ambiente)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Ambiente>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarAmbiente(model_Idi_Ambiente entidad)
        {
            try
            {
                _model_Idi_Ambiente.Agregar(entidad);
                _model_Idi_Ambiente.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Ambiente);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarAmbiente(model_Idi_Ambiente entidad)
        {
            try
            {
                _model_Idi_Ambiente.Modificar(entidad);
                _model_Idi_Ambiente.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Ambiente);
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
