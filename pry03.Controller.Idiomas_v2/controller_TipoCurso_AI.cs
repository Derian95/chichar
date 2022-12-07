using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;

using System;
using System.Collections.Generic;
using System.Text;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_TipoCurso_AI
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_TipoCurso_AI _acceso = new access_TipoCurso_AI();
        public Response<List<model_TipoCurso_AI>> Listar_TipoCurso_AI()
        {
            var objetos = _acceso.ListarTipoCurso();
            if (!objetos.Success)
            {
                return _respuesta.AddError<List<model_TipoCurso_AI>>(objetos.MensajeError);
            }
            var resultado = objetos.Data;
            return _respuesta.AddData_noMensaje(resultado);
        }
    }
}
