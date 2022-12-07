using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_viwIdi_Dependencia : IEntityTypeConfiguration<model_viwIdi_Dependencia>
    {
        public virtual void Configure(EntityTypeBuilder<model_viwIdi_Dependencia> builder)
        {
            builder.ToTable("viwIdi_Dependencia");
            builder.HasKey(m => new { m.IdDependencia });

            builder.Property(m => m.IdDependencia).HasColumnName("IdDepe");
            builder.Property(m => m.Descripcion).HasColumnName("Descripcion");
            builder.Property(m => m.IdPtaDependenciaFijo).HasColumnName("IdPtaDependenciaFijo");
        }
    }
}
