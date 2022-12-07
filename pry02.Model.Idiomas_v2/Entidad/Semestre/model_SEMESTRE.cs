using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_SEMESTRE
    {
        public int IdSemestre { get; set; }
        public string Semestre { get; set; }
        public DateTime InicioClases { get; set; }
        public DateTime MatriculaExtemporaneaInicio { get; set; }
        public DateTime MatriculaExtemporaneaFin { get; set; }
        public DateTime PrimerExamenParcialInicio { get; set; }
        public DateTime PrimerExamenParcialFin { get; set; }
        public DateTime FinClases { get; set; }
        public DateTime SegundoExamenParcialInicio { get; set; }
        public DateTime SegundoExamenParcialFin { get; set; }
        public DateTime ExtracurricularSustitutorioAplazadoInicio { get; set; }
        public DateTime ExtracurricularSustitutorioAplazadoFin { get; set; }
        public DateTime FinEntregaActas { get; set; }
        public bool? Activo { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? InicioMatricula { get; set; }
        public DateTime? FinMatricula { get; set; }
        public DateTime? FechaInicioRectificacion { get; set; }
        public DateTime? FechaFinRectificacion { get; set; }
        public int? Orden { get; set; }
        public byte? Tipo { get; set; }
        public byte? AmpliacionMatriculaNormal { get; set; }
        public byte? AmpliacionProcesoMatricula { get; set; }
        public string Usuario { get; set; }
        public int? IdModalidadSemestre { get; set; }
        public int? IdDependenciaSemestre { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public model_SEMESTRE(int idSemestre = default
            , string semestre = _defaultString
            , DateTime inicioClases = default
            , string observacion = _defaultString
            , string descripcion = _defaultString
            , string usuario = _defaultString)
        {
            IdSemestre = idSemestre;
            Semestre = semestre;
            InicioClases = _obtenerDefaultDateTime(inicioClases);
            Observacion = observacion;
            Descripcion = descripcion;
            Usuario = usuario;

            //Datos directos, sin constructor por null
            //Activo = activo;
            //Orden = orden;
            //Idmodalidadsem = idModalidadSemestre;


            MatriculaExtemporaneaInicio = _obtenerDefaultDateTime(MatriculaExtemporaneaInicio);
            MatriculaExtemporaneaFin = _obtenerDefaultDateTime(MatriculaExtemporaneaFin);
            PrimerExamenParcialInicio = _obtenerDefaultDateTime(PrimerExamenParcialInicio);
            PrimerExamenParcialFin = _obtenerDefaultDateTime(PrimerExamenParcialFin);
            FinClases = _obtenerDefaultDateTime(FinClases);
            SegundoExamenParcialInicio = _obtenerDefaultDateTime(SegundoExamenParcialInicio);
            SegundoExamenParcialFin = _obtenerDefaultDateTime(SegundoExamenParcialFin);
            ExtracurricularSustitutorioAplazadoInicio = _obtenerDefaultDateTime(ExtracurricularSustitutorioAplazadoInicio);
            ExtracurricularSustitutorioAplazadoFin = _obtenerDefaultDateTime(ExtracurricularSustitutorioAplazadoFin);
            FinEntregaActas = _obtenerDefaultDateTime(FinEntregaActas);
            InicioMatricula = _obtenerDefaultDateTime();
            FinMatricula = _obtenerDefaultDateTime();
            FechaInicioRectificacion = _obtenerDefaultDateTime();
            FechaFinRectificacion = _obtenerDefaultDateTime();
            Tipo = 4;
            AmpliacionMatriculaNormal = 0;
            AmpliacionProcesoMatricula = 0;
            IdDependenciaSemestre = 0;
        }
    }
}
