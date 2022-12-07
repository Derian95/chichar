using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_TipoEntidadConvenio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_TipoEntidadConvenio _acc_Idi_TipoEntidadConvenio = new access_Idi_TipoEntidadConvenio();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_Idi_TipoEntidadConvenio>> fncCON_ListaTipoEntidadConvenio()
        {
            Response<List<model_Idi_TipoEntidadConvenio>> data_Idi_TipoEntidadConvenio = _acc_Idi_TipoEntidadConvenio.fncACC_ListaTipoEntidadConvenio();

            if (!data_Idi_TipoEntidadConvenio.Success) { return _respuesta.AddError<List<model_Idi_TipoEntidadConvenio>>(data_Idi_TipoEntidadConvenio.MensajeError); }

            List<model_Idi_TipoEntidadConvenio> informacion = data_Idi_TipoEntidadConvenio.Data.Select(c => new model_Idi_TipoEntidadConvenio
            {
                IdIdi_TipoEntidadConvenio = c.IdIdi_TipoEntidadConvenio,
                Descripcion = c.Descripcion,
                Abreviacion = c.Abreviacion,
                _IdTipoEntidad = c._IdTipoEntidad
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarTipoEntidadConvenio(model_Idi_TipoEntidadConvenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_TipoEntidadConvenio informacion = new model_Idi_TipoEntidadConvenio
            {
                IdIdi_TipoEntidadConvenio = entidad.IdIdi_TipoEntidadConvenio,
                Descripcion = entidad.Descripcion,
                Abreviacion = entidad.Abreviacion
            };

            Response<short> dataRegistro = _acc_Idi_TipoEntidadConvenio.fncACC_RegistrarTipoEntidadConvenio(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarTipoEntidadConvenio(model_Idi_TipoEntidadConvenio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_TipoEntidadConvenio> informacion = _acc_Idi_TipoEntidadConvenio.fncACC_TipoEntidadConvenioIndividual(entidad.IdIdi_TipoEntidadConvenio);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.Descripcion = entidad.Descripcion;
            informacion.Data.Abreviacion = entidad.Abreviacion;

            Response<short> dataModificacion = _acc_Idi_TipoEntidadConvenio.fncACC_ActualizarTipoEntidadConvenio(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
