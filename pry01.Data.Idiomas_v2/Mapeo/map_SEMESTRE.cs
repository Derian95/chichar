using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_SEMESTRE : IEntityTypeConfiguration<model_SEMESTRE>
    {
        public virtual void Configure(EntityTypeBuilder<model_SEMESTRE> builder)
        {
            builder.ToTable("SEMESTRE");
            builder.HasKey(m => new { m.IdSemestre });

            builder.Property(m => m.IdSemestre).HasColumnName("IdSem");
            builder.Property(m => m.Semestre).HasColumnName("Semestre");
            builder.Property(m => m.InicioClases).HasColumnName("InicioClases");
            builder.Property(m => m.MatriculaExtemporaneaInicio).HasColumnName("MatriExtempIni");
            builder.Property(m => m.MatriculaExtemporaneaFin).HasColumnName("MatriExtempFin");
            builder.Property(m => m.PrimerExamenParcialInicio).HasColumnName("PriExParcialIni");
            builder.Property(m => m.PrimerExamenParcialFin).HasColumnName("PriExParcialFin");
            builder.Property(m => m.FinClases).HasColumnName("FinClases");
            builder.Property(m => m.SegundoExamenParcialInicio).HasColumnName("SegExParcialIni");
            builder.Property(m => m.SegundoExamenParcialFin).HasColumnName("SegExParcialFin");
            builder.Property(m => m.ExtracurricularSustitutorioAplazadoInicio).HasColumnName("ExSustAplaIni");
            builder.Property(m => m.ExtracurricularSustitutorioAplazadoFin).HasColumnName("ExSustAplaFin");
            builder.Property(m => m.FinEntregaActas).HasColumnName("FinEntregaActas");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.Observacion).HasColumnName("Observ");
            builder.Property(m => m.Descripcion).HasColumnName("Dessem");
            builder.Property(m => m.InicioMatricula).HasColumnName("Inimatri");
            builder.Property(m => m.FinMatricula).HasColumnName("Finmatri");
            builder.Property(m => m.FechaInicioRectificacion).HasColumnName("FechaInicioRect");
            builder.Property(m => m.FechaFinRectificacion).HasColumnName("FechaFinRect");
            builder.Property(m => m.Orden).HasColumnName("Orden");
            builder.Property(m => m.Tipo).HasColumnName("Tipo");
            builder.Property(m => m.AmpliacionMatriculaNormal).HasColumnName("AmpMatNormal");
            builder.Property(m => m.AmpliacionProcesoMatricula).HasColumnName("AmpProcesoMat");
            builder.Property(m => m.Usuario).HasColumnName("Usuario");
            builder.Property(m => m.IdModalidadSemestre).HasColumnName("Idmodalidadsem");
            builder.Property(m => m.IdDependenciaSemestre).HasColumnName("Iddepesem");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
        }
    }
}
