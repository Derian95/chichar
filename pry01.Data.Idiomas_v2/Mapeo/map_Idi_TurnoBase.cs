using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_TurnoBase : IEntityTypeConfiguration<model_Idi_TurnoBase>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_TurnoBase> builder)
        {
            builder.ToTable("Idi_TurnoBase");
            builder.HasKey(m => new { m.IdIdi_TurnoBase });

            builder.Property(m => m.IdIdi_TurnoBase).HasColumnName("IdIdi_TurnoBase");
            builder.Property(m => m.Descripcion).HasColumnName("Descripcion");
        }
    }
}
