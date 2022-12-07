using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Examen
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Examen> _model_Idi_Examen = new rep_Matrix<model_Idi_Examen>();

        public Response<List<model_Idi_Examen>> fncACC_ListaExamen()
        {
            try { return _respuesta.AddData(_model_Idi_Examen.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Examen>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Examen> fncACC_ExamenIndividual(short idIdi_Examen)
        {
            try { return _respuesta.AddData(_model_Idi_Examen.Obtener(c => c.IdIdi_Examen == idIdi_Examen)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Examen>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarExamen(model_Idi_Examen entidad)
        {
            try
            {
                _model_Idi_Examen.Agregar(entidad);
                _model_Idi_Examen.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Examen);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarExamen(model_Idi_Examen entidad)
        {
            try
            {
                _model_Idi_Examen.Modificar(entidad);
                _model_Idi_Examen.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Examen);
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
