using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEnumerable;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_EntidadConvenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_EntidadConvenio _acc_Idi_EntidadConvenio = new access_Idi_EntidadConvenio();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_EntidadConvenio>> fncCON_VisualListaEntidadConvenio()
        {
            Response<List<model_Idi_EntidadConvenio>> data_Idi_EntidadConvenio = _acc_Idi_EntidadConvenio.fncACC_ListaEntidadConvenio();

            if (!data_Idi_EntidadConvenio.Success) { return _respuesta.AddError<List<model_dto_EntidadConvenio>>(data_Idi_EntidadConvenio.MensajeError); }

            List<model_dto_EntidadConvenio> informacion = data_Idi_EntidadConvenio.Data.Select(c => new model_dto_EntidadConvenio
            {
                IdIdi_EntidadConvenio = c.IdIdi_EntidadConvenio,
                IdIdi_TipoEntidadConvenio = c.IdIdi_TipoEntidadConvenio,
                //TipoEntidadConvenio = _getCustomPropertyEnum<customDescripcion>((enmTipoEntidadConvenio)c.IdIdi_TipoEntidadConvenio).Descripcion,
                Nombre = c.Nombre
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarEntidadConvenio(model_Idi_EntidadConvenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_EntidadConvenio informacion = new model_Idi_EntidadConvenio
            {
                IdIdi_EntidadConvenio = entidad.IdIdi_EntidadConvenio,
                IdIdi_TipoEntidadConvenio = entidad.IdIdi_TipoEntidadConvenio,
                Nombre = entidad.Nombre
            };

            Response<short> dataRegistro = _acc_Idi_EntidadConvenio.fncACC_RegistrarEntidadConvenio(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarEntidadConvenio(model_Idi_EntidadConvenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_EntidadConvenio> informacion = _acc_Idi_EntidadConvenio.fncACC_EntidadConvenioIndividual(entidad.IdIdi_EntidadConvenio);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdIdi_TipoEntidadConvenio = entidad.IdIdi_TipoEntidadConvenio;
            informacion.Data.Nombre = entidad.Nombre;

            Response<short> dataModificacion = _acc_Idi_EntidadConvenio.fncACC_ActualizarEntidadConvenio(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
