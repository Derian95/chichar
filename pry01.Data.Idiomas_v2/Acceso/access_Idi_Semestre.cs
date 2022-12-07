using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Semestre
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Semestre> _model_Idi_Semestre = new rep_Matrix<model_Idi_Semestre>();

        public Response<List<model_Idi_Semestre>> fncACC_ListaSemestre(short anio)
        {
            try
            {
                return _respuesta.AddData(_model_Idi_Semestre.ObtenerListado(where: c => c.Estado == 1 && (c.Anio == anio || anio == -1)).ToList());
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Semestre>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Semestre> fncACC_SemestreIndividual(short idIdi_Semestre)
        {
            try { return _respuesta.AddData(_model_Idi_Semestre.Obtener(c => c.IdIdi_Semestre == idIdi_Semestre)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Semestre>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarSemestre(model_Idi_Semestre entidad)
        {
            try
            {
                _model_Idi_Semestre.Agregar(entidad);
                _model_Idi_Semestre.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Semestre);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarSemestre(model_Idi_Semestre entidad)
        {
            try
            {
                _model_Idi_Semestre.Modificar(entidad);
                _model_Idi_Semestre.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Semestre);
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
