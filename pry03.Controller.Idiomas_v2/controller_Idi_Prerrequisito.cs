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
    public class controller_Idi_Prerrequisito
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Curso _acc_Idi_Curso = new access_Idi_Curso();
        private readonly access_Idi_PlanEstudio _acc_Idi_PlanEstudio = new access_Idi_PlanEstudio();
        private readonly access_Idi_Prerrequisito _acc_Idi_Prerrequisito = new access_Idi_Prerrequisito();
        private readonly access_General _accGeneral = new access_General();

        //public Response<List<model_Idi_Prerrequisito>> fncCON_ListaPrerrequisito()
        //{
        //    Response<List<model_Idi_Prerrequisito>> data_Idi_Prerrequisito = _acc_Idi_Prerrequisito.fncACC_ListaPrerrequisito();

        //    if (!data_Idi_Prerrequisito.Success) { return _respuesta.AddError<List<model_Idi_Prerrequisito>>(data_Idi_Prerrequisito.MensajeError); }

        //    List<model_Idi_Prerrequisito> informacion = data_Idi_Prerrequisito.Data.Select(c => new model_Idi_Prerrequisito
        //    {
        //        IdIdi_Prerrequisito = c.IdIdi_Prerrequisito,
        //        IdIdi_Curso = c.IdIdi_Curso,
        //        IdIdi_CursoPrerrequisito = c.IdIdi_CursoPrerrequisito,
        //        IdTipo = c.IdTipo,
        //        Estado = c.Estado,
        //        Activo = c.Activo,
        //        UsuarioCreacion = c.UsuarioCreacion,
        //        FechaCreacion = c.FechaCreacion,
        //        UsuarioModificacion = c.UsuarioModificacion,
        //        FechaModificacion = c.FechaModificacion,
        //        DireccionIP = c.DireccionIP,
        //        DireccionMAC = c.DireccionMAC,
        //        _Idcurso = c._Idcurso,
        //        _PreReq = c._PreReq
        //    }).ToList();

        //    return _respuesta.AddData(informacion);
        //}

        public Response<List<model_dto_Curso_Prerrequisito>> fncCON_VisualListaCurso_Y_Prerrequisito(int idDependencia, short idIdi_PlanEstudio)
        {
            Response<List<model_Idi_PlanEstudio>> data_Idi_PlanEstudio = _acc_Idi_PlanEstudio.fncACC_ListaPlanEstudio(idDependencia); 
            Response<List<model_Idi_Curso>> data_Id_Curso = _acc_Idi_Curso.fncACC_ListaCurso(idIdi_PlanEstudio);
            Response<List<model_Idi_Prerrequisito>> data_Idi_Prerrequisito = _acc_Idi_Prerrequisito.fncACC_ListaPrerrequisito();

            if (!data_Idi_Prerrequisito.Success) { return _respuesta.AddError<List<model_dto_Curso_Prerrequisito>>(data_Idi_Prerrequisito.MensajeError); }

            var informacion = data_Id_Curso.Data
            .Where(a => (a.Estado >= Convert.ToByte(1)) && (a.Activo = true))
            .Join(
                data_Idi_PlanEstudio.Data,
                ic1 => ic1.IdIdi_PlanEstudio,
                ipe => ipe.IdIdi_PlanEstudio,
                (_ic1, _ipe) => new { cur1 = _ic1, pla = _ipe }
            ).Where(a => (a.pla.Estado >= Convert.ToByte(1)))
            .GroupJoin(
                data_Idi_Prerrequisito.Data,
                ic1_ipe => ic1_ipe.cur1.IdIdi_Curso,
                ip => ip.IdIdi_Curso,
                (_ic1_ipe_pd, _ip) => new { cur_pla_dep = _ic1_ipe_pd, pre = _ip }
            ).SelectMany(
                def_pre => def_pre.pre.DefaultIfEmpty(),
                (_a_mix, _a_rigth) => new { aMix = _a_mix, aRight = _a_rigth }
            ).Where(c => (c.aRight == null) || (c.aRight.Estado >= Convert.ToByte(1)))
            .GroupJoin(
                data_Id_Curso.Data,
                b_mix => Convert.ToInt16(b_mix.aRight == null ? 0: b_mix.aRight.IdIdi_CursoPrerrequisito), //Si el match anterior es null, colocar un default
                ic2 => ic2.IdIdi_Curso,
                (_b_Mix, _ic2) => new { bMix = _b_Mix, cur2 = _ic2 }
            ).SelectMany(
                def_cur => def_cur.cur2.DefaultIfEmpty(),
                (_final_mix, _b_right) => new model_dto_Curso_Prerrequisito
                {
                    IdIdi_Curso = _final_mix.bMix.aMix.cur_pla_dep.cur1.IdIdi_Curso,
                    CodigoCurso = _final_mix.bMix.aMix.cur_pla_dep.cur1.CodigoCurso,
                    Asignatura = _final_mix.bMix.aMix.cur_pla_dep.cur1.Asignatura,
                    Ciclo = _final_mix.bMix.aMix.cur_pla_dep.cur1.Ciclo,
                    HorasTeoricas = _final_mix.bMix.aMix.cur_pla_dep.cur1.HorasTeoricas,
                    HorasPracticas = _final_mix.bMix.aMix.cur_pla_dep.cur1.HorasPracticas,
                    HorasLectivas = _final_mix.bMix.aMix.cur_pla_dep.cur1.HorasLectivas,
                    Creditos = _final_mix.bMix.aMix.cur_pla_dep.cur1.Creditos,
                    Electivo = _final_mix.bMix.aMix.cur_pla_dep.cur1.Electivo,
                    EsElectivo = _final_mix.bMix.aMix.cur_pla_dep.cur1.Electivo ? "SI" : "NO",
                    Orden = _final_mix.bMix.aMix.cur_pla_dep.cur1.Orden,
                    Ofertado = _final_mix.bMix.aMix.cur_pla_dep.cur1.Ofertado,
                    EsOfertado = _final_mix.bMix.aMix.cur_pla_dep.cur1.Ofertado ? "SI" : "NO",
                    IdIdi_Prerrequisito = Convert.ToInt16(_final_mix.bMix.aRight == null ? 0 : _final_mix.bMix.aRight.IdIdi_Prerrequisito),
                    IdIdi_CursoPrerrequisito = Convert.ToInt16(_final_mix.bMix.aRight == null ? 0 : _final_mix.bMix.aRight.IdIdi_CursoPrerrequisito),
                    Pre_CodigoCurso = _b_right == null ? "" : _b_right.CodigoCurso,
                    Pre_Asignatura = _b_right == null ? "" : _b_right.Asignatura,
                    Pre_Ciclo = Convert.ToByte(_b_right == null ? 0 : _b_right.Ciclo),
                    Pre_HorasTeoricas = Convert.ToByte(_b_right == null ? 0 : _b_right.HorasTeoricas),
                    Pre_HorasPracticas = Convert.ToByte(_b_right == null ? 0 : _b_right.HorasPracticas),
                    Pre_HorasLectivas = Convert.ToByte(_b_right == null ? 0 : _b_right.HorasLectivas),
                    Pre_Creditos = Convert.ToByte(_b_right == null ? 0 : _b_right.Creditos),
                    Pre_Electivo = _b_right == null ? "" : _b_right.Electivo ? "SI" : "NO",
                    Pre_Ofertado = _b_right == null ? "" : _b_right.Ofertado ? "SI" : "NO",
                }
            ).OrderBy(a => a.Ciclo)
            .ThenBy(a => a.Orden)
            .ToList();

            //var informacion2 = data_Idi_Prerrequisito.Data.Select(c => new model_dto_Curso_Prerrequisito
            //{
            //    IdIdi_Prerrequisito = c.IdIdi_Prerrequisito,
            //    IdIdi_Curso = c.IdIdi_Curso,
            //    IdIdi_CursoPrerrequisito = c.IdIdi_CursoPrerrequisito,
            //}).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarPrerrequisito(model_Idi_Prerrequisito entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Prerrequisito informacion = new model_Idi_Prerrequisito
            {
                IdIdi_Prerrequisito = entidad.IdIdi_Prerrequisito,
                IdIdi_Curso = entidad.IdIdi_Curso,
                IdIdi_CursoPrerrequisito = entidad.IdIdi_CursoPrerrequisito,
                IdTipo = 1,
                Estado = 1,
                Activo = true,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC()
            };

            Response<short> dataRegistro = _acc_Idi_Prerrequisito.fncACC_RegistrarPrerrequisito(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarPrerrequisito(model_Idi_Prerrequisito entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Prerrequisito> informacion = _acc_Idi_Prerrequisito.fncACC_PrerrequisitoIndividual(entidad.IdIdi_Prerrequisito);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }
            
            informacion.Data.IdIdi_Curso = entidad.IdIdi_Curso;
            informacion.Data.IdIdi_CursoPrerrequisito = entidad.IdIdi_CursoPrerrequisito;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();
            
            Response<short> dataModificacion = _acc_Idi_Prerrequisito.fncACC_ActualizarPrerrequisito(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }


        //public Response<List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>> fncCON_RelacionCursosYPrerrequisitos(int idDepe, short idIdi_PlanEstudio)
        //{
        //    Response<List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>> dataCurso = _acc_Idi_Prerrequisito.fncACC_RelacionCursosYPrerrequisitos(idDepe, idIdi_PlanEstudio);

        //    if (!dataCurso.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos>>(dataCurso.MensajeError); }

        //    List<model_Usp_Idi_S_Idi_ListarCursosYPrerrequisitos> informacion = dataCurso.Data.ToList();

        //    return _respuesta.AddData(informacion);
        //}
    }
}
