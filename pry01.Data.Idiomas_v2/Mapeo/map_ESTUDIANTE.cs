using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_ESTUDIANTE : IEntityTypeConfiguration<model_ESTUDIANTE>
    {
        public virtual void Configure(EntityTypeBuilder<model_ESTUDIANTE> builder)
        {
            builder.ToTable("ESTUDIANTE");
            builder.HasKey(m => new { m.CodigoUniversitario });

            builder.Property(m => m.CodigoUniversitario).HasColumnName("CodUniv");
            builder.Property(m => m.ItemEstudiante).HasColumnName("ItemEst");
            builder.Property(m => m.CodigoPersona).HasColumnName("CodPer");
            builder.Property(m => m.IdDependencia).HasColumnName("Iddepe");
            builder.Property(m => m.CodigoEstamento).HasColumnName("CodEstamento");
            builder.Property(m => m.FechaIngreso).HasColumnName("FechIngreso");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.Observacion).HasColumnName("Observ");
            builder.Property(m => m.Usuario).HasColumnName("Usuario");
            builder.Property(m => m.Fecha).HasColumnName("Fecha");
            builder.Property(m => m.ModalidadIngreso).HasColumnName("ModIngreso");
        }
    }
}
