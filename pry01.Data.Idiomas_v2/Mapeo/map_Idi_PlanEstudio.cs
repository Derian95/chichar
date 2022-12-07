using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_PlanEstudio : IEntityTypeConfiguration<model_Idi_PlanEstudio>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_PlanEstudio> builder)
        {
            builder.ToTable("Idi_PlanEstudio");
            builder.HasKey(m => new { m.IdIdi_PlanEstudio });

            builder.Property(m => m.IdIdi_PlanEstudio).HasColumnName("IdIdi_PlanEstudio");
            builder.Property(m => m.IdDependencia).HasColumnName("IdDepe");
            builder.Property(m => m.IdPtaDependenciaFijo).HasColumnName("IdPtaDependenciaFijo");
            builder.Property(m => m.Fecha).HasColumnName("Fecha");
            builder.Property(m => m.Semestre).HasColumnName("Semestre");
            builder.Property(m => m.Observacion).HasColumnName("Observacion");
            builder.Property(m => m.Item).HasColumnName("Item");
            builder.Property(m => m.IdIdi_PlanEstudioPadre).HasColumnName("IdIdi_PlanEstudioPadre");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdPe).HasColumnName("_IdPe");

            builder.HasMany(m => m.Idi_Curso).WithOne(n => n.Idi_PlanEstudio).HasForeignKey(o => o.IdIdi_PlanEstudio);
        }
    }
}
