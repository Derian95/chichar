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
    public class controller_Idi_Horario
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Horario _acc_Idi_Horario = new access_Idi_Horario();
        private readonly access_viwIdi_Dependencia _acc_Pta_Dependencia = new access_viwIdi_Dependencia();
        private readonly access_Idi_Semestre _acc_Idi_Semestre = new access_Idi_Semestre();
        private readonly access_Idi_Curso _acc_Idi_Curso = new access_Idi_Curso();

        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_Horario>> fncCON_VisualListaHorario(int idi_Curso)
        {
            Response<List<model_Idi_Horario>> data_Idi_Horario = _acc_Idi_Horario.fncACC_ListaHorario(idi_Curso);
            Response<List<model_Idi_Curso>> data_Idi_Curso = _acc_Idi_Curso.fncACC_ListaCurso();
            Response<List<model_Idi_Semestre>> data_Idi_Semestre = _acc_Idi_Semestre.fncACC_ListaSemestre(-1);

            if (!data_Idi_Horario.Success) { return _respuesta.AddError<List<model_dto_Horario>>(data_Idi_Horario.MensajeError); }
            if (!data_Idi_Curso.Success) { return _respuesta.AddError<List<model_dto_Horario>>(data_Idi_Curso.MensajeError); }
            if (!data_Idi_Semestre.Success) { return _respuesta.AddError<List<model_dto_Horario>>(data_Idi_Semestre.MensajeError); }

            List<model_dto_Horario> informacion = data_Idi_Horario.Data.Join(
                data_Idi_Curso.Data,
                ih => ih.IdIdi_Curso,
                ic => ic.IdIdi_Curso,
                (_ih, _ic) => new { ho = _ih, cu = _ic }
            ).ToList().Join(
                data_Idi_Semestre.Data,
                ih_ic => ih_ic.ho.IdIdi_Semestre,
                ise => ise.IdIdi_Semestre,
                (_mix, _right) => new model_dto_Horario
                {
                    IdIdi_Horario = _mix.ho.IdIdi_Horario,
                    NumeroDia = _mix.ho.NumeroDia,
                    NombreDia = _getCustomPropertyEnum<customDescripcion>((enm_G_MesAnio)_mix.ho.NumeroDia).Descripcion,
                    IdIdi_Semestre = _mix.ho.IdIdi_Semestre,
                    Semestre = _right.Semestre,
                    IdIdi_Curso = _mix.cu.IdIdi_Curso,
                    Curso = _mix.cu.CodigoCurso + "-" + _mix.cu.Asignatura,
                    Seccion = _mix.ho.Seccion,
                    HoraEntrada = _mix.ho.HoraEntrada,
                    HoraSalida = _mix.ho.HoraSalida,
                    Estado = _mix.ho.Estado,
                    Activo = _mix.ho.Activo
                }
            ).OrderBy(c => c.Curso)
            .ThenBy(d => d.NumeroDia)
            .ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarHorario(model_Idi_Horario entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Horario informacion = new model_Idi_Horario
            {
                IdIdi_Horario = entidad.IdIdi_Horario,
                NumeroDia = entidad.NumeroDia,
                IdIdi_Semestre = entidad.IdIdi_Semestre,
                IdIdi_Curso = entidad.IdIdi_Curso,
                Seccion = entidad.Seccion,
                HoraEntrada = entidad.HoraEntrada,
                HoraSalida = entidad.HoraSalida,
                Estado = 1,
                Activo = true,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC()
            };

            Response<int> dataRegistro = _acc_Idi_Horario.fncACC_RegistrarHorario(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarHorario(model_Idi_Horario entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Horario> informacion = _acc_Idi_Horario.fncACC_HorarioIndividual(entidad.IdIdi_Horario);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdIdi_Horario = entidad.IdIdi_Horario;
            informacion.Data.NumeroDia = entidad.NumeroDia;
            informacion.Data.IdIdi_Semestre = entidad.IdIdi_Semestre;
            informacion.Data.IdIdi_Curso = entidad.IdIdi_Curso;
            informacion.Data.Seccion = entidad.Seccion;
            informacion.Data.HoraEntrada = entidad.HoraEntrada;
            informacion.Data.HoraSalida = entidad.HoraSalida;
            informacion.Data.Estado = entidad.Estado;
            informacion.Data.Activo = entidad.Activo;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();

            Response<int> dataModificacion = _acc_Idi_Horario.fncACC_ActualizarHorario(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }
    }
}
