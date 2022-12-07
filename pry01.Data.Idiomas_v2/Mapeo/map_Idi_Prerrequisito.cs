using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Prerrequisito : IEntityTypeConfiguration<model_Idi_Prerrequisito>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Prerrequisito> builder)
        {
            builder.ToTable("Idi_Prerrequisito");
            builder.HasKey(m => new { m.IdIdi_Prerrequisito });

            builder.Property(m => m.IdIdi_Prerrequisito).HasColumnName("IdIdi_Prerrequisito");
            builder.Property(m => m.IdIdi_Curso).HasColumnName("IdIdi_Curso");
            builder.Property(m => m.IdIdi_CursoPrerrequisito).HasColumnName("IdIdi_CursoPrerrequisito");
            builder.Property(m => m.IdTipo).HasColumnName("IdTipo");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._Idcurso).HasColumnName("_Idcurso");
            builder.Property(m => m._PreReq).HasColumnName("_PreReq");

        }
    }
}
