using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_ESTUDIANTE
    {
        public int CodigoUniversitario { get; set; }
        public byte ItemEstudiante { get; set; }
        public int CodigoPersona { get; set; }
        public int IdDependencia { get; set; }
        public byte CodigoEstamento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public byte Activo { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public byte? ModalidadIngreso { get; set; }

        public model_ESTUDIANTE(int codigoUniversitario = default
            , byte itemEstudiante = default
            , int codigoPersona = default
            , int idDependencia = default
            , byte codigoEstamento = default
            , DateTime fechaIngreso = default
            , byte activo = default
            , string observacion = _defaultString
            , string usuario = _defaultString
            , DateTime fecha = default)
        {
            CodigoUniversitario = codigoUniversitario;
            ItemEstudiante = itemEstudiante;
            CodigoPersona = codigoPersona;
            IdDependencia = idDependencia;
            CodigoEstamento = codigoEstamento;
            FechaIngreso = _obtenerDefaultDateTime(fechaIngreso);
            Activo = activo;
            Observacion = observacion;
            Usuario = usuario;
            Fecha = _obtenerDefaultDateTime(fecha);
            
            //Datos directos, sin constructor por null
            //ModIngreso = modIngreso;
        }
    }
}
