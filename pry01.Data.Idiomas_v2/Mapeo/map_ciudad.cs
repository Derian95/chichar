using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_ciudad : IEntityTypeConfiguration<model_ciudad>
    {
        public virtual void Configure(EntityTypeBuilder<model_ciudad> builder)
        {
            builder.ToTable("ciudad");
            builder.HasKey(m => new { m.CodigoCiudad });

            builder.Property(m => m.CodigoCiudad).HasColumnName("CodCiudad");
            builder.Property(m => m.Descripcion).HasColumnName("Descripcion");
            builder.Property(m => m.Relacion).HasColumnName("Relacion");
        }
    }
}
