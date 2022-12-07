using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_PERSONA
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_PERSONA _acc_PERSONA = new access_PERSONA();
        private readonly access_General _accGeneral = new access_General();

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarPERSONA(model_PERSONA entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_PERSONA informacion = new model_PERSONA
            {
                CodigoPersona = entidad.CodigoPersona,
                CodigoEstamento = entidad.CodigoEstamento,
                ApellidoPaterno = entidad.ApellidoPaterno,
                ApellidoMaterno = entidad.ApellidoMaterno,
                Nombre = entidad.Nombre,
                NumeroDocumento = entidad.NumeroDocumento,
                Direccion = entidad.Direccion,
                FechaNacimiento = entidad.FechaNacimiento,
                CodigoLugarNacimiento = entidad.CodigoLugarNacimiento,
                TelefonoFijo = entidad.TelefonoFijo,
                TelefonoCelular = entidad.TelefonoCelular,
                Sexo = entidad.Sexo,
                Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString(),
                Fecha = dataFechaServidor.Data[0].FechaHoraServidor,
                Email = entidad.Email,
                Activo = true,
                TipoDocumento = entidad.TipoDocumento
            };

            Response<int> dataRegistro = _acc_PERSONA.fncACC_RegistrarPERSONA(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarPERSONA(model_PERSONA entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_PERSONA> informacion = _acc_PERSONA.fncACC_PERSONAIndividual(entidad.CodigoPersona);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.CodigoPersona = entidad.CodigoPersona;
            informacion.Data.CodigoEstamento = entidad.CodigoEstamento;
            informacion.Data.ApellidoPaterno = entidad.ApellidoPaterno;
            informacion.Data.ApellidoMaterno = entidad.ApellidoMaterno;
            informacion.Data.Nombre = entidad.Nombre;
            informacion.Data.NumeroDocumento = entidad.NumeroDocumento;
            informacion.Data.Direccion = entidad.Direccion;
            informacion.Data.FechaNacimiento = entidad.FechaNacimiento;
            informacion.Data.CodigoLugarNacimiento = entidad.CodigoLugarNacimiento;
            informacion.Data.TelefonoFijo = entidad.TelefonoFijo;
            informacion.Data.TelefonoCelular = entidad.TelefonoCelular;
            informacion.Data.Sexo = entidad.Sexo;
            informacion.Data.Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString();
            informacion.Data.Fecha = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.Email = entidad.Email;
            informacion.Data.Activo = entidad.Activo;
            informacion.Data.TipoDocumento = entidad.TipoDocumento;

            Response<int> dataModificacion = _acc_PERSONA.fncACC_ActualizarPERSONA(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }

        public Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> fncCON_RelacionPersonas(int codigoPersona = -1
            , string numeroDocumento = _defaultString
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , string nombres = _defaultString)
        {
            Response<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>> data_PERSONA = _acc_PERSONA.fncACC_RelacionPersonas(codigoPersona, numeroDocumento, apellidoPaterno, apellidoMaterno, nombres);

            if (!data_PERSONA.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_ListarPersonaParaIdiomas>>(data_PERSONA.MensajeError); }

            List<model_Usp_Idi_S_ListarPersonaParaIdiomas> informacion = data_PERSONA.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_Usp_Adm_S_ListarNacionalidades>> fncCON_ListaNacionalidad()
        {
            Response<List<model_Usp_Adm_S_ListarNacionalidades>> data_Nacionalidad = _acc_PERSONA.fncACC_ListaNacionalidad();

            if (!data_Nacionalidad.Success) { return _respuesta.AddError<List<model_Usp_Adm_S_ListarNacionalidades>>(data_Nacionalidad.MensajeError); }

            List<model_Usp_Adm_S_ListarNacionalidades> informacion = data_Nacionalidad.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_ciudad>> fncCON_Lista_ciudad(short idNacionalidad)
        {
            Response<List<model_ciudad>> data_Ciudad = _acc_PERSONA.fncACC_Lista_ciudad(idNacionalidad);

            if (!data_Ciudad.Success) { return _respuesta.AddError<List<model_ciudad>>(data_Ciudad.MensajeError); }

            List<model_ciudad> informacion = data_Ciudad.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_Usp_Adm_S_ListarProvincias>> fncCON_ListaProvincia(short idCiudad)
        {
            Response<List<model_Usp_Adm_S_ListarProvincias>> data_Provincia = _acc_PERSONA.fncACC_ListaProvincia(idCiudad);

            if (!data_Provincia.Success) { return _respuesta.AddError<List<model_Usp_Adm_S_ListarProvincias>>(data_Provincia.MensajeError); }

            List<model_Usp_Adm_S_ListarProvincias> informacion = data_Provincia.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_Usp_Adm_S_ListarDistritos>> fncCON_ListaDistrito(short idProvincia)
        {
            Response<List<model_Usp_Adm_S_ListarDistritos>> data_Distrito = _acc_PERSONA.fncACC_ListaDistrito(idProvincia);

            if (!data_Distrito.Success) { return _respuesta.AddError<List<model_Usp_Adm_S_ListarDistritos>>(data_Distrito.MensajeError); }

            List<model_Usp_Adm_S_ListarDistritos> informacion = data_Distrito.Data.ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
