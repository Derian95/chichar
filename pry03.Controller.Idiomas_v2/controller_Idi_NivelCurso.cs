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
    public class controller_Idi_NivelCurso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_NivelCurso _acc_Idi_NivelCurso = new access_Idi_NivelCurso();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_Idi_NivelCurso>> fncCON_ListaNivelCurso()
        {
            Response<List<model_Idi_NivelCurso>> data_Idi_NivelCurso = _acc_Idi_NivelCurso.fncACC_ListaNivelCurso();

            if (!data_Idi_NivelCurso.Success) { return _respuesta.AddError<List<model_Idi_NivelCurso>>(data_Idi_NivelCurso.MensajeError); }

            List<model_Idi_NivelCurso> informacion = data_Idi_NivelCurso.Data.Select(c => new model_Idi_NivelCurso
            {
                IdIdi_NivelCurso = c.IdIdi_NivelCurso,
                Nombre = c.Nombre,
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarNivelCurso(model_Idi_NivelCurso entidad)
        {
            Response<List<pry02.Model.Idiomas_v2.Procedimiento.model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_NivelCurso informacion = new model_Idi_NivelCurso
            {
                IdIdi_NivelCurso = entidad.IdIdi_NivelCurso,
                Nombre = entidad.Nombre,
            };

            Response<short> dataRegistro = _acc_Idi_NivelCurso.fncACC_RegistrarNivelCurso(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarNivelCurso(model_Idi_NivelCurso entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_NivelCurso> informacion = _acc_Idi_NivelCurso.fncACC_NivelCursoIndividual(entidad.IdIdi_NivelCurso);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.Nombre = entidad.Nombre;

            Response<short> dataModificacion = _acc_Idi_NivelCurso.fncACC_ActualizarNivelCurso(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
