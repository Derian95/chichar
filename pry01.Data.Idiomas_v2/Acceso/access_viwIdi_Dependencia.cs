using pry01.Data.Idiomas_v2.Repositorio;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace pry01.Data.Idiomas_v2.Acceso
{
    public class access_viwIdi_Dependencia
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly rep_Matrix<model_viwIdi_Dependencia> _model_viwIdi_Dependencia = new rep_Matrix<model_viwIdi_Dependencia>();

        public Response<List<model_viwIdi_Dependencia>> fncACC_ListaIdioma(int idDependencia)
        {
            try { return _respuesta.AddData(_model_viwIdi_Dependencia.ObtenerListado(where: c => c.IdDependencia == idDependencia || idDependencia == -1).ToList()); }
            catch (Exception ex)
            {
                return _respuesta.AddError<List<model_viwIdi_Dependencia>>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), "No se pudo obtener la información")
                    , new _MensajeError(Convert.ToByte(enm_G_CodigoError.DBObtenerListado), ex.Message)
                });
            }
        }
    }
}
