using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.clsEnumerable;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_Ambiente
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Ambiente _acc_Idi_Ambiente = new access_Idi_Ambiente();

        public Response<List<model_dto_Ambiente>> fncCON_VisualListaAmbiente()
        {
            Response<List<model_Idi_Ambiente>> data_Idi_Ambiente = _acc_Idi_Ambiente.fncACC_ListaAmbiente();

            if (!data_Idi_Ambiente.Success) { return _respuesta.AddError<List<model_dto_Ambiente>>(data_Idi_Ambiente.MensajeError); }

            List<model_dto_Ambiente> informacion = data_Idi_Ambiente.Data.Select(c => new model_dto_Ambiente
            {
                IdIdi_Ambiente = c.IdIdi_Ambiente,
                Codigo = c.Codigo,
                Descripcion = c.Descripcion,
                Tipo = c.Tipo,
                NombreTipo = _getCustomPropertyEnum<customDescripcion>((enmTipoAmbiente)c.Tipo).Descripcion,
                Capacidad = c.Capacidad
            }).OrderByDescending(c => c.IdIdi_Ambiente).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarAmbiente(model_Idi_Ambiente entidad)
        {
            model_Idi_Ambiente informacion = new model_Idi_Ambiente
            {
                IdIdi_Ambiente = entidad.IdIdi_Ambiente,
                Codigo = entidad.Codigo,
                Descripcion = entidad.Descripcion,
                Tipo = entidad.Tipo,
                Capacidad = entidad.Capacidad
            };

            Response<short> dataRegistro = _acc_Idi_Ambiente.fncACC_RegistrarAmbiente(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarAmbiente(model_Idi_Ambiente entidad)
        {
            Response<model_Idi_Ambiente> informacion = _acc_Idi_Ambiente.fncACC_AmbienteIndividual(entidad.IdIdi_Ambiente);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.Codigo = entidad.Codigo;
            informacion.Data.Descripcion = entidad.Descripcion;
            informacion.Data.Tipo = entidad.Tipo;
            informacion.Data.Capacidad = entidad.Capacidad;

            Response<short> dataModificacion = _acc_Idi_Ambiente.fncACC_ActualizarAmbiente(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
