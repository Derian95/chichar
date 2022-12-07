using pry01.Data.Idiomas_v2.Acceso;
using pry02.Model.Idiomas_v2.Entidad;
using pry02.Model.Idiomas_v2.Procedimiento;

using pry100.Utilitario.Idiomas_v2.Clases;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Linq;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;
using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;

namespace pry03.Controller.Idiomas_v2
{
    public class controller_Idi_Docente
    {
        private readonly clsEsquemaRespuesta _respuesta = new clsEsquemaRespuesta();
        private readonly access_Idi_Docente _acc_Idi_Docente = new access_Idi_Docente();
        private readonly access_General _accGeneral = new access_General();

        public Response<List<model_dto_Docente>> fncCON_VisualListaDocente(short idIdi_Docente = -1)
        {
            Response<List<model_Idi_Docente>> data_Idi_Docente = _acc_Idi_Docente.fncACC_ListaDocente(idIdi_Docente);

            if (!data_Idi_Docente.Success) { return _respuesta.AddError<List<model_dto_Docente>>(data_Idi_Docente.MensajeError); }

            List<model_dto_Docente> informacion = data_Idi_Docente.Data.Select(c => new model_dto_Docente
            {
                IdIdi_Docente = c.IdIdi_Docente,
                IdEsc_TrabajadorDatosPersonales = c.IdEsc_TrabajadorDatosPersonales,
                NumeroDocumento = c.NumeroDocumento,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Nombres = c.Nombres,
                Estado = c.Estado,
                Activo = c.Activo,
            }).ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<model_Idi_Docente> fncCON_IndividualDocente(short idIdi_Docente)
        {
            Response<model_Idi_Docente> data_Idi_Docente = _acc_Idi_Docente.fncACC_DocenteIndividual(idIdi_Docente);

            if (!data_Idi_Docente.Success) { return _respuesta.AddError<model_Idi_Docente>(data_Idi_Docente.MensajeError); }

            return _respuesta.AddData(data_Idi_Docente.Data);
        }

        public Response<EsquemaRespuestaRegistro> fncCON_RegistrarDocente(model_Idi_Docente entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataFechaServidor.MensajeError); }

            model_Idi_Docente informacion = new model_Idi_Docente
            {
                IdIdi_Docente = entidad.IdIdi_Docente,
                IdEsc_TrabajadorDatosPersonales = entidad.IdEsc_TrabajadorDatosPersonales,
                NumeroDocumento = entidad.NumeroDocumento,
                ApellidoPaterno = entidad.ApellidoPaterno,
                ApellidoMaterno = entidad.ApellidoMaterno,
                Nombres = entidad.Nombres,
                Estado = 1,
                Activo = true,
                UsuarioCreacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaCreacion = dataFechaServidor.Data[0].FechaHoraServidor,
                UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario,
                FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor,
                DireccionIP = _obtenerDireccionIPv4(),
                DireccionMAC = _obtenerDireccionMAC()
            };

            Response<short> dataRegistro = _acc_Idi_Docente.fncACC_RegistrarDocente(informacion);

            if (!dataRegistro.Success) { return _respuesta.AddError<EsquemaRespuestaRegistro>(dataRegistro.MensajeError); }

            return _respuesta.AddData(new EsquemaRespuestaRegistro(identificador: Convert.ToInt64(dataRegistro.Data), true));
        }

        public Response<bool> fncCON_ModificarDocente(model_Idi_Docente entidad)
        {
            Response<List<model_Usp_Idi_S_FechaHoraServidor>> dataFechaServidor = _accGeneral.fncACC_FechaHoraServidor();

            if (!dataFechaServidor.Success) { return _respuesta.AddError<bool>(dataFechaServidor.MensajeError); }

            Response<model_Idi_Docente> informacion = _acc_Idi_Docente.fncACC_DocenteIndividual(entidad.IdIdi_Docente);
            if (!informacion.Success)
            {
                return _respuesta.AddError<bool>(informacion.MensajeError);
            }
            if (informacion.Data == null)
            {
                return _respuesta.AddError<bool>(new[] {
                    new _MensajeError(Convert.ToByte(enm_G_CodigoError.Validacion), "No se pudo identificar el registro") });
            }

            informacion.Data.IdEsc_TrabajadorDatosPersonales = entidad.IdEsc_TrabajadorDatosPersonales;
            informacion.Data.NumeroDocumento = entidad.NumeroDocumento;
            informacion.Data.ApellidoPaterno = entidad.ApellidoPaterno;
            informacion.Data.ApellidoMaterno = entidad.ApellidoMaterno;
            informacion.Data.Nombres = entidad.Nombres;
            informacion.Data.FechaModificacion = dataFechaServidor.Data[0].FechaHoraServidor;
            informacion.Data.UsuarioModificacion = stuSistema.esquemaUsuario.IdSegUsuario;
            informacion.Data.DireccionIP = _obtenerDireccionIPv4();
            informacion.Data.DireccionMAC = _obtenerDireccionMAC();

            Response<short> dataModificacion = _acc_Idi_Docente.fncACC_ActualizarDocente(informacion.Data);
            if (!dataModificacion.Success)
            {
                return _respuesta.AddError<bool>(dataModificacion.MensajeError);
            }

            return _respuesta.AddData(true);
        }

        public Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>> fncCON_RelacionDocentesEnEscalafon()
        {
            Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>> dataDistrito = _acc_Idi_Docente.fncACC_RelacionDocentesEnEscalafon();

            if (!dataDistrito.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id>>(dataDistrito.MensajeError); }

            List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_Id> informacion = dataDistrito.Data.ToList();

            return _respuesta.AddData(informacion);
        }

        public Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>> fncCON_RelacionDocentesEnEscalafon_NoSincronizado()
        {
            Response<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>> dataDistrito = _acc_Idi_Docente.fncACC_RelacionDocentesEnEscalafon_NoSincronizado();

            if (!dataDistrito.Success) { return _respuesta.AddError<List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento>>(dataDistrito.MensajeError); }

            List<model_Usp_Idi_S_Idi_ListarDocentesConEscalafon_NumeroDocumento> informacion = dataDistrito.Data.ToList();

            return _respuesta.AddData(informacion);
        }
    }
}
