using System;
using System.Collections.Generic;
using System.Text;

namespace pry02.Model.Idiomas_v2.Entidad
{
    public class model_TipoCurso_AI
    {
        public byte IdTipoCurso { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public DateTime FecRegistro { get; set; }

        public model_TipoCurso_AI(byte idTipoCurso = default
            , string nombre = default
            , string usuario = default
            , DateTime fecRegistro = default)
        {
            IdTipoCurso = idTipoCurso;
            Nombre = nombre;
            Usuario = usuario;
            FecRegistro = fecRegistro;
        }
    }
}
