using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_Horario
    {
        public int IdIdi_Horario { get; set; }
        public byte NumeroDia { get; set; }
        public short IdIdi_Semestre { get; set; }
        public short IdIdi_Curso { get; set; }
        public string Seccion { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int _IdSem { get; set; }
        public int _IdTurno { get; set; }
        public int _Codigo { get; set; }

        public model_Idi_Horario(int idIdi_Horario = default
            , byte numeroDia = default
            , short idIdi_Semestre = default
            , short idIdi_Curso = default
            , string seccion = default
            , TimeSpan horaEntrada = default
            , TimeSpan horaSalida = default
            , byte estado = default
            , bool activo = default
            , int usuarioCreacion = default
            , DateTime fechaCreacion = default
            , int usuarioModificacion = default
            , DateTime fechaModificacion = default
            , string direccionIP = _defaultString
            , string direccionMAC = _defaultString
            , int idSem = default
            , int idTurno = default
            , int codigo = default)
        {
            IdIdi_Horario = idIdi_Horario;
            NumeroDia = numeroDia;
            IdIdi_Semestre = idIdi_Semestre;
            IdIdi_Curso = idIdi_Curso;
            Seccion = seccion;
            HoraEntrada = _obtenerDefaultTimeSpan(horaEntrada);
            HoraSalida = _obtenerDefaultTimeSpan(horaSalida);
            Estado = estado;
            Activo = activo;
            UsuarioCreacion = usuarioCreacion;
            FechaCreacion = _obtenerDefaultDateTime(fechaCreacion);
            UsuarioModificacion = usuarioModificacion;
            FechaModificacion = _obtenerDefaultDateTime(fechaModificacion);
            DireccionIP = direccionIP;
            DireccionMAC = direccionMAC;
            _IdSem = idSem;
            _IdTurno = idTurno;
            _Codigo = codigo;
        }
    }
}
