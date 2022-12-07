using System;

namespace pry02.Model.Idiomas_v2.Procedimiento
{
    public class model_Usp_Idi_S_ListarPersonaParaIdiomas
    {
        public int CodPer { get; set; }
        public byte CodEstamento { get; set; }
        public string Estamento { get; set; }
        public string ApepPer { get; set; }
        public string ApemPer { get; set; }
        public string NomPer { get; set; }
        public string DniPer { get; set; }
        public DateTime FechaNac { get; set; }
        public short CodLugNac { get; set; }
        public string RucPer { get; set; }
        public string LmPer { get; set; }
        public string Direccion { get; set; }
        public string TelefFijo { get; set; }
        public string TelefCelular { get; set; }
        public string Sexo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Email { get; set; }
        public string GrupoSang { get; set; }
        public string IndMedica { get; set; }
        public bool Activo { get; set; }
        public string EstadoCivil { get; set; }
        public byte TipoDocum { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string Perobs { get; set; }
        public int LugNac { get; set; }
    }
}
