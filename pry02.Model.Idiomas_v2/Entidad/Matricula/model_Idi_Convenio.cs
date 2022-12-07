using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Convenio
    {
        public short IdIdi_Convenio { get; set; }
        public short IdIdi_EntidadConvenio { get; set; }
        public string Documento { get; set; }
        public decimal Pension { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _IdConvenio { get; set; }
        public int _IdEntidad { get; set; }

        public model_Idi_EntidadConvenio Idi_EntidadConvenio { get; set; }

        public model_Idi_Convenio(short idIdi_Convenio = default
            , short idIdi_EntidadConvenio = default
            , string documento = _defaultString
            , decimal pension = default
            , DateTime fechaInicio = default
            , DateTime fechaFin = default
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idConvenio = default
            , int idEntidad = default)
        {
            IdIdi_Convenio = idIdi_Convenio;
            IdIdi_EntidadConvenio = idIdi_EntidadConvenio;
            Documento = documento;
            Pension = pension;
            FechaInicio = _obtenerDefaultDateTime(fechaInicio);
            FechaFin = _obtenerDefaultDateTime(fechaFin);
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion); ;
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion); ;
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdConvenio = idConvenio;
            _IdEntidad = idEntidad;
        }
    }
}
