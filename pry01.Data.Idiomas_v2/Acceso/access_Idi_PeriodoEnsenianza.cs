using Microsoft.EntityFrameworkCore.Storage;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_Idi_PeriodoEnsenianza
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_Idi_PeriodoEnsenianza> _model_Idi_PeriodoEnsenianza = new rep_Matrix<model_Idi_PeriodoEnsenianza>();

        public virtual IDbContextTransaction _fncACC_BeginTransaction() { return _model_Idi_PeriodoEnsenianza._repositorio_getBT(); }

        public Response<List<model_Idi_PeriodoEnsenianza>> fncACC_ListaPeriodoEnsenianza(short idIdi_Docente)
        {
            try { return _respuesta.AddData(_model_Idi_PeriodoEnsenianza.ObtenerListado(where: c => c.IdIdi_Docente == idIdi_Docente).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_PeriodoEnsenianza>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<List<model_Idi_PeriodoEnsenianza>> fncACC_ListaPeriodoEnsenianza_w_CursoPeriodo(short idIdi_Docente, short idIdi_Semestre = -1)
        {
            try
            {
                return _respuesta.AddData(_model_Idi_PeriodoEnsenianza.ObtenerListado(
                    where: c => (
                        c.IdIdi_Docente == idIdi_Docente && (c.IdIdi_Semestre == idIdi_Semestre || idIdi_Semestre == -1)
                    )
                    , d => d.Idi_CursoPeriodo).ToList()
                );
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_Idi_PeriodoEnsenianza>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }

        public Response<model_Idi_PeriodoEnsenianza> fncACC_PeriodoEnsenianzaIndividual(int idIdi_PeriodoEnsenianza)
        {
            try { return _respuesta.AddData(_model_Idi_PeriodoEnsenianza.Obtener(c => c.IdIdi_PeriodoEnsenianza == idIdi_PeriodoEnsenianza)); }
            catch (Exception ex)
            {
                return _respuesta.AddError<model_Idi_PeriodoEnsenianza>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), "No se pudo obtener la información"),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerRegistro), ex.Message)
                });
            }
        }

        public Response<int> fncACC_ActualizarPeriodoEnsenianzaCompleto(model_Idi_PeriodoEnsenianza entidad)
        {
            try
            {
                _model_Idi_PeriodoEnsenianza.Modificar(entidad);
                _model_Idi_PeriodoEnsenianza.GuardarCambios();
                return _respuesta.AddData(entidad.IdIdi_PeriodoEnsenianza);
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<int>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), "No se pudo actualizar el registro."),
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBActualizarRegistro), ex.Message)
                });
            }
        }
    }
}