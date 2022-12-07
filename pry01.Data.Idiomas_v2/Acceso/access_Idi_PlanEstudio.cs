using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_PlanEstudio
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_PlanEstudio> _model_Idi_PlanEstudio = new rep_Matrix<model_Idi_PlanEstudio>();

        public virtual IDbContextTransaction _fncACC_BeginTransaction() { return _model_Idi_PlanEstudio._repositorio_getBT(); }

        public Response<List<model_Idi_PlanEstudio>> fncACC_ListaPlanEstudio(int idDependencia)
        {
            try { return _respuesta.AddData(_model_Idi_PlanEstudio.ObtenerListado(where: c => c.IdDependencia == idDependencia).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_PlanEstudio>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_PlanEstudio> fncACC_ListaPlanEstudio_w_Cursos(int idIdi_PlanEstudio)
        {
            try { return _respuesta.AddData(_model_Idi_PlanEstudio.Obtener(where: c => c.IdIdi_PlanEstudio == idIdi_PlanEstudio, d => d.Idi_Curso)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_PlanEstudio>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_PlanEstudio> fncACC_PlanEstudioIndividual(short idIdi_PlanEstudio)
        {
            try { return _respuesta.AddData(_model_Idi_PlanEstudio.Obtener(c => c.IdIdi_PlanEstudio == idIdi_PlanEstudio)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_PlanEstudio>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarPlandeEstudioCompleto(model_Idi_PlanEstudio entidad)
        {
            try
            {
                _model_Idi_PlanEstudio.Modificar(entidad);
                _model_Idi_PlanEstudio.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_PlanEstudio);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        //public Response<List<model_dto_PlanEstudio>> fncACC_RelacionPlanesEstudio(int idDepe)
        //{
        //    List<SqlParameter> Parametros = new List<SqlParameter>() { new SqlParameter("@IdDepe", idDepe) };
        //    try
        //    {
        //        return _respuesta.AddData(
        //            _model_Idi_PlanEstudio.ExecuteStoredProcedureList<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma>("dbo.Usp_Idi_S_Idi_ListarPlanesPorIdioma", Parametros)
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarPlanesPorIdioma>>(new[] {
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
        //            , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
        //        });
        //    }
        //}
    }
}
