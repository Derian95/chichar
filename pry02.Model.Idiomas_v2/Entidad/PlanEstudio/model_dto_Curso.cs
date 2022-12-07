using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Curso
    {
        public short IdIdi_Curso { get; set; }
        public short IdIdi_PlanEstudio { get; set; }
        public short IdIdi_NivelCurso { get; set; }
        public short IdIdi_TipoCurso { get; set; }
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
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int _Idcurso { get; set; }
        public int _PreReq { get; set; }
        public byte _IdNivel { get; set; }
        public byte _IdTipoCurso { get; set; }
        public byte _auxiliarEmpadronamiento { get; set; }

        public model_dto_Curso(short idIdi_Curso = default
            , short idIdi_PlanEstudio = default
            , short idIdi_NivelCurso = default
            , short idIdi_TipoCurso = default
            , string codigoCurso = _defaultString
            , string asignatura = _defaultString
            , byte ciclo = default
            , byte horasTeoricas = default
            , byte horasPracticas = default
            , byte horasLectivas = default
            , byte creditos = default
            , bool electivo = default
            , string esElectivo = _defaultString
            , byte orden = default
            , bool ofertado = default
            , string esOfertado = _defaultString
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int idCurso = default
            , int preReq = default
            , byte idNivel = default
            , byte idTipoCurso = default
            , byte auxiliarEmpadronamiento = default)
        {
            IdIdi_Curso = idIdi_Curso;
            IdIdi_PlanEstudio = idIdi_PlanEstudio;
            IdIdi_NivelCurso = idIdi_NivelCurso;
            IdIdi_TipoCurso = idIdi_TipoCurso;
            CodigoCurso = codigoCurso;
            Asignatura = asignatura;
            Ciclo = ciclo;
            HorasTeoricas = horasTeoricas;
            HorasPracticas = horasPracticas;
            HorasLectivas = horasLectivas;
            Creditos = creditos;
            Electivo = electivo;
            EsElectivo = esElectivo;
            Orden = orden;
            Ofertado = ofertado;
            EsOfertado = esOfertado;
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            _Idcurso = idCurso;
            _PreReq = preReq;
            _IdNivel = idNivel;
            _IdTipoCurso = idTipoCurso;
            _auxiliarEmpadronamiento = auxiliarEmpadronamiento;
        }
    }
}


