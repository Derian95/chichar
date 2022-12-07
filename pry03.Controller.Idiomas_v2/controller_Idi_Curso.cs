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
    public class controller_Idi_Curso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Curso _acc_Idi_Curso = new access_Idi_Curso();

        public Response<model_Idi_Curso> fncCON_IndividualCurso(short idIdi_Curso)
        {
            Response<model_Idi_Curso> data_Idi_Curso = _acc_Idi_Curso.fncACC_CursoIndividual(idIdi_Curso);

            if (!data_Idi_Curso.Success) { return _respuesta.AddError<model_Idi_Curso>(data_Idi_Curso.MensajeError); }

            return _respuesta.AddData(data_Idi_Curso.Data);
        }

        public Response<List<model_dto_Curso>> fncCON_VisualListaCurso(short idIdi_PlanEstudio = -1)
        {
            Response<List<model_Idi_Curso>> data_Id_Curso = _acc_Idi_Curso.fncACC_ListaCurso(idIdi_PlanEstudio);

            if (!data_Id_Curso.Success) { return _respuesta.AddError<List<model_dto_Curso>>(data_Id_Curso.MensajeError); }

            List<model_dto_Curso> informacion = data_Id_Curso.Data.Select(c => new model_dto_Curso
            {
                IdIdi_Curso = c.IdIdi_Curso,
                IdIdi_PlanEstudio = c.IdIdi_PlanEstudio,
                IdIdi_NivelCurso = c.IdIdi_NivelCurso,
                IdIdi_TipoCurso = c.IdIdi_TipoCurso,
                CodigoCurso = c.CodigoCurso,
                Asignatura = c.Asignatura,
                Ciclo = c.Ciclo,
                HorasTeoricas = c.HorasTeoricas,
                HorasPracticas = c.HorasPracticas,
                HorasLectivas = c.HorasLectivas,
                Creditos = c.Creditos,
                Electivo = c.Electivo,
                EsElectivo = c.Electivo? "SI": "NO",
                Orden = c.Orden,
                Ofertado = c.Ofertado,
                EsOfertado = c.Ofertado? "SI": "NO",
                Estado = c.Estado,
                Activo = c.Activo,
                UsuarioCreacion = c.UsuarioCreacion,
                FechaCreacion = c.FechaCreacion,
                _Idcurso = c._Idcurso,
                _PreReq = c._PreReq,
                _IdNivel = c._IdNivel,
                _IdTipoCurso = c._IdTipoCurso,
                _auxiliarEmpadronamiento = 0,
            }).ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
