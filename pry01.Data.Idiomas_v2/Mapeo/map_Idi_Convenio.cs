using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Convenio : IEntityTypeConfiguration<model_Idi_Convenio>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Convenio> builder)
        {
            builder.ToTable("Idi_Convenio");
            builder.HasKey(m => new { m.IdIdi_Convenio });

            builder.Property(m => m.IdIdi_Convenio).HasColumnName("IdIdi_Convenio"); 
            builder.Property(m => m.IdIdi_EntidadConvenio).HasColumnName("IdIdi_EntidadConvenio");
            builder.Property(m => m.Documento).HasColumnName("Documento");
            builder.Property(m => m.Pension).HasColumnName("Pension");
            builder.Property(m => m.FechaInicio).HasColumnName("FechaInicio");
            builder.Property(m => m.FechaFin).HasColumnName("FechaFin");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdConvenio).HasColumnName("_IdConvenio");
            builder.Property(m => m._IdEntidad).HasColumnName("_IdEntidad");

            builder.HasOne(m => m.Idi_EntidadConvenio).WithMany(n => n.Idi_Convenio).HasForeignKey(o => o.IdIdi_EntidadConvenio);
        }
    }
}
