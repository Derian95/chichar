using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_NivelCurso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_NivelCurso> _model_Idi_NivelCurso = new rep_Matrix<model_Idi_NivelCurso>();

        public Response<List<model_Idi_NivelCurso>> fncACC_ListaNivelCurso()
        {
            try { return _respuesta.AddData(_model_Idi_NivelCurso.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_NivelCurso>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_NivelCurso> fncACC_NivelCursoIndividual(short idIdi_NivelCurso)
        {
            try { return _respuesta.AddData(_model_Idi_NivelCurso.Obtener(c => c.IdIdi_NivelCurso == idIdi_NivelCurso)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_NivelCurso>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarNivelCurso(model_Idi_NivelCurso entidad)
        {
            try
            {
                _model_Idi_NivelCurso.Agregar(entidad);
                _model_Idi_NivelCurso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_NivelCurso);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarNivelCurso(model_Idi_NivelCurso entidad)
        {
            try
            {
                _model_Idi_NivelCurso.Modificar(entidad);
                _model_Idi_NivelCurso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_NivelCurso);
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
