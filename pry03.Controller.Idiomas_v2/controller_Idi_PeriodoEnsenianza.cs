using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using System.Runtime.Intrinsics.X86;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_PeriodoEnsenianza
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_PeriodoEnsenianza _acc_Idi_PeriodoEnsenianza = new access_Idi_PeriodoEnsenianza();
        private readonly access_Idi_Docente _acc_Idi_Docente = new access_Idi_Docente();
        private readonly access_Idi_Semestre _acc_Idi_Semestre = new access_Idi_Semestre();
        
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_PeriodoEnsenianza>> fncCON_VisualPeriodoEnsenianza(short idIdi_Docente)
        {
            Response<List<model_Idi_PeriodoEnsenianza>> data_Idi_PeriodoEnsenianza = _acc_Idi_PeriodoEnsenianza.fncACC_ListaPeriodoEnsenianza(idIdi_Docente);
            Response<List<model_Idi_Semestre>> data_Idi_Semestre = _acc_Idi_Semestre.fncACC_ListaSemestre(-1);
            
            if (!data_Idi_PeriodoEnsenianza.Success) { return _respuesta.AddError<List<model_dto_PeriodoEnsenianza>>(data_Idi_PeriodoEnsenianza.MensajeError); }
            if (!data_Idi_Semestre.Success) { return _respuesta.AddError<List<model_dto_PeriodoEnsenianza>>(data_Idi_Semestre.MensajeError); }
            
            List<model_dto_PeriodoEnsenianza> informacion = data_Idi_PeriodoEnsenianza.Data.Join(
                data_Idi_Semestre.Data,
                ipe => ipe.IdIdi_Semestre,
                ise => ise.IdIdi_Semestre,
                (_ipe, _ise) => new model_dto_PeriodoEnsenianza
                {
                    IdIdi_PeriodoEnsenianza = _ipe.IdIdi_PeriodoEnsenianza,
                    IdIdi_Semestre = _ipe.IdIdi_Semestre,
                    Semestre = _ise.Semestre,
                    FechaInicio = _ipe.FechaInicio,
                    FechaFin = _ipe.FechaFin,
                    Estado = _ipe.Estado,
                    Activo = _ipe.Activo,
                    UsuarioCreacion = _ipe.UsuarioCreacion,
                    FechaCreacion = _ipe.FechaCreacion,
                    _IdSem = _ipe._IdSem,
                    _IdTurno = _ipe._IdTurno,
                    _Codigo = _ipe._Codigo,
                }
            ).OrderByDescending(c => c.FechaInicio)
            .ThenByDescending(c => c.FechaFin)
            .ToList();

            return _respuesta.AddData(informacion);
        }
        //public Response<List<model_Idi_PeriodoEnsenianza>> fncCON_ListaPeriodoEnsenianza(short idIdi_Docente)
        //{
        //    Response<List<model_Idi_PeriodoEnsenianza>> data_Idi_PeriodoEnsenianza = _acc_Idi_PeriodoEnsenianza.fncACC_ListaPeriodoEnsenianza(idIdi_Docente);

        //    if (!data_Idi_PeriodoEnsenianza.Success) { return _respuesta.AddError<List<model_Idi_PeriodoEnsenianza>>(data_Idi_PeriodoEnsenianza.MensajeError); }

        //    List<model_Idi_PeriodoEnsenianza> informacion = data_Idi_PeriodoEnsenianza.Data.Select(c => new model_Idi_PeriodoEnsenianza
        //    {
        //        IdIdi_PeriodoEnsenianza = c.IdIdi_PeriodoEnsenianza,
        //        IdIdi_Docente = c.IdIdi_Docente,
        //        IdIdi_Semestre = c.IdIdi_Semestre,
        //        FechaInicio = c.FechaInicio,
        //        FechaFin = c.FechaFin,
        //        Estado = c.Estado,
        //        Activo = c.Activo,
        //        UsuarioCreacion = c.UsuarioCreacion,
        //        FechaCreacion = c.FechaCreacion,
        //        _IdSem = c._IdSem,
        //        _IdTurno = c._IdTurno,
        //        _Codigo = c._Codigo,
        //    }
        //    ).OrderByDescending(c => c.FechaInicio)
        //    .ThenByDescending(c => c.FechaFin)
        //    .ToList();

        //    return _respuesta.AddData(informacion);
        //}

        public Response<List<model_Idi_PeriodoEnsenianza>> fncCON_ListaPeriodoEnsenianzaIndividualCompleto(short idIdi_Docente, short idIdi_Semestre = -1)
        {
            Response<List<model_Idi_PeriodoEnsenianza>> data_Idi_PlanEstudio = _acc_Idi_PeriodoEnsenianza.fncACC_ListaPeriodoEnsenianza_w_CursoPeriodo(idIdi_Docente, idIdi_Semestre);

            if (!data_Idi_PlanEstudio.Success) { return _respuesta.AddError<List<model_Idi_PeriodoEnsenianza>>(data_Idi_PlanEstudio.MensajeError); }

            List<model_Idi_PeriodoEnsenianza> informacion = data_Idi_PlanEstudio.Data;

            return _respuesta.AddData(informacion);
        }

        public Response<bool> fncCON_ModificarPeriodoEnsenianzaCompleto(model_Idi_PeriodoEnsenianza entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();
            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            if (entidad.IdIdi_PeriodoEnsenianza == 0)
            {
                entidad.Estado = 1;
                entidad.Activo = true;
                entidad.UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario;
                entidad.FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor;
            }

            entidad.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            entidad.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            entidad.DireccionIP = _obtenerDireccionIPv4();
            entidad.DireccionMAC = _obtenerDireccionMAC();

            foreach (model_Idi_CursoPeriodo cursoPeriodo in entidad.Idi_CursoPeriodo)
            {
                if (cursoPeriodo.IdIdi_CursoPeriodo == 0)
                {
                    cursoPeriodo.Estado = 1;
                    cursoPeriodo.Activo = true;
                    cursoPeriodo.UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario;
                    cursoPeriodo.FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor;
                }

                cursoPeriodo.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
                cursoPeriodo.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
                cursoPeriodo.DireccionIP = _obtenerDireccionIPv4();
                cursoPeriodo.DireccionMAC = _obtenerDireccionMAC();
            }

            Response<int> dataRegistro = _acc_Idi_PeriodoEnsenianza.fncACC_ActualizarPeriodoEnsenianzaCompleto(entidad);

            if (!dataRegistro.Success) { return _respuesta.AddError<bool>(dataRegistro.MensajeError); }
            return _respuesta.AddData(true);
        }
    }
}
