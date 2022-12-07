using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry100.Utilitario.Idiomas_v2.Enumerables
{
    public enum enm_G_CodigoError
    {
        APIExterna = 0
        , DBInsertarRegistro = 1
        , DBActualizarRegistro = 2
        , DBObtenerRegistro = 3
        , DBObtenerListado = 4
        , DBProcedimientoA = 5
        , ValorNulo = 6
        , ListaVacia = 7
        , ListaMasDeUno = 8
        , Validacion = 9

        //OperacionModificada = 10,
        //MatriculaSinCuota = 11,
        //AdelantoConcepto = 12,
    }
}
