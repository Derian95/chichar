using System;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_Idi_TurnoDetalle
    {
        public short IdIdi_TurnoDetalle { get; set; }
        public short IdIdi_TurnoBase { get; set; }
        public byte NumeroDia { get; set; }
        public TimeSpan Desde { get; set; }
        public TimeSpan Hasta { get; set; }
        public byte Estado { get; set; }

        public model_Idi_TurnoDetalle(short idIdi_TurnoDetalle = default
            , short idIdi_TurnoBase = default
            , byte numeroDia = default
            , TimeSpan desde = default
            , TimeSpan hasta = default
            , byte estado = default)
        {
            IdIdi_TurnoDetalle = idIdi_TurnoDetalle;
            IdIdi_TurnoBase = idIdi_TurnoBase;
            NumeroDia = numeroDia;
            Desde = _obtenerDefaultTimeSpan(desde);
            Hasta = _obtenerDefaultTimeSpan(hasta);
            Estado = estado;
        }
    }
}
