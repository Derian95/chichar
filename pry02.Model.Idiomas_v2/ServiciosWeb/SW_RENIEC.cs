using System;

namespace pry02.Model.Idiomas_v2.ServiciosWeb
{
    public class SW_RENIECResult
    {
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoCasada { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Origen { get; set; }
    }

    public class SW_RENIECRequest
    {
        public int IdEscCredencialReniec { get; set; }
        public int IdSegSistema { get; set; }
        public int IdSegUsuario { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
