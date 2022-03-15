using System;

namespace Usuarios.Entities.Answer
{
    public class Login : Response
    {
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string IdentificacionConcatenada { get; set; }
        public string nombresConcatenados { get; set; }

    }
}
