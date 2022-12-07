using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Semestre
    {
        public short IdIdi_Semestre { get; set; }
        public short Anio { get; set; }
        public byte Mes { get; set; }
        public string Semestre { get; set; }
        public DateTime InicioClases { get; set; }
        public byte Estado { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _IdSem { get; set; }

        public model_Idi_Semestre(short idIdi_Semestre = default
            , short anio = default
            , byte mes = default
            , string semestre = _defaultString
            , DateTime inicioClases = default
            , byte estado = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idSem = default)
        {
            IdIdi_Semestre = idIdi_Semestre;
            Anio = anio;
            Mes = mes;
            Semestre = semestre;
            InicioClases = _obtenerDefaultDateTime(inicioClases);
            Estado = estado;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdSem = idSem;
        }
    }
}
