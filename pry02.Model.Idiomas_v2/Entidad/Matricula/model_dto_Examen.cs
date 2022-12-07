using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

using pry100.Utilitario.Idiomas_v2.Clases;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public enum enmTipoCalificacion
    {
        Ninguno,

        [customDescripcion("DE 0 A 100")]
        CeroACien,
    }

    public enum enmTipoExamen
    {
        Ninguno,

        [customDescripcion("Ubicación")]
        Ubicacion,
        
        [customDescripcion("Acreditación")]
        Acreditacion,
    }

    public class model_dto_Examen
    {
        public short IdIdi_Examen { get; set; }
        public short IdIdi_Docente { get; set; }
        public short IdIdi_Curso { get; set; }
        public short IdIdi_Semestre { get; set; }
        public string Semestre { get; set; }
        public short AnioSemestre { get; set; }
        public byte MesSemestre { get; set; }
        public byte IdIdi_TipoCalificacion { get; set; }
        public string TipoCalificacion { get; set; }
        public byte CodigoEstadoCurso { get; set; }
        public string EstadoCurso { get; set; }
        public byte TipoExamen { get; set; }
        public string TipoExamenDescripcion { get; set; }
        public int CodigoUniversitario { get; set; }
        public string Tema { get; set; }
        public DateTime Fecha { get; set; }
        public short Nota { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }

        public model_dto_Examen(short idIdi_Examen = default
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
            , bool activo = default)
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
        }
    }
}
