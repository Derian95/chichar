using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_NivelCurso : IEntityTypeConfiguration<model_Idi_NivelCurso>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_NivelCurso> builder)
        {
            builder.ToTable("Idi_NivelCurso");
            builder.HasKey(m => new { m.IdIdi_NivelCurso });

            builder.Property(m => m.IdIdi_NivelCurso).HasColumnName("IdIdi_NivelCurso");
            builder.Property(m => m.Nombre).HasColumnName("Nombre");
        }
    }
}
