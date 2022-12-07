using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

using pry02.Model.Idiomas_v2.ServiciosWeb;
using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

namespace pry01.Data.Idiomas_v2.ServiciosWeb
{
    public class service_Login
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();

        public Response<SW_LoginResult> fncService_Login(SW_LoginRequest esquema)
        {
            IConfigurationRoot configuracion = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("Extras/appsettings.json").Build();
            RestClient client = new RestClient(configuracion["ExternalAPIs:Autorizador"]);

            string endPoint = "api/identity/login";
            RestRequest request = new RestRequest(endPoint, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(esquema);

            Response<SW_LoginResult> resultado = new Response<SW_LoginResult>();
            try
            {
                IRestResponse _response = client.Execute(request);
                resultado = JsonConvert.DeserializeObject<Response<SW_LoginResult>>(_response.Content);
            }
            catch (Exception ex) { return _respuesta.AddError<SW_LoginResult>(new[] { new _MensajeError(Convert.ToByte(enm_G_CodigoError.APIExterna), ex.Message) }); }

            return resultado;
        }
    }
}
