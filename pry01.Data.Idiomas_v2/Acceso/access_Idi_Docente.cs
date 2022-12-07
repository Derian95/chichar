using Microsoft.Data.SqlClient;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_Docente
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_Docente> _model_Idi_Docente = new rep_Matrix<model_Idi_Docente>();

        public Response<List<model_Idi_Docente>> fncACC_ListaDocente(short idIdi_Docente = -1)
        {
            try
            {
                return _respuesta.AddData(_model_Idi_Docente.ObtenerListado(
                    where: c => c.IdIdi_Docente == idIdi_Docente || idIdi_Docente == -1
                ).ToList());
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_Docente>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_Docente> fncACC_DocenteIndividual(short idIdi_Docente)
        {
            try { return _respuesta.AddData(_model_Idi_Docente.Obtener(c => c.IdIdi_Docente == idIdi_Docente)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_Docente>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_RegistrarDocente(model_Idi_Docente entidad)
        {
            try
            {
                _model_Idi_Docente.Agregar(entidad);
                _model_Idi_Docente.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Docente);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), "No se pudo agregar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBInsertarRegistro), ex.Message)
                });
            }
        }

        public Response<short> fncACC_ActualizarDocente(model_Idi_Docente entidad)
        {
            try
            {
                _model_Idi_Docente.Modificar(entidad);
                _model_Idi_Docente.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_Docente);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<short>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>> fncACC_RelacionDocentesEnEscalafon()
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            try
            {
                return _respuesta.AddData(
                    _model_Idi_Docente.ExecuteStoredProcedureList<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>("dbo.Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>> fncACC_RelacionDocentesEnEscalafon_NoSincronizado()
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            try
            {
                return _respuesta.AddData(
                    _model_Idi_Docente.ExecuteStoredProcedureList<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>("dbo.Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento", Parametros)
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
