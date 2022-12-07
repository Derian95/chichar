using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_TurnoBase
    {
        public short IdIdi_TurnoBase { get; set; }
        public string Descripcion { get; set; }

        public model_Idi_TurnoBase(short idIdi_TurnoBase = default
            , string descripcion = _defaultString)
        {
            IdIdi_TurnoBase = idIdi_TurnoBase;
            Descripcion = descripcion;
        }
    }
}
