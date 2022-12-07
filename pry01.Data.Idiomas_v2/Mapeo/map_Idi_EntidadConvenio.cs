using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_EntidadConvenio : IEntityTypeConfiguration<model_Idi_EntidadConvenio>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_EntidadConvenio> builder)
        {
            builder.ToTable("Idi_EntidadConvenio");
            builder.HasKey(m => new { m.IdIdi_EntidadConvenio });

            builder.Property(m => m.IdIdi_EntidadConvenio).HasColumnName("IdIdi_EntidadConvenio");
            builder.Property(m => m.IdIdi_TipoEntidadConvenio).HasColumnName("IdIdi_TipoEntidadConvenio");
            builder.Property(m => m.Nombre).HasColumnName("Nombre");
            builder.Property(m => m._IdEntidad).HasColumnName("_IdEntidad");
            builder.Property(m => m._IdTipoEntidad).HasColumnName("_IdTipoEntidad");

            builder.HasMany(m => m.Idi_Convenio).WithOne(n => n.Idi_EntidadConvenio).HasForeignKey(o => o.IdIdi_EntidadConvenio);
        }
    }
}
