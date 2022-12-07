using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Horario : IEntityTypeConfiguration<model_Idi_Horario>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Horario> builder)
        {
            builder.ToTable("Idi_Horario");
            builder.HasKey(m => new { m.IdIdi_Horario });

            builder.Property(m => m.IdIdi_Horario).HasColumnName("IdIdi_Horario");
            builder.Property(m => m.NumeroDia).HasColumnName("NumeroDia");
            builder.Property(m => m.IdIdi_Semestre).HasColumnName("IdIdi_Semestre");
            builder.Property(m => m.IdIdi_Curso).HasColumnName("IdIdi_Curso");
            builder.Property(m => m.Seccion).HasColumnName("Seccion");
            builder.Property(m => m.HoraEntrada).HasColumnName("HoraEntrada");
            builder.Property(m => m.HoraSalida).HasColumnName("HoraSalida");
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
        }
    }
}
