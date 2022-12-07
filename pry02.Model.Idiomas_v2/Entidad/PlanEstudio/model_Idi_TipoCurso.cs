using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_TipoCurso
    {
        public short IdIdi_TipoCurso { get; set; }
        public string Nombre { get; set; }
        public byte _IdTipoCurso { get; set; }

        public model_Idi_TipoCurso(short idIdi_TipoCurso = default
            , string nombre = _defaultString
            , byte idTipoCurso = default)
        {
            IdIdi_TipoCurso = idIdi_TipoCurso;
            Nombre = nombre;
            _IdTipoCurso = idTipoCurso;
        }
    }
}
