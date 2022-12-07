using System;

namespace pry02.Model.Idiomas_v2.Procedimiento
{
    public class model_Usp_Idi_S_ListarEstudianteParaIdiomas
    {
        public int CodPer { get; set; }
        public string Estamento { get; set; }
        public string DniPer { get; set; }
        public string NombreCompleto { get; set; }
        public int CodUniv { get; set; }
        public byte ItemEst { get; set; }
        public int iddepe { get; set; }
        public byte CodEstamento { get; set; }
        public DateTime FechIngreso { get; set; }
        public byte Activo { get; set; }
        public string Observ { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public byte ModIngreso { get; set; }
        public string Descripcion { get; set; }
        public int IdPtaDependenciaFijo { get; set; }
    }
}
