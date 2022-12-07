namespace pry02.Model.Idiomas_v2.ServiciosWeb
{
    public class SW_LoginResult
    {
        public long IdentificadorUsuario { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public _InformacionGenerica InformacionGenerica { get; set; }
        public _InformacionEspecifica InformacionEspecifica { get; set; }
    }

    public class _InformacionGenerica
    {
        public string IdSegUsuario { get; set; }
        public string IdTipoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string EsAdministrador { get; set; }
        public string EmailValidado { get; set; }
        public string Email { get; set; }
        public string IdTdvUsuario { get; set; }
    }

    public class _InformacionEspecifica
    {
        public int EsElector { get; set; }
        public int EsParticipante { get; set; }
        public int EsPersonero { get; set; }
        public int EsMiembroComite { get; set; }
        public string CorreoInstitucional { get; set; }
    }

    public class SW_LoginRequest
    {
        public short IdSistema { get; set;}
        public short IdTipoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
