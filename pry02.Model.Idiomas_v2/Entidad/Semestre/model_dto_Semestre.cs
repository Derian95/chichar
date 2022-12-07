using System;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Semestre
    {
        public short IdIdi_Semestre { get; set; }
        public short Anio { get; set; }
        public byte Mes { get; set; }
        public string MesDescripcion { get; set; }
        public string Semestre { get; set; }
        public DateTime InicioClases { get; set; }
        public int _IdSem { get; set; }
    }
}
