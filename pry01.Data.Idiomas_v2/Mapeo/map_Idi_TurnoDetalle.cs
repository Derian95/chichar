using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_TurnoDetalle : IEntityTypeConfiguration<model_Idi_TurnoDetalle>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_TurnoDetalle> builder)
        {
            builder.ToTable("Idi_TurnoDetalle");
            builder.HasKey(m => new { m.IdIdi_TurnoDetalle });

            builder.Property(m => m.IdIdi_TurnoDetalle).HasColumnName("IdIdi_TurnoDetalle");
            builder.Property(m => m.IdIdi_TurnoBase).HasColumnName("IdIdi_TurnoBase");
            builder.Property(m => m.NumeroDia).HasColumnName("NumeroDia");
            builder.Property(m => m.Desde).HasColumnName("Desde");
            builder.Property(m => m.Hasta).HasColumnName("Hasta");
            builder.Property(m => m.Estado).HasColumnName("Estado");
        }
    }
}
