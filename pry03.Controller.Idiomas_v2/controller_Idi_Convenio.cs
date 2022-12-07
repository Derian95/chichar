using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_Convenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Convenio _acc_Idi_Convenio = new access_Idi_Convenio();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_Convenio>> fncCON_VisualListaConvenio()
        {
            Response<List<model_Idi_Convenio>> data_Idi_Convenio = _acc_Idi_Convenio.fncACC_ListaConvenioCompleta();

            if (!data_Idi_Convenio.Success) { return _respuesta.AddError<List<model_dto_Convenio>>(data_Idi_Convenio.MensajeError); }

            List<model_dto_Convenio> informacion = new List<model_dto_Convenio>();

            foreach (model_Idi_Convenio reg in data_Idi_Convenio.Data)
            {
                informacion.Add(new model_dto_Convenio(
                    reg.IdIdi_Convenio
                    , reg.IdIdi_EntidadConvenio
                    , reg.Idi_EntidadConvenio.Nombre
                    , reg.Documento
                    , reg.Pension
                    , reg.FechaInicio
                    , reg.FechaFin
                ));
            }

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarConvenio(model_Idi_Convenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Convenio informacion = new model_Idi_Convenio
            {
                IdIdi_Convenio = entidad.IdIdi_Convenio,
                IdIdi_EntidadConvenio = entidad.IdIdi_EntidadConvenio,
                Documento = entidad.Documento,
                Pension = entidad.Pension,
                FechaInicio = entidad.FechaInicio,
                FechaFin = entidad.FechaFin,
                Estado = 1,
                Activo = true,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC(),
            };

            Response<short> dataRegistro = _acc_Idi_Convenio.fncACC_RegistrarConvenio(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarConvenio(model_Idi_Convenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Convenio> informacion = _acc_Idi_Convenio.fncACC_ConvenioIndividual(entidad.IdIdi_Convenio);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdIdi_EntidadConvenio = entidad.IdIdi_EntidadConvenio;
            informacion.Data.Documento = entidad.Documento;
            informacion.Data.Pension = entidad.Pension;
            informacion.Data.FechaInicio = entidad.FechaInicio;
            informacion.Data.FechaFin = entidad.FechaFin;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();

            Response<short> dataModificacion = _acc_Idi_Convenio.fncACC_ActualizarConvenio(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
