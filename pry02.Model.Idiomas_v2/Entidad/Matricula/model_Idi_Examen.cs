using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Examen
    {
        public short IdIdi_Examen { get; set; }
        public short IdIdi_Docente { get; set; }
        public short IdIdi_Curso { get; set; }
        public short IdIdi_Semestre { get; set; }
        public byte IdIdi_TipoCalificacion { get; set; }
        public byte CodigoEstadoCurso { get; set; }
        public byte TipoExamen { get; set; }
        public int CodigoUniversitario { get; set; }
        public string Tema { get; set; }
        public DateTime Fecha { get; set; }
        public short Nota { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _IdExamen { get; set; }
        public int _IdSupervisor { get; set; }
        public int _IdCurso { get; set; }
        public int _IdSem { get; set; }
        public byte _IdTipoCalificacion { get; set; }

        public model_Idi_Examen(short idIdi_Examen = default
            , short idIdi_Docente = default
            , short idIdi_Curso = default
            , short idIdi_Semestre = default
            , byte idIdi_TipoCalificacion = default
            , byte codigoEstadoCurso = default
            , byte tipoExamen = default
            , int codigoUniversitario = default
            , string tema = _defaultString
            , DateTime fecha = default
            , short nota = default
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idExamen = default
            , int idSupervisor = default
            , int idCurso = default
            , int idSem = default
            , byte idTipoCalificacion = default)
        {
            IdIdi_Examen = idIdi_Examen;
            IdIdi_Docente = idIdi_Docente;
            IdIdi_Curso = idIdi_Curso;
            IdIdi_Semestre = idIdi_Semestre;
            IdIdi_TipoCalificacion = idIdi_TipoCalificacion;
            CodigoEstadoCurso = codigoEstadoCurso;
            TipoExamen = tipoExamen;
            CodigoUniversitario = codigoUniversitario;
            Tema = tema;
            Fecha = _obtenerDefaultDateTime(fecha);
            Nota = nota;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdExamen = idExamen;
            _IdSupervisor = idSupervisor;
            _IdCurso = idCurso;
            _IdSem = idSem;
            _IdTipoCalificacion = idTipoCalificacion;
        }
    }
}
