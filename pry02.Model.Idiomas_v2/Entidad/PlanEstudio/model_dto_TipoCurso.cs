using pry100.Utilitario.Idiomas_v2.Clases;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public enum enmTipoCurso
    {
        Ninguno,

        [customDescripcion("Normal")]
        Normal,

        [customDescripcion("Propósito Específico")]
        PropositoEspecifico,

        [customDescripcion("Taller")]
        Taller
    }
    public class model_dto_TipoCurso
    {
        public short IdIdi_TipoCurso { get; set; }
        public string Nombre { get; set; }
    }
}
