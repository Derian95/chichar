using pry01.Data.Idiomas_v2.ServiciosWeb;
using pry02.Model.Idiomas_v2.ServiciosWeb;
using pry100.Utilitario.Idiomas_v2.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_CURSO
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        //private readonly UptGenericoAccess _uptGenericoAccess = new UptGenericoAccess();
        //private readonly UptGenObjetoPruebaAccess _uptGenObjetoPruebaAccess = new UptGenObjetoPruebaAccess();


        //public Respuesta<List<GenObjetoPruebaModel>> ObtenerObjetosPrueba(string nombre, bool soloActivo)
        //{
        //    var objetos = _uptGenObjetoPruebaAccess.ObtenerObjetosPrueba(nombre, soloActivo);
        //    if (!objetos.Success)
        //    {
        //        return _respuesta.AddError<List<GenObjetoPruebaModel>>(objetos.MensajeError);
        //    }

        //    var resultado = objetos.Data.Select(c => new GenObjetoPruebaModel
        //    {
        //        IdGenObjetoPrueba = c.IdGenObjetoPrueba,
        //        Codigo = c.Codigo,
        //        Nombre = c.Nombre,
        //        Estado = c.Estado
        //    }).ToList();

        //    return _respuesta.AddData(resultado);
        //}
        //public Response<List<CursoData>> ListarCursos()
        //{

        //}

        //public Respo
    }
}
