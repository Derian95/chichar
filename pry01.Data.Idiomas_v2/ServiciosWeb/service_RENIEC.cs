using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

using pry02.Model.Idiomas_v2.ServiciosWeb;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;


namespace pry01.Data.Idiomas_v2.ServiciosWeb
{
    public class service_RENIEC
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();

        public Response<SW_RENIECResult> fncService_ConsultarDNI(SW_RENIECRequest esquema)
        {
            IConfigurationRoot configuracion = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("Extras/appsettings.json").Build();
            RestClient cliente = new RestClient(configuracion["ExternalAPIs:RENIEC"]);

            string endPoint = "api/reniec/consultardni";
            RestRequest request = new RestRequest(endPoint, Method.POST);
            request.AddHeader("Authorization", "Basic " + "dXRpbGl0YXJpb0B1cHQuZWR1LnBlOllEV2RRV2RxVFZqYzk5OTk5OQ==");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(esquema);

            Response<SW_RENIECResult> resultado = new Response<SW_RENIECResult>();
            try
            {
                IRestResponse _response = cliente.Execute(request);
                resultado = JsonConvert.DeserializeObject<Response<SW_RENIECResult>>(_response.Content);
            }
            catch (Exception ex) { return _respuesta.AddError<SW_RENIECResult>(new[] { new _MensajeError(Convert.ToByte(enm_G_CodigoError.APIExterna), ex.Message) }); }

            return resultado;
        }
    }
}
