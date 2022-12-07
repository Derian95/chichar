using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_TipoCurso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_TipoCurso> _model_Idi_TipoCurso = new rep_Matrix<model_Idi_TipoCurso>();

        public Response<List<model_Idi_TipoCurso>> fncACC_ListaTipoCurso()
        {
            try { return _respuesta.AddData(_model_Idi_TipoCurso.ObtenerListado().ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_TipoCurso>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_TipoCurso> fncACC_TipoCursoIndividual(short idIdi_TipoCurso)
        {
            try { return _respuesta.AddData(_model_Idi_TipoCurso.Obtener(c => c.IdIdi_TipoCurso == idIdi_TipoCurso)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_TipoCurso>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarTipoCurso(model_Idi_TipoCurso entidad)
        {
            try
            {
                _model_Idi_TipoCurso.Agregar(entidad);
                _model_Idi_TipoCurso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TipoCurso);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarTipoCurso(model_Idi_TipoCurso entidad)
        {
            try
            {
                _model_Idi_TipoCurso.Modificar(entidad);
                _model_Idi_TipoCurso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_TipoCurso);
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
