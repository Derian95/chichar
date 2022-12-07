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
    public class controller_Idi_Semestre
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Semestre _acc_Idi_Semestre = new access_Idi_Semestre();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_Semestre>> fncCON_VisualListaSemestre(short anio = -1)
        {
            Response<List<model_Idi_Semestre>> data_Idi_Semestre = _acc_Idi_Semestre.fncACC_ListaSemestre(anio);

            if (!data_Idi_Semestre.Success) { return _respuesta.AddError<List<model_dto_Semestre>>(data_Idi_Semestre.MensajeError); }

            List<model_dto_Semestre> informacion = data_Idi_Semestre.Data.Select(c => new model_dto_Semestre
            {
                IdIdi_Semestre = c.IdIdi_Semestre,
                Anio = c.Anio,
                Mes = c.Mes,
                MesDescripcion = _getCustomPropertyEnum<customDescripcion>((enm_G_MesAnio)c.Mes).Descripcion,
                Semestre = c.Semestre,
                InicioClases = c.InicioClases,
                _IdSem = c._IdSem
            }).OrderByDescending(c => c.Anio).ThenByDescending(c => c.Mes).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<model_Idi_Semestre> fncCON_IndividualCurso(short idIdi_Semestre)
        {
            Response<model_Idi_Semestre> data_Idi_Curso = _acc_Idi_Semestre.fncACC_SemestreIndividual(idIdi_Semestre);

            if (!data_Idi_Curso.Success) { return _respuesta.AddError<model_Idi_Semestre>(data_Idi_Curso.MensajeError); }

            return _respuesta.AddData(data_Idi_Curso.Data);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarSemestre(model_Idi_Semestre entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();
            
            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Semestre informacion = new model_Idi_Semestre
            {
                Anio = entidad.Anio,
                Mes = entidad.Mes,
                Semestre = entidad.Semestre,
                InicioClases = entidad.InicioClases,
                Estado = 1,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC(),
                _IdSem = entidad._IdSem
            };

            Response<short> dataRegistro = _acc_Idi_Semestre.fncACC_RegistrarSemestre(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarSemestre(model_Idi_Semestre entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();
            
            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Semestre> informacion = _acc_Idi_Semestre.fncACC_SemestreIndividual(entidad.IdIdi_Semestre);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.Anio = entidad.Anio;
            informacion.Data.Mes = entidad.Mes;
            informacion.Data.Semestre = entidad.Semestre;
            informacion.Data.InicioClases = entidad.InicioClases;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();
            informacion.Data._IdSem = entidad._IdSem;

            Response<short> dataModificacion = _acc_Idi_Semestre.fncACC_ActualizarSemestre(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
