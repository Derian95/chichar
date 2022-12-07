using System;
using System.Collections.Generic;
using System.Text;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_PlanEstudio
    {
        public short IdIdi_PlanEstudio { get; set; }
        public int IdDependencia { get; set; }
        public int IdPtaDependenciaFijo { get; set; }
        public string Idioma { get; set; }
        public DateTime Fecha { get; set; }
        public string Semestre { get; set; }
        public string Observacion { get; set; }
        public byte Item { get; set; }
        public short IdIdi_PlanEstudioPadre { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public string EsActivo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }        
        public short _IdPe { get; set; }
    }
}



