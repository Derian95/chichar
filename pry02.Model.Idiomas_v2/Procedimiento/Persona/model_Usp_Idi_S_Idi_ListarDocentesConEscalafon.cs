namespace pry02.Model.Idiomas_v2.Procedimiento
{
    public class model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id
    {
        public long Esc_IdEsc_TrabajadorDatosPersonales { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public short IdIdi_Docente { get; set; }
        public long Idi_IdEsc_TrabajadorDatosPersonales { get; set; }

    }

    public class model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento
    {
        public long TrabajadorDatosPersonalesId { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public short IdIdi_Docente { get; set; }

    }
}
