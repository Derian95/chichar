using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_CursoPeriodo : IEntityTypeConfiguration<model_Idi_CursoPeriodo>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_CursoPeriodo> builder)
        {
            builder.ToTable("Idi_CursoPeriodo");
            builder.HasKey(m => new { m.IdIdi_CursoPeriodo });

            builder.Property(m => m.IdIdi_CursoPeriodo).HasColumnName("IdIdi_CursoPeriodo");
            builder.Property(m => m.IdIdi_PeriodoEnsenianza).HasColumnName("IdIdi_PeriodoEnsenianza");
            builder.Property(m => m.IdIdi_Curso).HasColumnName("IdIdi_Curso");
            builder.Property(m => m.Seccion).HasColumnName("Seccion");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdSem).HasColumnName("_IdSem");
            builder.Property(m => m._IdTurno).HasColumnName("_IdTurno");
            builder.Property(m => m._Codigo).HasColumnName("_Codigo");

            builder.HasOne(m => m.Idi_PeriodoEnsenianza).WithMany(n => n.Idi_CursoPeriodo).HasForeignKey(o => o.IdIdi_PeriodoEnsenianza);
        }
    }
}
