using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Prerrequisito
    {
        public short IdIdi_Prerrequisito { get; set; }
        public short IdIdi_Curso { get; set; }
        public short IdIdi_CursoPrerrequisito { get; set; }
        public byte IdTipo { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _Idcurso { get; set; }
        public int _PreReq { get; set; }

        public model_Idi_Prerrequisito(short idIdi_Prerrequisito = default
            , short idIdi_Curso = default
            , short idIdi_CursoPrerrequisito = default
            , byte idTipo = default
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idcurso = default
            , int preReq = default)
        {
            IdIdi_Prerrequisito = idIdi_Prerrequisito;
            IdIdi_Curso = idIdi_Curso;
            IdIdi_CursoPrerrequisito = idIdi_CursoPrerrequisito;
            IdTipo = idTipo;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _Idcurso = idcurso;
            _PreReq = preReq;
        }
    }
}
