using System;
using System.Collections.Generic;
using System.Text;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Curso_Prerrequisito
    {
        public short IdIdi_Curso { get; set; }
        public string CodigoCurso { get; set; }
        public string Asignatura { get; set; }
        public byte Ciclo { get; set; }
        public byte HorasTeoricas { get; set; }
        public byte HorasPracticas { get; set; }
        public byte HorasLectivas { get; set; }
        public byte Creditos { get; set; }
        public bool Electivo { get; set; }
        public string EsElectivo { get; set; }
        public byte Orden { get; set; }
        public bool Ofertado { get; set; }
        public string EsOfertado { get; set; }        
        public short IdIdi_Prerrequisito { get; set; }
        public short IdIdi_CursoPrerrequisito { get; set; }
        public string Pre_CodigoCurso { get; set; }
        public string Pre_Asignatura { get; set; }
        public byte Pre_Ciclo { get; set; }
        public byte Pre_HorasTeoricas { get; set; }
        public byte Pre_HorasPracticas { get; set; }
        public byte Pre_HorasLectivas { get; set; }
        public byte Pre_Creditos { get; set; }
        public string Pre_Electivo { get; set; }
        public string Pre_Ofertado { get; set; }
    }
}
