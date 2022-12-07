using System;
using System.Collections.Generic;
using System.Text;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Docente
    {
        public short IdIdi_Docente { get; set; }
        public long IdEsc_TrabajadorDatosPersonales { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public byte Estado { get; set; }
        public bool Activo { get; set; }

        public model_dto_Docente(short idIdi_Docente = default
            , long idEsc_TrabajadorDatosPersonales = default
            , string numeroDocumento = _defaultString
            , string apellidoPaterno = _defaultString
            , string apellidoMaterno = _defaultString
            , byte estado = default
            , bool activo = default)
        {
            IdIdi_Docente = idIdi_Docente;
            IdEsc_TrabajadorDatosPersonales = IdEsc_TrabajadorDatosPersonales;
            NumeroDocumento = numeroDocumento;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = Nombres;
            Estado = estado;
            Activo = activo;
        }
    }
}
