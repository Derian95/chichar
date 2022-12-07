using System;
using System.Collections.Generic;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_PlanEstudio
    {
        public short IdIdi_PlanEstudio { get; set; }
        public int IdDependencia { get; set; }
        public int IdPtaDependenciaFijo { get; set; }
        public DateTime Fecha { get; set; }
        public string Semestre { get; set; }
        public string Observacion { get; set; }
        public byte Item { get; set; }
        public short IdIdi_PlanEstudioPadre { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public short _IdPe { get; set; }

        public List<model_Idi_Curso> Idi_Curso { get; set; }

        public model_Idi_PlanEstudio(short idIdi_PlanEstudio = default
            , int idDependencia = default
            , int idPtaDependenciaFijo = default
            , DateTime fecha = default
            , string semestre = _defaultString
            , string observacion = _defaultString
            , byte item = default
            , short idIdi_PlanEstudioPadre = default
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , short idPe = default)
        {
            IdIdi_PlanEstudio = idIdi_PlanEstudio;
            IdDependencia = idDependencia;
            IdPtaDependenciaFijo = idPtaDependenciaFijo;
            Fecha = fecha;
            Semestre = semestre;
            Observacion = observacion;
            Item = item;
            IdIdi_PlanEstudioPadre = idIdi_PlanEstudioPadre;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdPe = idPe;

            Idi_Curso = new List<model_Idi_Curso>();
        }
    }
}
