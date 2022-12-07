namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Ad_LugarNacimiento
    {
        public int IdLugarNacimiento { get; set; }
        public int CodigoPersona { get; set; }
        public int CodigoNacionalidad { get; set; }
        public int CodigoDepartamento { get; set; }
        public int CodigoProvincia { get; set; }
        public int CodigoDistrito { get; set; }
        public int Estado { get; set; }

        public model_Ad_LugarNacimiento(int idLugarNacimiento = default
            , int codigoPersona = default
            , int codigoNacionalidad = default
            , int codigoDepartamento = default
            , int codigoProvincia = default
            , int codigoDistrito = default
            , int estado = default)
        {
            IdLugarNacimiento = idLugarNacimiento;
            CodigoPersona = codigoPersona;
            CodigoNacionalidad = codigoNacionalidad;
            CodigoDepartamento = codigoDepartamento;
            CodigoProvincia = codigoProvincia;
            CodigoDistrito = codigoDistrito;
            Estado = estado;
        }
    }
}
