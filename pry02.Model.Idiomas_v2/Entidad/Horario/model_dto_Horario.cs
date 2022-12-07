using System;
namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Horario
    {
        public int IdIdi_Horario { get; set; }
        public byte NumeroDia { get; set; }
        public string NombreDia { get; set; }
        public string Dependencia { get; set; }
        public short IdIdi_Semestre { get; set; }
        public string Semestre { get; set; }
        public short IdIdi_Curso { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
    }
}
