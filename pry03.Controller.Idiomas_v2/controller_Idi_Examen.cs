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
    public class controller_Idi_Examen
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Examen _acc_Idi_Examen = new access_Idi_Examen();
        private readonly access_ESTADOCURSO _acc_ESTADOCURSO = new access_ESTADOCURSO();
        private readonly access_Idi_Semestre _acc_Idi_Semestre = new access_Idi_Semestre();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_Examen>> fncCON_VisualListaExamen()
        {
            Response<List<model_Idi_Examen>> data_Idi_Examen = _acc_Idi_Examen.fncACC_ListaExamen();
            Response<List<model_ESTADOCURSO>> data_ESTADOCURSO = _acc_ESTADOCURSO.fncACC_ListaESTADOCURSO();
            Response<List<model_Idi_Semestre>> data_Idi_Semestre = _acc_Idi_Semestre.fncACC_ListaSemestre(-1);

            if (!data_Idi_Examen.Success) { return _respuesta.AddError<List<model_dto_Examen>>(data_Idi_Examen.MensajeError); }
            if (!data_ESTADOCURSO.Success) { return _respuesta.AddError<List<model_dto_Examen>>(data_ESTADOCURSO.MensajeError); }
            if (!data_Idi_Semestre.Success) { return _respuesta.AddError<List<model_dto_Examen>>(data_Idi_Semestre.MensajeError); }

            List<model_dto_Examen> informacion = data_Idi_Examen.Data.Join(
                data_ESTADOCURSO.Data,
                iex => iex.CodigoEstadoCurso,
                ies => ies.CodigoEstado,
                (_ex, _es) => new { exa = _ex, est = _es }
            ).ToList().GroupJoin(
                data_Idi_Semestre.Data,
                ex_es => ex_es.exa.IdIdi_Semestre,
                ise => ise.IdIdi_Semestre,
                (_ex_es, _sem) => new { exa_est = _ex_es, sem = _sem }
            ).SelectMany(
                mix => mix.sem.DefaultIfEmpty(),
                (_mix, _right) => new model_dto_Examen
                {
                    IdIdi_Examen = _mix.exa_est.exa.IdIdi_Examen,
                    IdIdi_Docente = _mix.exa_est.exa.IdIdi_Docente,
                    IdIdi_Curso = _mix.exa_est.exa.IdIdi_Curso,
                    IdIdi_Semestre = _mix.exa_est.exa.IdIdi_Semestre,
                    AnioSemestre = Convert.ToInt16(_right == null ? 0 : _right.Anio),
                    MesSemestre = Convert.ToByte(_right == null ? 0 : _right.Mes),
                    Semestre = (_right == null ? "" : _right.Semestre).ToString(),
                    IdIdi_TipoCalificacion = _mix.exa_est.exa.IdIdi_TipoCalificacion,
                    TipoCalificacion = _getCustomPropertyEnum<customDescripcion>((enmTipoCalificacion)_mix.exa_est.exa.IdIdi_TipoCalificacion).Descripcion,
                    CodigoEstadoCurso = _mix.exa_est.exa.CodigoEstadoCurso,
                    EstadoCurso = _mix.exa_est.est.NombreEstado,
                    TipoExamen = _mix.exa_est.exa.TipoExamen,
                    TipoExamenDescripcion = _getCustomPropertyEnum<customDescripcion>((enmTipoExamen)_mix.exa_est.exa.TipoExamen).Descripcion,
                    CodigoUniversitario = _mix.exa_est.exa.CodigoUniversitario,
                    Tema = _mix.exa_est.exa.Tema,
                    Fecha = _mix.exa_est.exa.Fecha,
                    Nota = _mix.exa_est.exa.Nota,
                    Estado = _mix.exa_est.exa.Estado,
                    Activo = _mix.exa_est.exa.Activo
                }
            ).OrderByDescending(i => i.IdIdi_Semestre)
            .ThenByDescending(j => j.AnioSemestre)
            .ThenByDescending(k => k.MesSemestre)
            .ToList();            

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarExamen(model_Idi_Examen entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Examen informacion = new model_Idi_Examen
            {
                IdIdi_Examen = entidad.IdIdi_Examen,
                IdIdi_Docente = entidad.IdIdi_Docente,
                IdIdi_Curso = entidad.IdIdi_Curso,
                IdIdi_Semestre = entidad.IdIdi_Semestre,
                IdIdi_TipoCalificacion = Convert.ToByte(1), //Esta es la escala -> de 0-100, luego modificar
                CodigoEstadoCurso = entidad.CodigoEstadoCurso,
                TipoExamen = entidad.TipoExamen,
                CodigoUniversitario = entidad.CodigoUniversitario,
                Tema = entidad.Tema,
                Fecha = entidad.Fecha,
                Nota = entidad.Nota,
                Estado = 1,
                Activo = true,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC()
            };

            Response<short> dataRegistro = _acc_Idi_Examen.fncACC_RegistrarExamen(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarExamen(model_Idi_Examen entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Examen> informacion = _acc_Idi_Examen.fncACC_ExamenIndividual(entidad.IdIdi_Examen);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdIdi_Docente = entidad.IdIdi_Docente;
            informacion.Data.IdIdi_Curso = entidad.IdIdi_Curso;
            informacion.Data.IdIdi_Semestre = entidad.IdIdi_Semestre;
            informacion.Data.IdIdi_TipoCalificacion = entidad.IdIdi_TipoCalificacion;
            informacion.Data.CodigoEstadoCurso = entidad.CodigoEstadoCurso;
            informacion.Data.TipoExamen = entidad.TipoExamen;
            informacion.Data.CodigoUniversitario = entidad.CodigoUniversitario;
            informacion.Data.Tema = entidad.Tema;
            informacion.Data.Fecha = entidad.Fecha;
            informacion.Data.Nota = entidad.Nota;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();

            Response<short> dataModificacion = _acc_Idi_Examen.fncACC_ActualizarExamen(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
