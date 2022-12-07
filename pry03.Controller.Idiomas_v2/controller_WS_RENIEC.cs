using pry01.Data.Idiomas_v2.ServiciosWeb;
using pry02.Model.Idiomas_v2.ServiciosWeb;

using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_WS_RENIEC
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly service_RENIEC _srvRENIEC = new service_RENIEC();

        public Response<SW_RENIECResult> fncCON_ConsultarDNI(string dni)
        {
            SW_RENIECRequest RENIECRequest = new SW_RENIECRequest
            {
                IdEscCredencialReniec = 1,
                IdSegSistema = stuSistema.IdSegSistema,
                IdSegUsuario = stuSistema.esquemaUsuario.IdSegUsuario,
                NumeroDocumento = dni
            };
            Response<SW_RENIECResult> dataConsultaDNI = _srvRENIEC.fncService_ConsultarDNI(RENIECRequest);

            if (!dataConsultaDNI.Success) { return _respuesta.AddError<SW_RENIECResult>(dataConsultaDNI.MensajeError); }

            return _respuesta.AddData(dataConsultaDNI.Data);
        }
    }
}
