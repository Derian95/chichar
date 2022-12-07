using pry100.Utilitario.Idiomas_v2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry100.Utilitario.Idiomas_v2.Enumerables
{
    public enum enm_G_Alignment
    {
        Center,
        Left,
        Rigth
    }
    public enum enm_G_TipoFormatoDataGridView
    {
        Visible,
        Fecha,
        Decimal,
        Entero
    }
    public enum enm_G_OrdenarModelo
    {
        Ascendente,
        Descendente
    }
    public enum enm_G_ClaseSemestre
    {
        Regular = 904010000
        , Intensivo = 904020000
    }
    public enum enm_G_TipoMensaje
    {
        Informacion,
        Pregunta
    }
    public enum enm_G_DiaSemana
    {
        Default,
        [customDescripcion("Lunes")]
        Lunes,
        [customDescripcion("Martes")]
        Martes,
        [customDescripcion("Miércoles")]
        Miercoles,
        [customDescripcion("Jueves")]
        Jueves,
        [customDescripcion("Viernes")]
        Viernes,
        [customDescripcion("Sábado")]
        Sabado,
        [customDescripcion("Domingo")]
        Domingo
    }

    public enum enm_G_MesAnio
    {
        Ninguno,
        [customDescripcion("Enero")]
        Enero,
        [customDescripcion("Febrero")]
        Febrero,
        [customDescripcion("Marzo")]
        Marzo,
        [customDescripcion("Abril")]
        Abril,
        [customDescripcion("Mayo")]
        Mayo,
        [customDescripcion("Junio")]
        Junio,
        [customDescripcion("Julio")]
        Julio,
        [customDescripcion("Agosto")]
        Agosto,
        [customDescripcion("Septiembre")]
        Septiembre,
        [customDescripcion("Octubre")]
        Octubre,
        [customDescripcion("Noviembre")]
        Noviembre,
        [customDescripcion("Diciembre")]
        Diciembre,
    }

    public enum enm_G_TipoHoraTurno
    {
        Default,
        Entrada,
        Salida
    }

    public enum enm_G_TipoAccionMantenimiento
    {
        Ninguno,
        Nuevo,
        Modificar,
        Cancelar
    }

    public enum enm_G_TipoAccionFormulario
    {
        Ninguno,
        Limpiar,
        LLenar
    }

    public enum enm_G_TipoValidacionRegex
    {
        Ninguno,
        Numeros,
        Letras,
        AlfaNumerico,
        Mail
    }

    public enum enm_G_ValidacionRENIEC
    {
        Ninguno,
        DatosIdenticos,
        DatosCorregidos,
        BusquedaManual,
        MenorEdad,
        SinResultado
    }

    public enum enm_G_TipoDocumento
    {
        Ninguno = 0,
        DNI = 1,
        CE = 4,
        Pasaporte = 7
    }
}
