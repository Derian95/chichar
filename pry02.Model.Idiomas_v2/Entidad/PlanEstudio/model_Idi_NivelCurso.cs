using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_NivelCurso
    {
        public short IdIdi_NivelCurso { get; set; }
        public string Nombre { get; set; }

        public model_Idi_NivelCurso(short idIdi_NivelCurso = default
            , string nombre = _defaultString)
        {
            IdIdi_NivelCurso = idIdi_NivelCurso;
            Nombre = nombre;
        }
    }
}
