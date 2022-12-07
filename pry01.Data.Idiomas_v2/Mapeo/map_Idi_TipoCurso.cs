using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_TipoCurso : IEntityTypeConfiguration<model_Idi_TipoCurso>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_TipoCurso> builder)
        {
            builder.ToTable("Idi_TipoCurso");
            builder.HasKey(m => new { m.IdIdi_TipoCurso });

            builder.Property(m => m.IdIdi_TipoCurso).HasColumnName("IdIdi_TipoCurso");
            builder.Property(m => m.Nombre).HasColumnName("Nombre");
            builder.Property(m => m._IdTipoCurso).HasColumnName("_IdTipoCurso");
        }
    }
}
