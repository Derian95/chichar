using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_ESTADOCURSO : IEntityTypeConfiguration<model_ESTADOCURSO>
    {
        public virtual void Configure(EntityTypeBuilder<model_ESTADOCURSO> builder)
        {
            builder.ToTable("ESTADOCURSO");
            builder.HasKey(m => new { m.CodigoEstado });

            builder.Property(m => m.CodigoEstado).HasColumnName("CodEstado");
            builder.Property(m => m.NombreEstado).HasColumnName("NomEstado");
        }
    }
}
