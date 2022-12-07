using System;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_PeriodoEnsenianza
    {
        public int IdIdi_PeriodoEnsenianza { get; set; }
        public short IdIdi_Semestre { get; set; }
        public string Semestre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int _IdSem { get; set; }
        public int _IdTurno { get; set; }
        public int _Codigo { get; set; }
    }
}
