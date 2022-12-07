using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Curso
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Curso> _model_Idi_Curso = new rep_Matrix<model_Idi_Curso>();

        public Response<List<model_Idi_Curso>> fncACC_ListaCurso(short idIdi_PlanEstudio = -1)
        {
            try { return _respuesta.AddData(_model_Idi_Curso.ObtenerListado(where: c => c.IdIdi_PlanEstudio == idIdi_PlanEstudio || idIdi_PlanEstudio == -1).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Curso>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Curso> fncACC_CursoIndividual(short idIdi_Curso)
        {
            try { return _respuesta.AddData(_model_Idi_Curso.Obtener(c => c.IdIdi_Curso == idIdi_Curso)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Curso>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarCurso(model_Idi_Curso entidad)
        {
            try
            {
                _model_Idi_Curso.Agregar(entidad);
                _model_Idi_Curso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Curso);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        //public Response<List<short>> fncACC_RegistrarGrupodeCursos(List<model_Idi_Curso> entidades)
        //{
        //    try
        //    {
        //        _model_Idi_Curso.AgregarVarios(entidades);
        //        _model_Idi_Curso.GuardarCambios();
        //        return _respuesta.AddData(entidades.Select(c => c.IdIdi_Curso).ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return _respuesta.AddError<List<short>>(new[] {
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
        //        });
        //    }
        //}

        public Response<short> fncACC_ActualizarCurso(model_Idi_Curso entidad)
        {
            try
            {
                _model_Idi_Curso.Modificar(entidad);
                _model_Idi_Curso.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Curso);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        //public Response<List<short>> fncACC_ActualizarGrupodeCursos(List<model_Idi_Curso> entidades)
        //{
        //    try
        //    {
        //        _model_Idi_Curso.ModificarVarios(entidades);
        //        _model_Idi_Curso.GuardarCambios();
        //        return _respuesta.AddData(entidades.Select(c => c.IdIdi_Curso).ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return _respuesta.AddError<List<short>>(new[] {
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
        //            new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
        //        });
        //    }
        //}
    }
}
