using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Microsoft.Extensions.Configuration;
using pry01.Data.Idiomas_v2.Mapeo;
using System;

namespace pry01.Data.Idiomas_v2.Conexto
{
    public class Matrix : DbContext
    {
        public Matrix(): base(GetContextOptions()) { }

        public virtual IDbContextTransaction _contexto_getBT() { return Database.BeginTransaction(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new map_SEMESTRE());
            modelBuilder.ApplyConfiguration(new map_Idi_Semestre());

            modelBuilder.ApplyConfiguration(new map_Idi_TurnoBase());
            modelBuilder.ApplyConfiguration(new map_Idi_TurnoDetalle());

            modelBuilder.ApplyConfiguration(new map_Ad_LugarNacimiento()); 
            modelBuilder.ApplyConfiguration(new map_PERSONA());
            modelBuilder.ApplyConfiguration(new map_Idi_Docente());
            modelBuilder.ApplyConfiguration(new map_ESTUDIANTE());
            
            modelBuilder.ApplyConfiguration(new map_Idi_Ambiente());
            modelBuilder.ApplyConfiguration(new map_Idi_Examen());
            modelBuilder.ApplyConfiguration(new map_viwIdi_Dependencia());
            
            modelBuilder.ApplyConfiguration(new map_Idi_NivelCurso());
            modelBuilder.ApplyConfiguration(new map_Idi_TipoCurso());
            modelBuilder.ApplyConfiguration(new map_Idi_PlanEstudio());
            modelBuilder.ApplyConfiguration(new map_Idi_Curso());
            modelBuilder.ApplyConfiguration(new map_Idi_Prerrequisito());

            modelBuilder.ApplyConfiguration(new map_Idi_TipoEntidadConvenio());
            modelBuilder.ApplyConfiguration(new map_Idi_EntidadConvenio());
            modelBuilder.ApplyConfiguration(new map_Idi_Convenio());

            modelBuilder.ApplyConfiguration(new map_ESTADOCURSO());
            modelBuilder.ApplyConfiguration(new map_ciudad());

            modelBuilder.ApplyConfiguration(new map_Idi_Horario());
            modelBuilder.ApplyConfiguration(new map_Idi_PeriodoEnsenianza());
            modelBuilder.ApplyConfiguration(new map_Idi_CursoPeriodo());
        }
        public static DbContextOptions<Matrix> GetContextOptions()
        {
            IConfigurationRoot configuracion = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("Extras/appsettings.json").Build();
            DbContextOptionsBuilder<Matrix> optionBuilder = new DbContextOptionsBuilder<Matrix>();
            optionBuilder.UseSqlServer(configuracion["ConnectionStrings:conexionMatrix"]);
            return optionBuilder.Options;
        }
    }
}
