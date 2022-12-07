using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_CursoPeriodo
    {
        public int IdIdi_CursoPeriodo { get; set; }
        public int IdIdi_PeriodoEnsenianza { get; set; }
        public short IdIdi_Curso { get; set; }
        public string Curso { get; set; }
        public byte Ciclo { get; set; }
        public string Seccion { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int _IdSem { get; set; }
        public int _IdTurno { get; set; }
        public int _Codigo { get; set; }

        public model_dto_CursoPeriodo(int idIdi_CursoPeriodo = default
            , int idIdi_PeriodoEnsenianza = default
            , short idIdi_Curso = default
            , string curso = _defaultString
            , byte ciclo = default
            , string seccion = _defaultString
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int idSem = default
            , int idTurno = default
            , int codigo = default)
        {
            IdIdi_CursoPeriodo = idIdi_CursoPeriodo;
            IdIdi_PeriodoEnsenianza = idIdi_PeriodoEnsenianza;
            IdIdi_Curso = idIdi_Curso;
            Curso = curso;
            Ciclo = ciclo;
            Seccion = seccion;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            _IdSem = idSem;
            _IdTurno = idTurno;
            _Codigo = codigo;
        }
    }
}
