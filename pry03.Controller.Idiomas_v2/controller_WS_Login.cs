using pry01.Data.Idiomas_v2.ServiciosWeb;
using pry02.Model.Idiomas_v2.ServiciosWeb;

using pry100.Utilitario.Idiomas_v2.Clases;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_WS_Login
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly service_Login _srvLogin = new service_Login();

        public Response<SW_LoginResult> fncCON_Login(string usuario, string contrasenia)
        {
            SW_LoginRequest loginRequest = new SW_LoginRequest
            {
                IdSistema = stuSistema.IdSegSistema,
                IdTipoUsuario = 2,
                Usuario = usuario,
                Contrasenia = contrasenia
            };
            Response<SW_LoginResult> login = _srvLogin.fncService_Login(loginRequest);
            
            if (!login.Success) { return _respuesta.AddError<SW_LoginResult>(login.MensajeError); }

            return _respuesta.AddData(login.Data);
        }
    }
}
