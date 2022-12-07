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
    public class controller_ESTUDIANTE
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_ESTUDIANTE _acc_ESTUDIANTE = new access_ESTUDIANTE();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_ESTUDIANTE>> fncCON_ListaESTUDIANTE(int codUniv)
        {
            Response<List<model_ESTUDIANTE>> data_ESTUDIANTE = _acc_ESTUDIANTE.fncACC_ListaESTUDIANTE(codUniv);

            if (!data_ESTUDIANTE.Success) { return _respuesta.AddError<List<model_ESTUDIANTE>>(data_ESTUDIANTE.MensajeError); }

            List<model_ESTUDIANTE> informacion = data_ESTUDIANTE.Data.Select(c => new model_ESTUDIANTE
            {
                CodigoUniversitario = c.CodigoUniversitario,
                ItemEstudiante = c.ItemEstudiante,
                CodigoPersona = c.CodigoPersona,
                IdDependencia = c.IdDependencia,
                CodigoEstamento = c.CodigoEstamento,
                FechaIngreso = c.FechaIngreso,
                Activo = c.Activo,
                Observacion = c.Observacion,
                Usuario = c.Usuario,
                Fecha = c.Fecha,
                ModalidadIngreso = c.ModalidadIngreso
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarESTUDIANTE(model_ESTUDIANTE entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_ESTUDIANTE informacion = new model_ESTUDIANTE
            {
                CodigoUniversitario = entidad.CodigoUniversitario,
                ItemEstudiante = entidad.ItemEstudiante,
                CodigoPersona = entidad.CodigoPersona,
                IdDependencia = entidad.IdDependencia,
                CodigoEstamento = entidad.CodigoEstamento,
                FechaIngreso = entidad.FechaIngreso,
                Activo = 1,
                Observacion = entidad.Observacion,
                Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString(),
                Fecha = dataFechaServidor.Data[0].FechaHoraServidor,
                ModalidadIngreso = entidad.ModalidadIngreso
            };

            Response<int> dataRegistro = _acc_ESTUDIANTE.fncACC_RegistrarESTUDIANTE(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarESTUDIANTE(model_ESTUDIANTE entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_ESTUDIANTE> informacion = _acc_ESTUDIANTE.fncACC_ESTUDIANTEIndividual(entidad.CodigoUniversitario);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.CodigoUniversitario = entidad.CodigoUniversitario;
            informacion.Data.ItemEstudiante = entidad.ItemEstudiante;
            informacion.Data.CodigoPersona = entidad.CodigoPersona;
            informacion.Data.IdDependencia = entidad.IdDependencia;
            informacion.Data.CodigoEstamento = entidad.CodigoEstamento;
            informacion.Data.FechaIngreso = entidad.FechaIngreso;
            informacion.Data.Activo = entidad.Activo;
            informacion.Data.Observacion = entidad.Observacion;
            informacion.Data.Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString();
            informacion.Data.Fecha = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.ModalidadIngreso = entidad.ModalidadIngreso;

            Response<int> dataModificacion = _acc_ESTUDIANTE.fncACC_ActualizarESTUDIANTE(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }

        public Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> fncCON_RelacionEstudiantes(int codigoUniversitario = -1
            , string numeroDocumento = _defaultString
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , string nombres = _defaultString)
        {
            Response<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>> dataPersona = _acc_ESTUDIANTE.fncACC_RelacionEstudiantes(codigoUniversitario, numeroDocumento, apellidoPaterno, apellidoMaterno, nombres);

            if (!dataPersona.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_ListarEstudianteParaIdiomas>>(dataPersona.MensajeError); }

            List<model_Usp_Idi_S_ListarEstudianteParaIdiomas> informacion = dataPersona.Data.ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
