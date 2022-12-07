using System.Collections.Generic;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_EntidadConvenio
    {
        public short IdIdi_EntidadConvenio { get; set; }
        public short IdIdi_TipoEntidadConvenio { get; set; }
        public string Nombre { get; set; }
        public int _IdEntidad { get; set; }
        public int _IdTipoEntidad { get; set; }

        public ICollection<model_Idi_Convenio> Idi_Convenio { get; set; }

        public model_Idi_EntidadConvenio(short idIdi_EntidadConvenio = default
            , short idIdi_TipoEntidadConvenio = default
            , string nombre = _defaultString
            , int idEntidad = default
            , int idTipoEntidad = default)
        {
            IdIdi_EntidadConvenio = idIdi_EntidadConvenio;
            IdIdi_TipoEntidadConvenio = idIdi_TipoEntidadConvenio;
            Nombre = nombre;
            _IdEntidad = idEntidad;
            _IdTipoEntidad = idTipoEntidad;
        }
    }
}
