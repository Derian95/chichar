using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;

using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Pta_Dependencia
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_viwIdi_Dependencia _acc_Pta_Dependencia = new access_viwIdi_Dependencia();

        public Response<List<model_viwIdi_Dependencia>> fncCON_ListaIdioma(int idDepe = -1)
        {
            Response<List<model_viwIdi_Dependencia>> dataPersona = _acc_Pta_Dependencia.fncACC_ListaIdioma(idDepe);

            if (!dataPersona.Success) { return _respuesta.AddError<List<model_viwIdi_Dependencia>>(dataPersona.MensajeError); }

            List<model_viwIdi_Dependencia> informacion = dataPersona.Data.ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
