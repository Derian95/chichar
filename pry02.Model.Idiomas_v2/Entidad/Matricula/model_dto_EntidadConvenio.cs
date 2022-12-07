namespace pry02.Model.Idiomas_v2.Entidad
{
    //public enum enmTipoEntidadConvenio
    //{
    //    Ninguno,
    //    [customDescripcion("Instituto")]
    //    Instituto,

    //    [customDescripcion("Colegio")]
    //    Colegio,

    //    [customDescripcion("Universidad")]
    //    Universidad,

    //    [customDescripcion("Academia")]
    //    Academia,

    //    [customDescripcion("Sindicato")]
    //    Sindicato,

    //    [customDescripcion("Institución Pública")]
    //    InstitucionPublica
    //}

    public class model_dto_EntidadConvenio
    {
        public short IdIdi_EntidadConvenio { get; set; }
        public short IdIdi_TipoEntidadConvenio { get; set; }
        //public string TipoEntidadConvenio { get; set; }
        public string Nombre { get; set; }

        //public ICollection<model_dto_Convenio> Idi_Convenio { get; set; }
    }
}
