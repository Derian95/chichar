using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Curso : IEntityTypeConfiguration<model_Idi_Curso>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Curso> builder)
        {
            builder.ToTable("Idi_Curso");
            builder.HasKey(m => new { m.IdIdi_Curso });
            
            builder.Property(m => m.IdIdi_Curso).HasColumnName("IdIdi_Curso");
            builder.Property(m => m.IdIdi_PlanEstudio).HasColumnName("IdIdi_PlanEstudio");
            builder.Property(m => m.IdIdi_NivelCurso).HasColumnName("IdIdi_NivelCurso");
            builder.Property(m => m.IdIdi_TipoCurso).HasColumnName("IdIdi_TipoCurso");
            builder.Property(m => m.CodigoCurso).HasColumnName("CodigoCurso");
            builder.Property(m => m.Asignatura).HasColumnName("Asignatura");
            builder.Property(m => m.Ciclo).HasColumnName("Ciclo");
            builder.Property(m => m.HorasTeoricas).HasColumnName("HorasTeoricas");
            builder.Property(m => m.HorasPracticas).HasColumnName("HorasPracticas");
            builder.Property(m => m.HorasLectivas).HasColumnName("HorasLectivas");
            builder.Property(m => m.Creditos).HasColumnName("Creditos");
            builder.Property(m => m.Electivo).HasColumnName("Electivo");
            builder.Property(m => m.Orden).HasColumnName("Orden");
            builder.Property(m => m.Ofertado).HasColumnName("Ofertado");
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
            builder.Property(m => m._IdNivel).HasColumnName("_IdNivel");
            builder.Property(m => m._IdTipoCurso).HasColumnName("_IdTipoCurso");

            builder.HasOne(m => m.Idi_PlanEstudio).WithMany(n => n.Idi_Curso).HasForeignKey(o => o.IdIdi_PlanEstudio);
        }
    }
}
