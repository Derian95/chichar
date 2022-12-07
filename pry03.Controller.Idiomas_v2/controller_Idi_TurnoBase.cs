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
    public class controller_Idi_TurnoBase
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_TurnoBase _acc_Idi_TurnoBase = new access_Idi_TurnoBase();

        public Response<List<model_Idi_TurnoBase>> fncCON_ListaTurnoBase()
        {
            Response<List<model_Idi_TurnoBase>> data_Idi_TurnoBase = _acc_Idi_TurnoBase.fncACC_ListaTurnoBase();

            if (!data_Idi_TurnoBase.Success) { return _respuesta.AddError<List<model_Idi_TurnoBase>>(data_Idi_TurnoBase.MensajeError); }

            List<model_Idi_TurnoBase> informacion = data_Idi_TurnoBase.Data.Select(c => new model_Idi_TurnoBase
            {
                IdIdi_TurnoBase = c.IdIdi_TurnoBase,
                Descripcion = c.Descripcion
            }).OrderByDescending(c => c.IdIdi_TurnoBase).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarTurnoBase(model_Idi_TurnoBase entidad)
        {
            model_Idi_TurnoBase informacion = new model_Idi_TurnoBase
            {
                IdIdi_TurnoBase = entidad.IdIdi_TurnoBase,
                Descripcion = entidad.Descripcion
            };

            Response<short> dataRegistro = _acc_Idi_TurnoBase.fncACC_RegistrarTurnoBase(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarTurnoBase(model_Idi_TurnoBase entidad)
        {
            Response<model_Idi_TurnoBase> informacion = _acc_Idi_TurnoBase.fncACC_TurnoBaseIndividual(entidad.IdIdi_TurnoBase);
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

            Response<short> dataModificacion = _acc_Idi_TurnoBase.fncACC_ActualizarTurnoBase(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
