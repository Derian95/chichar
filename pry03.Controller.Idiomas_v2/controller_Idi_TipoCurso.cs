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
    public class controller_Idi_TipoCurso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_TipoCurso _acc_Idi_TipoCurso = new access_Idi_TipoCurso();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_TipoCurso>> fncCON_ListaTipoCurso()
        {
            Response<List<model_Idi_TipoCurso>> data_Idi_TipoCurso = _acc_Idi_TipoCurso.fncACC_ListaTipoCurso();

            if (!data_Idi_TipoCurso.Success) { return _respuesta.AddError<List<model_dto_TipoCurso>>(data_Idi_TipoCurso.MensajeError); }

            List<model_dto_TipoCurso> informacion = data_Idi_TipoCurso.Data.Select(c => new model_dto_TipoCurso
            {
                IdIdi_TipoCurso = c.IdIdi_TipoCurso,
                Nombre = c.Nombre,
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarTipoCurso(model_Idi_TipoCurso entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_TipoCurso informacion = new model_Idi_TipoCurso
            {
                IdIdi_TipoCurso = entidad.IdIdi_TipoCurso,
                Nombre = entidad.Nombre
            };

            Response<short> dataRegistro = _acc_Idi_TipoCurso.fncACC_RegistrarTipoCurso(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarTipoCurso(model_Idi_TipoCurso entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_TipoCurso> informacion = _acc_Idi_TipoCurso.fncACC_TipoCursoIndividual(entidad.IdIdi_TipoCurso);
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

            Response<short> dataModificacion = _acc_Idi_TipoCurso.fncACC_ActualizarTipoCurso(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
