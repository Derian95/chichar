using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_EntidadConvenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_EntidadConvenio> _model_Idi_EntidadConvenio = new rep_Matrix<model_Idi_EntidadConvenio>();

        public Response<List<model_Idi_EntidadConvenio>> fncACC_ListaEntidadConvenio()
        {
            try { return _respuesta.AddData(_model_Idi_EntidadConvenio.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_EntidadConvenio>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_EntidadConvenio> fncACC_EntidadConvenioIndividual(short idIdi_EntidadConvenio)
        {
            try { return _respuesta.AddData(_model_Idi_EntidadConvenio.Obtener(c => c.IdIdi_EntidadConvenio == idIdi_EntidadConvenio)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_EntidadConvenio>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarEntidadConvenio(model_Idi_EntidadConvenio entidad)
        {
            try
            {
                _model_Idi_EntidadConvenio.Agregar(entidad);
                _model_Idi_EntidadConvenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_EntidadConvenio);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarEntidadConvenio(model_Idi_EntidadConvenio entidad)
        {
            try
            {
                _model_Idi_EntidadConvenio.Modificar(entidad);
                _model_Idi_EntidadConvenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_EntidadConvenio);
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
