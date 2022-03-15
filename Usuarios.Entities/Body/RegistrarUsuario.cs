using System;

namespace Usuarios.Entities.Body
{
    public class RegistrarUsuario
    {
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
    }
}
