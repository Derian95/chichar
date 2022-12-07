using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Ad_LugarNacimiento
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Ad_LugarNacimiento _acc_Ad_LugarNacimiento = new access_Ad_LugarNacimiento();

        public Response<List<model_Ad_LugarNacimiento>> fncCON_ListaLugarNacimientoPersona(int codigoPersona)
        {
            Response<List<model_Ad_LugarNacimiento>> data_Ad_LugarNacimiento = _acc_Ad_LugarNacimiento.fncACC_ListaLugarNacimientoPersona(codigoPersona);
            if (!data_Ad_LugarNacimiento.Success)
            {
                return _respuesta.AddError<List<model_Ad_LugarNacimiento>>(data_Ad_LugarNacimiento.MensajeError);
            }

            List<model_Ad_LugarNacimiento> informacion = data_Ad_LugarNacimiento.Data.Select(c => new model_Ad_LugarNacimiento
            {
                IdLugarNacimiento = c.IdLugarNacimiento,
                CodigoPersona = c.CodigoPersona,
                CodigoNacionalidad = c.CodigoNacionalidad,
                CodigoDepartamento = c.CodigoDepartamento,
                CodigoProvincia = c.CodigoProvincia,
                CodigoDistrito = c.CodigoDistrito,
                Estado = c.Estado,
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarAd_LugarNacimiento(model_Ad_LugarNacimiento entidad)
        {
            model_Ad_LugarNacimiento informacion = new model_Ad_LugarNacimiento
            {
                IdLugarNacimiento = entidad.IdLugarNacimiento,
                CodigoPersona = entidad.CodigoPersona,
                CodigoNacionalidad = entidad.CodigoNacionalidad,
                CodigoDepartamento = entidad.CodigoDepartamento,
                CodigoProvincia = entidad.CodigoProvincia,
                CodigoDistrito = entidad.CodigoDistrito,
                Estado = entidad.Estado,
            };

            Response<int> dataRegistro = _acc_Ad_LugarNacimiento.fncACC_RegistrarLugarNacimiento(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarAd_LugarNacimiento(model_Ad_LugarNacimiento entidad)
        {
            Response<model_Ad_LugarNacimiento> informacion = _acc_Ad_LugarNacimiento.fncACC_LugarNacimientoIndividual(entidad.IdLugarNacimiento);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro")
                });
            }

            informacion.Data.IdLugarNacimiento = entidad.IdLugarNacimiento;
            informacion.Data.CodigoPersona = entidad.CodigoPersona;
            informacion.Data.CodigoNacionalidad = entidad.CodigoNacionalidad;
            informacion.Data.CodigoDepartamento = entidad.CodigoDepartamento;
            informacion.Data.CodigoProvincia = entidad.CodigoProvincia;
            informacion.Data.CodigoDistrito = entidad.CodigoDistrito;
            informacion.Data.Estado = entidad.Estado;

            Response<int> dataModificacion = _acc_Ad_LugarNacimiento.fncACC_ActualizarLugarNacimiento(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
