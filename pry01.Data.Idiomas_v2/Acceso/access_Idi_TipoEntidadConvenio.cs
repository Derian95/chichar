using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_TipoEntidadConvenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_TipoEntidadConvenio> _model_Idi_TipoEntidadConvenio = new rep_Matrix<model_Idi_TipoEntidadConvenio>();

        public Response<List<model_Idi_TipoEntidadConvenio>> fncACC_ListaTipoEntidadConvenio()
        {
            try { return _respuesta.AddData(_model_Idi_TipoEntidadConvenio.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_TipoEntidadConvenio>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_TipoEntidadConvenio> fncACC_TipoEntidadConvenioIndividual(short idIdi_TipoEntidadConvenio)
        {
            try { return _respuesta.AddData(_model_Idi_TipoEntidadConvenio.Obtener(c => c.IdIdi_TipoEntidadConvenio == idIdi_TipoEntidadConvenio)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_TipoEntidadConvenio>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarTipoEntidadConvenio(model_Idi_TipoEntidadConvenio entidad)
        {
            try
            {
                _model_Idi_TipoEntidadConvenio.Agregar(entidad);
                _model_Idi_TipoEntidadConvenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TipoEntidadConvenio);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarTipoEntidadConvenio(model_Idi_TipoEntidadConvenio entidad)
        {
            try
            {
                _model_Idi_TipoEntidadConvenio.Modificar(entidad);
                _model_Idi_TipoEntidadConvenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TipoEntidadConvenio);
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
