using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Horario
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Horario> _model_Idi_Horario = new rep_Matrix<model_Idi_Horario>();

        public Response<List<model_Idi_Horario>> fncACC_ListaHorario(int idIdi_Curso)
        {
            try { return _respuesta.AddData(_model_Idi_Horario.ObtenerListado(where: c => c.IdIdi_Curso == idIdi_Curso).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Horario>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Horario> fncACC_HorarioIndividual(int idIdi_Horario)
        {
            try { return _respuesta.AddData(_model_Idi_Horario.Obtener(c => c.IdIdi_Horario == idIdi_Horario)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Horario>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarHorario(model_Idi_Horario entidad)
        {
            try
            {
                _model_Idi_Horario.Agregar(entidad);
                _model_Idi_Horario.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Horario);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarHorario(model_Idi_Horario entidad)
        {
            try
            {
                _model_Idi_Horario.Modificar(entidad);
                _model_Idi_Horario.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Horario);
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
