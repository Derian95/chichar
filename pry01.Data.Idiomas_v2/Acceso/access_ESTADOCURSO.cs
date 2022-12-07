using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_ESTADOCURSO
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_ESTADOCURSO> _model_ESTADOCURSO = new rep_Matrix<model_ESTADOCURSO>();

        public Response<List<model_ESTADOCURSO>> fncACC_ListaESTADOCURSO(byte codigoEstado = 255)
        {
            try { return _respuesta.AddData(_model_ESTADOCURSO.ObtenerListado(where: c => c.CodigoEstado == codigoEstado || codigoEstado == 255).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_ESTADOCURSO>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
