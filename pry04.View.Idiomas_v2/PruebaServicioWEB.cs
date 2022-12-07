using pry02.Model.Idiomas_v2.ServiciosWeb;
using pry03.Controller.Idiomas_v2;
using pry04.View.Idiomas_v2.Principal;
using pry100.Utilitario.Idiomas_v2.Clases;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

using System;
using System.Linq;
using System.Windows.Forms;

namespace pry04.View.Idiomas_v2
{
    public partial class PruebaServicioWEB : Form
    {
        private  controller_WS_Login controller_WS_Login = new controller_WS_Login();
        public PruebaServicioWEB()
        {
            InitializeComponent();
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            Response<SW_LoginResult> login = controller_WS_Login.fncCON_Login("2010036214", "999999");
            if (!login.Success)
            {
                MessageBox.Show(login.MensajeError.ToList()[0].Mensaje, stuSistema.NombreSistema);
            }
            else
            {
                //Falta desencriptar texto
                //$Dato -->$string
                //$LlaveInterna = "BRuFTXfzmQBK"; -->$key
                //function fncFuncionesDesencriptarTexto($string, $key)
                //{
                //    $result = '';
                //    $string = base64_decode($string);
                //    for ($i = 0; $i < strlen($string); $i++)
                //    {
                //       $char = substr($string, $i, 1);
                //       $keychar = substr($key, ($i % strlen($key)) - 1, 1);
                //       $char = chr(ord($char) - ord($keychar));
                //       $result.=$char;
                //    }
                //    return $result;
                //}
                MessageBox.Show("Éxito", stuSistema.NombreSistema);
            }
        }

        private void PruebaServicioWEB_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFormularioPadre FrmPadre = new frmFormularioPadre();
            FrmPadre.Show();
        }
    }
}
