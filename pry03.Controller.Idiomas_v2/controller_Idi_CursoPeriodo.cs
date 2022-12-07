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
    public class controller_Idi_CursoPeriodo
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_CursoPeriodo _acc_Idi_CursoPeriodo = new access_Idi_CursoPeriodo();
        private readonly access_Idi_Curso _acc_Idi_Curso = new access_Idi_Curso();
        private readonly access_viwIdi_Dependencia _acc_Pta_Dependencia = new access_viwIdi_Dependencia();

        public Response<model_Idi_CursoPeriodo> fncCON_IndividualCursoPeriodo(short idIdi_CursoPeriodo)
        {
            Response<model_Idi_CursoPeriodo> data_Idi_CursoPeriodo = _acc_Idi_CursoPeriodo.fncACC_CursoPeriodoIndividual(idIdi_CursoPeriodo);

            if (!data_Idi_CursoPeriodo.Success) { return _respuesta.AddError<model_Idi_CursoPeriodo>(data_Idi_CursoPeriodo.MensajeError); }

            return _respuesta.AddData(data_Idi_CursoPeriodo.Data);
        }

        public Response<List<model_dto_CursoPeriodo>> fncCON_VisualListaCursoPeriodo(int idIdi_PeriodoEnsenianza)
        {
            Response<List<model_Idi_CursoPeriodo>> data_Idi_CursoPeriodo = _acc_Idi_CursoPeriodo.fncACC_ListaCursoPeriodo(idIdi_PeriodoEnsenianza);
            Response<List<model_Idi_Curso>> data_Idi_Curso = _acc_Idi_Curso.fncACC_ListaCurso(-1);

            if (!data_Idi_CursoPeriodo.Success) { return _respuesta.AddError<List<model_dto_CursoPeriodo>>(data_Idi_CursoPeriodo.MensajeError); }

            List<model_dto_CursoPeriodo> informacion = data_Idi_CursoPeriodo.Data.Join(
                data_Idi_Curso.Data,
                icp => icp.IdIdi_Curso,
                ic => ic.IdIdi_Curso,
                (_icp, _ic) => new model_dto_CursoPeriodo
                {
                    IdIdi_CursoPeriodo = _icp.IdIdi_CursoPeriodo,
                    IdIdi_PeriodoEnsenianza = _icp.IdIdi_PeriodoEnsenianza,
                    IdIdi_Curso = _icp.IdIdi_Curso,
                    Curso = _ic.CodigoCurso + " " + _ic.Asignatura,
                    Seccion = _icp.Seccion,
                    Ciclo = _ic.Ciclo
                }
            ).ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
