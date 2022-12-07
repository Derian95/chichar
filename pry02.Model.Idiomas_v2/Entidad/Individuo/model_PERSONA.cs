using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_PERSONA
    {
        public int CodigoPersona { get; set; }
        public byte? CodigoEstamento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public short? CodigoLugarNacimiento { get; set; }
        public string RUC { get; set; }
        public string LibretaMilitar { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Email { get; set; }
        public string GrupoSang { get; set; }
        public string IndicacionMedica { get; set; }
        public bool? Activo { get; set; }
        public string EstadoCivil { get; set; }
        public byte? TipoDocumento { get; set; }
        public string Observacion { get; set; }
        public int? LugarNacimiento { get; set; }

        public model_PERSONA(int codigoPersona = default
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , string nombre = _defaultString
            , string numeroDocumento = _defaultString
            , string direccion = _defaultString
            , string telefonoFijo = _defaultString
            , string telefonoCelular = _defaultString
            , string sexo = _defaultString
            , string usuario = _defaultString
            , DateTime fecha = default
            , string email = _defaultString)
        {
            CodigoPersona = codigoPersona;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombre = nombre;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            TelefonoFijo = telefonoFijo;
            TelefonoCelular = telefonoCelular;
            Sexo = sexo;
            Usuario = usuario;
            Fecha = _obtenerDefaultDateTime(fecha);
            Email = email;
            
            //Datos directos, sin constructor por null
            //CodEstamento = codEstamento;
            //FechaNac = fechaNac;
            //CodLugNac = codLugNac;
            //Activo = activo;
            //TipoDocum = tipoDocum;

            Foto = new byte[] { 0 };
            RUC = _defaultString;
            LibretaMilitar = _defaultString; 
            GrupoSang = _defaultString;
            IndicacionMedica = _defaultString;                
            Observacion = _defaultString;
            LugarNacimiento = 0;
            EstadoCivil = _defaultString;
        }
    }
}
