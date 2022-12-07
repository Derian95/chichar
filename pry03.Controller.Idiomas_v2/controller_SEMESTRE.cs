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
    public class controller_SEMESTRE
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_SEMESTRE _acc_SEMESTRE = new access_SEMESTRE();
        private readonly access_General _accGeneral = new access_General();

        public Response<int> fncCON_encontrarMaximoOrdenSEMESTRE()
        {
            Response<List<model_SEMESTRE>> data_SEMESTRE = _acc_SEMESTRE.fncACC_ListaSEMESTRE();

            if (!data_SEMESTRE.Success) { return _respuesta.AddError<int>(data_SEMESTRE.MensajeError); }

            int maximo = data_SEMESTRE.Data.Max(c => Convert.ToInt32(c.Orden) as int?) ?? 0 + 1;

            return _respuesta.AddData(maximo);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarSEMESTRE(model_SEMESTRE entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_SEMESTRE informacion = new model_SEMESTRE
            {
                IdSemestre = entidad.IdSemestre,
                Semestre = entidad.Semestre,
                InicioClases = entidad.InicioClases,
                Activo = true,
                Observacion = entidad.Observacion,
                Descripcion = entidad.Descripcion,
                Orden = entidad.Orden,
                Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString(),
                IdModalidadSemestre = entidad.IdModalidadSemestre,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor
            };

            Response<int> dataRegistro = _acc_SEMESTRE.fncACC_RegistrarSEMESTRE(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarSEMESTRE(model_SEMESTRE entidad)
        {
            Response<model_SEMESTRE> informacion = _acc_SEMESTRE.fncACC_SEMESTREIndividual(entidad.IdSemestre);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }
            
            informacion.Data.InicioClases = entidad.InicioClases;
            informacion.Data.Usuario = stuSistema.esquemaUsuario.IdSegUsuario.ToString();

            Response<int> dataModificacion = _acc_SEMESTRE.fncACC_ActualizarSEMESTRE(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }

        public Response<List<model_Usp_Idi_S_ObtenerModalidadSemestre>> fncCON_ObtenerModalidadSemestre(string mesRomano, int claseSemestre)
        {
            Response<List<model_Usp_Idi_S_ObtenerModalidadSemestre>> data_ModalidadSemestre = _acc_SEMESTRE.fncACC_ObtenerModalidadSemestre(mesRomano, claseSemestre);

            if (!data_ModalidadSemestre.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_ObtenerModalidadSemestre>>(data_ModalidadSemestre.MensajeError); }

            List<model_Usp_Idi_S_ObtenerModalidadSemestre> informacion = data_ModalidadSemestre.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_Usp_Idi_S_ObtenerMaximoIdSem>> fncCON_ObtenerMaximoIdSem(short anio, byte mes)
        {
            Response<List<model_Usp_Idi_S_ObtenerMaximoIdSem>> dataMaximoIdSem = _acc_SEMESTRE.fncACC_ObtenerMaximoIdSem(anio, mes);

            if (!dataMaximoIdSem.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_ObtenerMaximoIdSem>>(dataMaximoIdSem.MensajeError); }

            List<model_Usp_Idi_S_ObtenerMaximoIdSem> informacion = dataMaximoIdSem.Data.ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
