using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;

using pry100.Utilitario.Idiomas_v2.Clases;

using System.Collections.Generic;
using System.Linq;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_ESTADOCURSO
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_ESTADOCURSO _acc_ESTADOCURSO = new access_ESTADOCURSO();

        public Response<List<model_ESTADOCURSO>> fncCON_VisualListaESTADOCURSO(byte CodEstado = 255)
        {
            Response<List<model_ESTADOCURSO>> data_ESTADOCURSO = _acc_ESTADOCURSO.fncACC_ListaESTADOCURSO(CodEstado);

            if (!data_ESTADOCURSO.Success) { return _respuesta.AddError<List<model_ESTADOCURSO>>(data_ESTADOCURSO.MensajeError); }

            List<model_ESTADOCURSO> informacion = data_ESTADOCURSO.Data.Select(c => new model_ESTADOCURSO
            {
                CodigoEstado = c.CodigoEstado,
                NombreEstado = c.NombreEstado
            }).OrderBy(c => c.NombreEstado).ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
