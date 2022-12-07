using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Docente
    {
        public short IdIdi_Docente { get; set; }
        public long IdEsc_TrabajadorDatosPersonales { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _IdDocente { get; set; }

        public model_Idi_Docente(short idIdi_Docente = default
            , long idEsc_TrabajadorDatosPersonales = default
            , string numeroDocumento = _defaultString
            , string apellidoMaterno = _defaultString
            , string apellidoPaterno = _defaultString
            , string nombres = _defaultString
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idDocente = default)
        {
            IdIdi_Docente = idIdi_Docente;
            IdEsc_TrabajadorDatosPersonales = idEsc_TrabajadorDatosPersonales;
            NumeroDocumento = numeroDocumento;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdDocente = idDocente;
        }
    }
}
