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
    public class controller_Idi_TurnoDetalle
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_TurnoDetalle _acc_Idi_TurnoDetalle = new access_Idi_TurnoDetalle();

        public Response<List<model_Idi_TurnoDetalle>> fncCON_ListaTurnoDetalle(short idIdi_TurnoBase)
        {
            Response<List<model_Idi_TurnoDetalle>> data_Idi_TurnoDetalle = _acc_Idi_TurnoDetalle.fncACC_ListaTurnoDetalle(idIdi_TurnoBase);

            if (!data_Idi_TurnoDetalle.Success) { return _respuesta.AddError<List<model_Idi_TurnoDetalle>>(data_Idi_TurnoDetalle.MensajeError); }

            List<model_Idi_TurnoDetalle> informacion = data_Idi_TurnoDetalle.Data.Select(c => new model_Idi_TurnoDetalle
            {
                IdIdi_TurnoDetalle = c.IdIdi_TurnoDetalle,
                IdIdi_TurnoBase = c.IdIdi_TurnoBase,
                NumeroDia = c.NumeroDia,
                Desde = c.Desde,
                Hasta = c.Hasta,
                Estado = c.Estado
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarTurnoDetalle(model_Idi_TurnoDetalle entidad)
        {
            model_Idi_TurnoDetalle informacion = new model_Idi_TurnoDetalle
            {
                IdIdi_TurnoDetalle = entidad.IdIdi_TurnoDetalle,
                IdIdi_TurnoBase = entidad.IdIdi_TurnoBase,
                NumeroDia = entidad.NumeroDia,
                Desde = entidad.Desde,
                Hasta = entidad.Hasta,
                Estado = 1
            };

            Response<short> dataRegistro = _acc_Idi_TurnoDetalle.fncACC_RegistrarTurnoDetalle(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarTurnoDetalle(model_Idi_TurnoDetalle entidad)
        {
            Response<model_Idi_TurnoDetalle> informacion = _acc_Idi_TurnoDetalle.fncACC_TurnoDetalleIndividual(entidad.IdIdi_TurnoDetalle);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdIdi_TurnoDetalle = entidad.IdIdi_TurnoDetalle;
            informacion.Data.IdIdi_TurnoBase = entidad.IdIdi_TurnoBase;
            informacion.Data.NumeroDia = entidad.NumeroDia;
            informacion.Data.Desde = entidad.Desde;
            informacion.Data.Hasta = entidad.Hasta;
            informacion.Data.Estado = entidad.Estado;

            Response<short> dataModificacion = _acc_Idi_TurnoDetalle.fncACC_ActualizarTurnoDetalle(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
