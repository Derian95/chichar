using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Semestre : IEntityTypeConfiguration<model_Idi_Semestre>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Semestre> builder)
        {
            builder.ToTable("Idi_Semestre");
            builder.HasKey(m => new { m.IdIdi_Semestre });

            builder.Property(m => m.IdIdi_Semestre).HasColumnName("IdIdi_Semestre");
            builder.Property(m => m.Anio).HasColumnName("Anio");
            builder.Property(m => m.Mes).HasColumnName("Mes");
            builder.Property(m => m.Semestre).HasColumnName("Semestre");
            builder.Property(m => m.InicioClases).HasColumnName("InicioClases");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdSem).HasColumnName("_IdSem");
        }
    }
}
