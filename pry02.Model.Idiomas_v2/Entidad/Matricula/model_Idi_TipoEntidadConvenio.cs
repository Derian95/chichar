using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_TipoEntidadConvenio
    {
        public short IdIdi_TipoEntidadConvenio { get; set; }
        public string Descripcion { get; set; }
        public string Abreviacion { get; set; }
        public int _IdTipoEntidad { get; set; }

        public model_Idi_TipoEntidadConvenio(short idIdi_TipoEntidadConvenio = default
            , string descripcion = _defaultString
            , string abreviacion = _defaultString
            , int idTipoEntidad = default)
        {
            IdIdi_TipoEntidadConvenio = idIdi_TipoEntidadConvenio;
            Descripcion = descripcion;
            Abreviacion = abreviacion;
            _IdTipoEntidad = idTipoEntidad;
        }
    }
}
