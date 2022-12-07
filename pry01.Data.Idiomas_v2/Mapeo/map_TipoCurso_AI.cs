using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pry02.Model.Idiomas_v2.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_TipoCurso_AI : IEntityTypeConfiguration<model_TipoCurso_AI>
    {
        public virtual void Configure(EntityTypeBuilder<model_TipoCurso_AI> builder)
        {
            builder.ToTable("TipoCurso_AI");
            builder.HasKey(m => new { m.IdTipoCurso });

            builder.Property(m => m.IdTipoCurso).HasColumnName("idTipoCurso");
            builder.Property(m => m.Nombre).HasColumnName("Nombre");
            builder.Property(m => m.Usuario).HasColumnName("Usuario");
            builder.Property(m => m.FecRegistro).HasColumnName("fecRegistro");
        }
    }
}
