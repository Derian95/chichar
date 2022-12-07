using Microsoft.Data.SqlClient;

using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_TipoCurso_AI
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_TipoCurso_AI> _model_TipoCurso_AI = new rep_Matrix<model_TipoCurso_AI>();

        public Response<List<model_TipoCurso_AI>> ListarTipoCurso()
        {
            try
            {
                return _respuesta.AddData_noMensaje(_model_TipoCurso_AI.ObtenerListado().ToList());
            }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_TipoCurso_AI>>(new[] {
                    new _MensajeError((int)enm_G_CodigoError.DBObtenerListado, "No se pudo obtener la información")
                    , new _MensajeError((int)enm_G_CodigoError.DBObtenerListado, ex.Message)
                });
            }
        }

    }
}
