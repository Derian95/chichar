using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Docente : IEntityTypeConfiguration<model_Idi_Docente>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Docente> builder)
        {
            builder.ToTable("Idi_Docente");
            builder.HasKey(m => new { m.IdIdi_Docente });

            builder.Property(m => m.IdIdi_Docente).HasColumnName("IdIdi_Docente");
            builder.Property(m => m.IdEsc_TrabajadorDatosPersonales).HasColumnName("IdEsc_TrabajadorDatosPersonales");
            builder.Property(m => m.NumeroDocumento).HasColumnName("NumeroDocumento");
            builder.Property(m => m.ApellidoPaterno).HasColumnName("ApellidoPaterno");
            builder.Property(m => m.ApellidoMaterno).HasColumnName("ApellidoMaterno");
            builder.Property(m => m.Nombres).HasColumnName("Nombres");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdDocente).HasColumnName("_IdDocente");
        }
    }
}
