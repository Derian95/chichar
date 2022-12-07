using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_TipoEntidadConvenio : IEntityTypeConfiguration<model_Idi_TipoEntidadConvenio>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_TipoEntidadConvenio> builder)
        {
            builder.ToTable("Idi_TipoEntidadConvenio");
            builder.HasKey(m => new { m.IdIdi_TipoEntidadConvenio });

            builder.Property(m => m.IdIdi_TipoEntidadConvenio).HasColumnName("IdIdi_TipoEntidadConvenio");
            builder.Property(m => m.Descripcion).HasColumnName("Descripcion");
            builder.Property(m => m.Abreviacion).HasColumnName("Abreviacion");
            builder.Property(m => m._IdTipoEntidad).HasColumnName("_IdTipoEntidad");
        }
    }
}
