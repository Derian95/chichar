using System;
using System.Collections.Generic;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_PeriodoEnsenianza
    {
        public int IdIdi_PeriodoEnsenianza { get; set; }
        public short IdIdi_Docente { get; set; }
        public short IdIdi_Semestre { get; set; }
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
        public int _IdSem { get; set; }
        public int _IdTurno { get; set; }
        public int _Codigo { get; set; }

        public ICollection<model_Idi_CursoPeriodo> Idi_CursoPeriodo { get; set; }

        public model_Idi_PeriodoEnsenianza(int idIdi_PeriodoEnsenianza = default
            , short idIdi_Docente = default
            , short idIdi_Semestre = default
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
            , int idSem = default
            , int idTurno = default
            , int codigo = default)
        {
            IdIdi_PeriodoEnsenianza = idIdi_PeriodoEnsenianza;
            IdIdi_Docente = idIdi_Docente;
            IdIdi_Semestre = idIdi_Semestre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdSem = idSem;
            _IdTurno = idTurno;
            _Codigo = codigo;

            Idi_CursoPeriodo = new List<model_Idi_CursoPeriodo>();
        }
    }
}
