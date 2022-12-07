using System;
using System.Collections.Generic;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry100.Utilitario.Idiomas_v2.Clases
{
    public class Response<TEntity>
    {
        public TEntity Data { get; set; }
        public bool Success { get; set; }
        public ICollection<_MensajeError> MensajeError { get; set; }
    }

    public class _MensajeError
    {
        public byte Codigo { get; set; }
        public string Mensaje { get; set; }
        public _MensajeError(byte codigo, string mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
        }
    }

    public class clsEsquemaRespuesta
    {
        public Response<TEntity> AddData<TEntity>(TEntity target)
        {
            return new Response<TEntity>()
            {
                Data = target
                , Success = true
            };
        }

        public Response<TEntity> AddData<TEntity>(TEntity target, ICollection<_MensajeError> mensajeError)
        {
            return new Response<TEntity>()
            {
                Data = target
                , Success = true
                , MensajeError = mensajeError
            };
        }

        public Response<TEntity> AddError<TEntity>(ICollection<_MensajeError> mensajeError)
        {
            return new Response<TEntity>()
            {
                MensajeError = mensajeError
            };
        }

        public static bool _validarRespuesta<customObject>(Response<customObject> target)
        {
            try
            {
                if (!target.Success) { return false; }
                if (target.Data == null) { return false; }
                return true;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }

        public static bool _validarRespuesta<customObject>(Response<List<customObject>> target)
        {
            try
            {
                if (!target.Success) { return false; }
                if (target.Data == null) { return false; }
                if (target.Data.Count == 0) { return false; }
                return true;
            }
            catch (Exception ex)
            {
                mtdMostrarMensaje(ex.Message);
                return false;
            }
        }
    }
}
