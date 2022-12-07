using pry100.Utilitario.Idiomas_v2.Clases;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public enum enmTipoAmbiente
    {
        Ninguno,

        [customDescripcion("Laboratorio")]
        Laboratorio,

        [customDescripcion("Salón de clases")]
        SalonClases
    }

    public class model_dto_Ambiente
    {
        public short IdIdi_Ambiente { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte Tipo { get; set; }
        public string NombreTipo { get; set; }
        public byte Capacidad { get; set; }
    }
}
