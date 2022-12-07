using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Microsoft.VisualBasic; //Information.IsNumeric
using System.Net; //Dns
using System.Net.Sockets; //AddressFamily
using System.Net.NetworkInformation; //NetworkInterface, OperationalStatus

using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry100.Utilitario.Idiomas_v2.Clases
{
    public class clsGeneral
    {

        #region ======================================================== ESTRUCTURAS ========================================================
        public struct EsquemaUsuario
        {
            public int IdSegUsuario { get; set; } //intUSRid
            public string NombreUsuario { get; set; }
            public int IdSegPerfil { get; set; }
            public string NombrePerfil { get; set; }
            public short IdIdi_Docente { get; set; }
            public bool EsAdministrador { get; set; }

            public EsquemaUsuario(int idSegUsuario = default
                , string nombreUsuario = _defaultString
                , int idSegPerfil = default
                , string nombrePerfil = _defaultString
                , short idIdi_Docente = default
                , bool esAdministrador = default)
            {
                IdSegUsuario = idSegUsuario;
                NombreUsuario = nombreUsuario;
                IdSegPerfil = idSegPerfil;
                NombrePerfil = nombrePerfil;
                IdIdi_Docente = idIdi_Docente;
                EsAdministrador = esAdministrador;
            }
        }

        public struct EsquemaSistema
        {
            public short IdSegSistema { get; set; }
            public string NombreSistema { get; set; }
            public EsquemaUsuario esquemaUsuario { get; set; }
            public EsquemaCronograma esquemaCronograma { get; set; }

            public EsquemaSistema(EsquemaUsuario _esquemaUsuario = default
                , EsquemaCronograma _esquemaCronograma = default)
            {
                IdSegSistema = 10;
                NombreSistema = "SISTEMA INTEGRADO DE IDIOMAS";
                esquemaCronograma = _esquemaCronograma;
                esquemaUsuario = _esquemaUsuario;
            }
        }

        public struct EsquemaCronograma
        {
            public int IdSem { get; set; }
            public short IdIdi_Semestre { get; set; }
            public short Anio { get; set; }
            public byte Mes { get; set; }
            public string Semestre { get; set; }

            public EsquemaCronograma(int idSem = default
                , short idIdi_Semestre = default
                , short anio = default
                , byte mes = default
                , string semestre = default)
            {
                IdSem = idSem;
                IdIdi_Semestre = idIdi_Semestre;
                Anio = anio;
                Mes = mes;
                Semestre = semestre;
            }
        }

        public struct EsquemaRespuestaRegistro
        {
            public long Identificador { get; set; }
            public bool Resultado { get; set; }
            public EsquemaRespuestaRegistro(long identificador = default
                , bool resultado = default)
            {
                Identificador = identificador;
                Resultado = resultado;
            }
        }

        public struct EsquemaSemana
        {
            public TimeSpan Lunes { get; set; }
            public TimeSpan Martes { get; set; }
            public TimeSpan Miercoles { get; set; }
            public TimeSpan Jueves { get; set; }
            public TimeSpan Viernes { get; set; }
            public TimeSpan Sabado { get; set; }
            public TimeSpan Domingo { get; set; }

            public EsquemaSemana(TimeSpan lunes = default
                , TimeSpan martes = default
                , TimeSpan miercoles = default
                , TimeSpan jueves = default
                , TimeSpan viernes = default
                , TimeSpan sabado = default
                , TimeSpan domingo = default)
            {
                Lunes = lunes;
                Martes = martes;
                Miercoles = miercoles;
                Jueves = jueves;
                Viernes = viernes;
                Sabado = sabado;
                Domingo = domingo;
            }
        }

        public struct EsquemaTurnoDetalle
        {
            public short IdIdi_TurnoDetalle { get; set; }
            public enm_G_DiaSemana NumeroDia { get; set; }
            public string DiaDescripcion { get; set; }
            public enm_G_TipoHoraTurno Tipo { get; set; }
            public TimeSpan Hora { get; set; }
            public byte Estado { get; set; }

            public EsquemaTurnoDetalle(short idIdi_TurnoDetalle = default
                , enm_G_DiaSemana numeroDia = default
                , enm_G_TipoHoraTurno tipo = default
                , TimeSpan hora = default
                , byte estado = default)
            {
                IdIdi_TurnoDetalle = idIdi_TurnoDetalle;
                NumeroDia = numeroDia;
                Tipo = tipo;
                DiaDescripcion = numeroDia > 0 ? _obtenerNombreDia(numeroDia) : "";
                Hora = _obtenerDefaultTimeSpan(hora);
                Estado = estado;
            }
        }

        public struct EsquemaValidacion
        {
            public bool Validado { get; set; }
            public string Mensaje { get; set; }
            public EsquemaValidacion(bool validado = default
                , string mensaje = _defaultString)
            {
                Validado = validado;
                Mensaje = mensaje;
            }
        }

        public struct EsquemaError
        {
            public string Valor { get; set; }
            public string Observacion { get; set; }

            public EsquemaError(string valor = _defaultString
                , string observacion = _defaultString)
            {
                Valor = valor;
                Observacion = observacion;
            }
        }
        #endregion

        public static EsquemaSistema stuSistema = new EsquemaSistema();

        #region ========================================================= FUNCIONES =========================================================
        
        public static DateTime _obtenerDefaultDateTime(DateTime target = default) { return target == default || target == null ? new DateTime(1900, 01, 01) : target; }
        public static TimeSpan _obtenerDefaultTimeSpan(TimeSpan target = default) { return target == default || target == null ? new TimeSpan(0, 0, 0) : target; }
        public static string _obtenerNombreDia(enm_G_DiaSemana target) { return Enum.GetName(typeof(enm_G_DiaSemana), target); }
        public static List<short> _obtenerListaIdMes() { return new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; }

        public static long _obtenerEntero(object valor)
        {
            try { if (Information.IsNumeric(valor)) { return Convert.ToInt64(valor); } else { return 0; } }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); return 0; }
        }

        public static decimal _obtenerDecimal(object valor)
        {
            try { if (Information.IsNumeric(valor)) { return Convert.ToDecimal(valor); } else { return 0; } }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); return 0; }
        }

        public static string _obtenerDireccionIPv4()
        {
            try
            {
                IPHostEntry Host = Dns.GetHostEntry(Dns.GetHostName());
                return Host.AddressList.FirstOrDefault(c => c.AddressFamily == AddressFamily.InterNetwork).ToString();

            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            return _defaultString;
        }
        public static string _obtenerDireccionMAC()
        {
            try
            {
                NetworkInterface[] Interface = NetworkInterface.GetAllNetworkInterfaces();
                return Interface.FirstOrDefault(c => c.OperationalStatus == OperationalStatus.Up).GetPhysicalAddress().ToString();
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            return _defaultString;
        }

        public static string _obtenerEstadoValidacionRENIEC(enm_G_ValidacionRENIEC target)
        {
            try
            {
                switch (target)
                {
                    case enm_G_ValidacionRENIEC.DatosIdenticos: return "DATOS IDÉNTICOS";
                    case enm_G_ValidacionRENIEC.DatosCorregidos: return "DATOS CORREGIDOS";
                    case enm_G_ValidacionRENIEC.BusquedaManual: return "BÚSQUEDA MANUAL";
                    case enm_G_ValidacionRENIEC.MenorEdad: return "MENOR DE EDAD";
                    case enm_G_ValidacionRENIEC.SinResultado: return "SIN RESULTADO";
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return "NINGUNO";
        }

        public static string _obtenerRomanoFromEntero(int numero)
        {
            string resultado = _defaultString;
            
            int unidades = numero % 10; numero /= 10;
            int decenas = numero % 10; numero /= 10;
            int centenas = numero % 10; numero /= 10;
            int millares = numero % 10; numero /= 10;
            
            try
            {
                
                switch (millares)
                {
                    case 1: resultado += "M"; break;
                    case 2: resultado += "MM"; break;
                    case 3: resultado += "MMM"; break;
                }

                switch (centenas)
                {
                    case 1: resultado += "C"; break;
                    case 2: resultado += "CC"; break;
                    case 3: resultado += "CCC"; break;
                    case 4: resultado += "CD"; break;
                    case 5: resultado += "D"; break;
                    case 6: resultado += "DC"; break;
                    case 7: resultado += "DCC"; break;
                    case 8: resultado += "DCCC"; break;
                    case 9: resultado += "CM"; break;
                }

                switch (decenas)
                {
                    case 1: resultado += "X"; break;
                    case 2: resultado += "XX"; break;
                    case 3: resultado += "XXX"; break;
                    case 4: resultado += "XL"; break;
                    case 5: resultado += "L"; break;
                    case 6: resultado += "LX"; break;
                    case 7: resultado += "LXX"; break;
                    case 8: resultado += "LXXX"; break;
                    case 9: resultado += "XC"; break;
                }

                switch (unidades)
                {
                    case 1: resultado += "I"; break;
                    case 2: resultado += "II"; break;
                    case 3: resultado += "III"; break;
                    case 4: resultado += "IV"; break;
                    case 5: resultado += "V"; break;
                    case 6: resultado += "VI"; break;
                    case 7: resultado += "VII"; break;
                    case 8: resultado += "VIII"; break;
                    case 9: resultado += "IX"; break;
                }

                return resultado;

            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            
            return resultado;
        }

        public static byte _obtenerExtensionTipoDocumento(enm_G_TipoDocumento target)
        {
            try
            {
                switch (target)
                {
                    case enm_G_TipoDocumento.Ninguno: return 0;
                    case enm_G_TipoDocumento.DNI: return 8;
                    case enm_G_TipoDocumento.CE: return 9;
                    case enm_G_TipoDocumento.Pasaporte: return 12;
                    default: return 0;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return new byte();
        }

        public static EsquemaValidacion fncValidarDato(string dato, string mensaje, enm_G_TipoValidacionRegex opcion)
        {
            EsquemaValidacion respuesta = new EsquemaValidacion();
            try
            {
                if (dato.Trim() == "") { respuesta = new EsquemaValidacion(false, mensaje); }
                else if (!fncValidarRegex(dato, opcion)) { respuesta.Mensaje = "No se puede admitir este valor [" + dato + "] | " + mensaje; }
                else { respuesta.Validado = true; }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return respuesta;
        }

        public static bool fncValidarRegex(string dato, enm_G_TipoValidacionRegex opcion)
        {
            bool resultado = true;
            Regex regex = new Regex("");
            List<string> caracteres = new List<string>();

            caracteres.AddRange(dato.Select(c => c.ToString()));

            try
            {
                if (opcion != enm_G_TipoValidacionRegex.Ninguno)
                {
                    switch (opcion)
                    {
                        case enm_G_TipoValidacionRegex.Numeros:
                            regex = new Regex(@"[^0-9]");
                            break;
                        case enm_G_TipoValidacionRegex.Letras:
                            regex = new Regex(@"[^a-zA-Z]ñÑÁáÉéÍíÓóÚú");
                            break;
                        case enm_G_TipoValidacionRegex.AlfaNumerico:
                            regex = new Regex(@"[^a-zA-Z0-9]");
                            break;
                        case enm_G_TipoValidacionRegex.Mail:
                            regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                            break;
                    }

                    if (opcion == enm_G_TipoValidacionRegex.Mail) { if (regex.Matches(dato).Count <= 0) { return false; } }
                    else
                    {
                        for (int i = caracteres.Count - 1; i >= 0; i--)
                        {
                            if (!caracteres[i].Equals("") && caracteres[i].ToString() != "")
                            { if (regex.Matches(caracteres[i]).Count > 0) { return false; } }
                        }
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }

            return resultado;
        }

        #endregion

        #region ========================================================= METODOS =========================================================
        public static void mtdMostrarMensaje(string mensaje/*, enm_G_TipoMensaje tipoMensaje = enm_G_TipoMensaje.Informacion*/)
        {
            //MessageBoxButtons BotonesMostrar = new MessageBoxButtons();
            //MessageBoxIcon Icono = new MessageBoxIcon();
            //switch (tipoMensaje)
            //{
            //    case enm_G_TipoMensaje.Informacion:

            //    break;
            //    case enm_G_TipoMensaje.Pregunta:
            //        BotonesMostrar = MessageBoxButtons.YesNo;
            //        Icono = MessageBoxIcon.Question;
            //        break;
            //}
            MessageBox.Show(mensaje, stuSistema.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public static void mtdMostrarCentrado(Control principal, Control target)
        {
            try
            {
                target.Top = (principal.Height - target.Height) / 2;
                target.Left = (principal.Width - target.Width) / 2;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        #endregion
    }
}
