using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;

using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_PlanEstudio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_PlanEstudio _acc_Idi_PlanEstudio = new access_Idi_PlanEstudio();
        private readonly access_viwIdi_Dependencia _acc_Pta_Dependencia = new access_viwIdi_Dependencia();
        private readonly access_General _accGeneral = new access_General();

        public Response<model_Idi_PlanEstudio> fncCON_ListaPlanEstudioIndividualCompleto(int idIdi_PlanEstudio)
        {
            Response<model_Idi_PlanEstudio> data_Idi_PlanEstudio = _acc_Idi_PlanEstudio.fncACC_ListaPlanEstudio_w_Cursos(idIdi_PlanEstudio);

            if (!data_Idi_PlanEstudio.Success) { return _respuesta.AddError<model_Idi_PlanEstudio>(data_Idi_PlanEstudio.MensajeError); }

            model_Idi_PlanEstudio informacion = data_Idi_PlanEstudio.Data;

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_dto_PlanEstudio>> fncCON_VisualListaPlanEstudio(int idDepe)
        {
            Response<List<model_Idi_PlanEstudio>> data_Idi_PlanEstudio = _acc_Idi_PlanEstudio.fncACC_ListaPlanEstudio(idDepe);
            Response<List<model_viwIdi_Dependencia>> data_Pta_Dependencia = _acc_Pta_Dependencia.fncACC_ListaIdioma(-1);

            if (!data_Idi_PlanEstudio.Success) { return _respuesta.AddError<List<model_dto_PlanEstudio>>(data_Idi_PlanEstudio.MensajeError); }

            List<model_dto_PlanEstudio> informacion = data_Idi_PlanEstudio.Data.Join(
                data_Pta_Dependencia.Data
                , ipe => ipe.IdDependencia
                , pd => pd.IdDependencia
                , (_ipe, _pd) => new model_dto_PlanEstudio
                {
                    IdIdi_PlanEstudio = _ipe.IdIdi_PlanEstudio,
                    IdDependencia = _ipe.IdDependencia,
                    Idioma = _pd.Descripcion,
                    IdPtaDependenciaFijo = _ipe.IdPtaDependenciaFijo,
                    Fecha = _ipe.Fecha,
                    Semestre = _ipe.Semestre,
                    Observacion = _ipe.Observacion,
                    Item = _ipe.Item,
                    IdIdi_PlanEstudioPadre = _ipe.IdIdi_PlanEstudioPadre,
                    Estado = _ipe.Estado,
                    Activo = _ipe.Activo,
                    EsActivo = _ipe.Activo? "SI": "NO",
                    UsuarioCreacion = _ipe.UsuarioCreacion,
                    FechaCreacion = _ipe.FechaCreacion,
                    _IdPe = _ipe._IdPe
                }
            ).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<bool> fncCON_ModificarPlandeEstudioCompleto(model_Idi_PlanEstudio entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();
            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }
                
            if (entidad.IdIdi_PlanEstudio == 0)
            {
                entidad.Estado = 1;
                entidad.UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario;
                entidad.FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor;
            }

            entidad.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            entidad.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            entidad.DireccionIP = _obtenerDireccionIPv4();
            entidad.DireccionMAC = _obtenerDireccionMAC();

            foreach (model_Idi_Curso curso in entidad.Idi_Curso)
            {
                if (curso.IdIdi_Curso == 0)
                {
                    curso.Estado = 1;
                    curso.Activo = true;
                    curso.UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario;
                    curso.FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor;
                }

                curso.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
                curso.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
                curso.DireccionIP = _obtenerDireccionIPv4();
                curso.DireccionMAC = _obtenerDireccionMAC();
            }

            Response<short> dataRegistro = _acc_Idi_PlanEstudio.fncACC_ActualizarPlandeEstudioCompleto(entidad);

            if (!dataRegistro.Success) { return _respuesta.AddError<bool>(dataRegistro.MensajeError); }
            return _respuesta.AddData(true);
        }

        //public Response<List<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma>> fncCON_RelacionPlanesEstudio(int idDepe)
        //{
        //    Response<List<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma>> dataDistrito = _acc_Idi_PlanEstudio.fncACC_RelacionPlanesEstudio(idDepe);

        //    if (!dataDistrito.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma>>(dataDistrito.MensajeError); }

        //    List<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma> informacion = dataDistrito.Data.ToList();

        //    return _respuesta.AddData(informacion);
        //}
    }
}
