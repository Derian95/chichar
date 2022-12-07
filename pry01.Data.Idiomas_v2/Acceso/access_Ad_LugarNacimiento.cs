using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Ad_LugarNacimiento
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Ad_LugarNacimiento> _model_Ad_LugarNacimiento = new rep_Matrix<model_Ad_LugarNacimiento>();

        public Response<List<model_Ad_LugarNacimiento>> fncACC_ListaLugarNacimientoPersona(int codigoPersona = -1)
        {
            try
            {
                return _respuesta.AddData(_model_Ad_LugarNacimiento.ObtenerListado(
                    where: c=> (c.CodigoPersona == codigoPersona || codigoPersona == -1) && (c.Estado == 1)
                ).ToList());
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Ad_LugarNacimiento>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Ad_LugarNacimiento> fncACC_LugarNacimientoIndividual(int idLugarNacimiento)
        {
            try { return _respuesta.AddData(_model_Ad_LugarNacimiento.Obtener(c => c.IdLugarNacimiento == idLugarNacimiento)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Ad_LugarNacimiento>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_RegistrarLugarNacimiento(model_Ad_LugarNacimiento entidad)
        {
            try
            {
                _model_Ad_LugarNacimiento.Agregar(entidad);
                _model_Ad_LugarNacimiento.GuardarCambios();
                return _respuesta.AddData(entidad.IdLugarNacimiento);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarLugarNacimiento(model_Ad_LugarNacimiento entidad)
        {
            try
            {
                _model_Ad_LugarNacimiento.Modificar(entidad);
                _model_Ad_LugarNacimiento.GuardarCambios();
                return _respuesta.AddData(entidad.IdLugarNacimiento);
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
