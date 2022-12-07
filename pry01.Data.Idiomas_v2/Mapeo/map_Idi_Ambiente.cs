using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Ambiente : IEntityTypeConfiguration<model_Idi_Ambiente>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Ambiente> builder)
        {
            builder.ToTable("Idi_Ambiente");
            builder.HasKey(m => new { m.IdIdi_Ambiente });

            builder.Property(m => m.IdIdi_Ambiente).HasColumnName("IdIdi_Ambiente");
            builder.Property(m => m.Codigo).HasColumnName("Codigo");
            builder.Property(m => m.Descripcion).HasColumnName("Descripcion");
            builder.Property(m => m.Tipo).HasColumnName("Tipo");
            builder.Property(m => m.Capacidad).HasColumnName("Capacidad");
            builder.Property(m => m._IdAula).HasColumnName("_IdAula");
        }
    }
}
