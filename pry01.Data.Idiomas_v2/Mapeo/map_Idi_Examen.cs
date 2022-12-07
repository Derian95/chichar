using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_Idi_Examen : IEntityTypeConfiguration<model_Idi_Examen>
    {
        public virtual void Configure(EntityTypeBuilder<model_Idi_Examen> builder)
        {
            builder.ToTable("Idi_Examen");
            builder.HasKey(m => new { m.IdIdi_Examen });

            builder.Property(m => m.IdIdi_Examen).HasColumnName("IdIdi_Examen");
            builder.Property(m => m.IdIdi_Docente).HasColumnName("IdIdi_Docente");
            builder.Property(m => m.IdIdi_Curso).HasColumnName("IdIdi_Curso");
            builder.Property(m => m.IdIdi_Semestre).HasColumnName("IdIdi_Semestre");
            builder.Property(m => m.IdIdi_TipoCalificacion).HasColumnName("IdIdi_TipoCalificacion");
            builder.Property(m => m.CodigoEstadoCurso).HasColumnName("CodEstado");
            builder.Property(m => m.TipoExamen).HasColumnName("TipoExamen");
            builder.Property(m => m.CodigoUniversitario).HasColumnName("CodigoUniversitario");
            builder.Property(m => m.Tema).HasColumnName("Tema");
            builder.Property(m => m.Fecha).HasColumnName("Fecha");
            builder.Property(m => m.Nota).HasColumnName("Nota");
            builder.Property(m => m.Estado).HasColumnName("Estado");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            builder.Property(m => m.FechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(m => m.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            builder.Property(m => m.FechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(m => m.DireccionIP).HasColumnName("DireccionIP");
            builder.Property(m => m.DireccionMAC).HasColumnName("DireccionMAC");
            builder.Property(m => m._IdExamen).HasColumnName("_IdExamen");
            builder.Property(m => m._IdSupervisor).HasColumnName("_IdSupervisor");
            builder.Property(m => m._IdCurso).HasColumnName("_IdCurso");
            builder.Property(m => m._IdSem).HasColumnName("_IdSem");
            builder.Property(m => m._IdTipoCalificacion).HasColumnName("_IdTipoCalificacion");
    }
    }
}
