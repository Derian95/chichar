using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Convenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Convenio> _model_Idi_Convenio = new rep_Matrix<model_Idi_Convenio>();

        public Response<List<model_Idi_Convenio>> fncACC_ListaConvenio()
        {
            try { return _respuesta.AddData(_model_Idi_Convenio.ObtenerListado().OrderByDescending(c => c.IdIdi_Convenio).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Convenio>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<List<model_Idi_Convenio>> fncACC_ListaConvenioCompleta()
        {
            try { return _respuesta.AddData(_model_Idi_Convenio.ObtenerListado(c => c.Idi_EntidadConvenio).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Convenio>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Convenio> fncACC_ConvenioIndividual(short idIdi_Convenio)
        {
            try { return _respuesta.AddData(_model_Idi_Convenio.Obtener(c => c.IdIdi_Convenio == idIdi_Convenio)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Convenio>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarConvenio(model_Idi_Convenio entidad)
        {
            try
            {
                _model_Idi_Convenio.Agregar(entidad);
                _model_Idi_Convenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Convenio);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarConvenio(model_Idi_Convenio entidad)
        {
            try
            {
                _model_Idi_Convenio.Modificar(entidad);
                _model_Idi_Convenio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Convenio);
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
