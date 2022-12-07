using System;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_dto_Convenio
    {
        public short IdIdi_Convenio { get; set; }
        public short IdIdi_EntidadConvenio { get; set; }
        public string EntidadConvenio { get; set; }
        public string Documento { get; set; }
        public decimal Pension { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public model_dto_Convenio(short idIdi_Convenio = default
            , short idIdi_EntidadConvenio = default
            , string entidadConvenio = _defaultString
            , string documento = _defaultString
            , decimal pension = default
            , DateTime fechaInicio = default
            , DateTime fechaFin = default)
        {
            IdIdi_Convenio = idIdi_Convenio;
            IdIdi_EntidadConvenio = idIdi_EntidadConvenio;
            EntidadConvenio = entidadConvenio;
            Documento = documento;
            Pension = pension;
            FechaInicio = _obtenerDefaultDateTime(fechaInicio);
            FechaFin = _obtenerDefaultDateTime(fechaFin);
        }
    }
}
