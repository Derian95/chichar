using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Ambiente
    {
        public short IdIdi_Ambiente { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte Tipo { get; set; }
        public byte Capacidad { get; set; }
        public byte _IdAula { get; set; }

        public model_Idi_Ambiente(short idIdi_Ambiente = default
            , string codigo = _defaultString
            , string descripcion = _defaultString
            , byte tipo = default
            , byte capacidad = default
            , byte idAula = default)
        {
            IdIdi_Ambiente = idIdi_Ambiente;
            Codigo = codigo;
            Descripcion = descripcion;
            Tipo = tipo;
            Capacidad = capacidad;
            _IdAula = idAula;
        }
    }
}
