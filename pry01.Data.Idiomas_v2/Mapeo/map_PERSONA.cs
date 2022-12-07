using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using pry02.Model.Idiomas_v2.Entidad;

namespace pry01.Data.Idiomas_v2.Mapeo
{
    public class map_PERSONA : IEntityTypeConfiguration<model_PERSONA>
    {
        public virtual void Configure(EntityTypeBuilder<model_PERSONA> builder)
        {
            builder.ToTable("PERSONA");
            builder.HasKey(m => new { m.CodigoPersona });

            builder.Property(m => m.CodigoPersona).HasColumnName("CodPer");
            builder.Property(m => m.CodigoEstamento).HasColumnName("CodEstamento");
            builder.Property(m => m.ApellidoPaterno).HasColumnName("ApepPer");
            builder.Property(m => m.ApellidoMaterno).HasColumnName("ApemPer");
            builder.Property(m => m.Nombre).HasColumnName("NomPer");
            builder.Property(m => m.NumeroDocumento).HasColumnName("DniPer");
            builder.Property(m => m.FechaNacimiento).HasColumnName("FechaNac");
            builder.Property(m => m.CodigoLugarNacimiento).HasColumnName("CodLugNac");
            builder.Property(m => m.RUC).HasColumnName("RucPer");
            builder.Property(m => m.LibretaMilitar).HasColumnName("LmPer");
            builder.Property(m => m.Direccion).HasColumnName("Direccion");
            builder.Property(m => m.TelefonoFijo).HasColumnName("TelefFijo");
            builder.Property(m => m.TelefonoCelular).HasColumnName("TelefCelular");
            builder.Property(m => m.Sexo).HasColumnName("Sexo");
            builder.Property(m => m.Foto).HasColumnName("Foto");
            builder.Property(m => m.Usuario).HasColumnName("Usuario");
            builder.Property(m => m.Fecha).HasColumnName("Fecha");
            builder.Property(m => m.Email).HasColumnName("Email");
            builder.Property(m => m.GrupoSang).HasColumnName("GrupoSang");
            builder.Property(m => m.IndicacionMedica).HasColumnName("IndMedica");
            builder.Property(m => m.Activo).HasColumnName("Activo");
            builder.Property(m => m.EstadoCivil).HasColumnName("EstadoCivil");
            builder.Property(m => m.TipoDocumento).HasColumnName("TipoDocum");
            builder.Property(m => m.Observacion).HasColumnName("Perobs");
            builder.Property(m => m.LugarNacimiento).HasColumnName("LugNac");
        }
    }
}
