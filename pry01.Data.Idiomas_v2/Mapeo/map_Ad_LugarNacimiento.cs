using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Ad_LugarNacimiento : IEntityTypeConfiguration<model_Ad_LugarNacimiento>
    {
        public virtual void Configure(EntityTypeBuilder<model_Ad_LugarNacimiento> builder)
        {
            builder.ToTable("Ad_LugarNacimiento");
            builder.HasKey(m => new { m.IdLugarNacimiento });

            builder.Property(m => m.IdLugarNacimiento).HasColumnName("IdLugarNacimiento");
            builder.Property(m => m.CodigoPersona).HasColumnName("CodPer");
            builder.Property(m => m.CodigoNacionalidad).HasColumnName("CodNac");
            builder.Property(m => m.CodigoDepartamento).HasColumnName("CodDep");
            builder.Property(m => m.CodigoProvincia).HasColumnName("CodProv");
            builder.Property(m => m.CodigoDistrito).HasColumnName("CodDist");
            builder.Property(m => m.Estado).HasColumnName("Estado");
        }
    }
}
