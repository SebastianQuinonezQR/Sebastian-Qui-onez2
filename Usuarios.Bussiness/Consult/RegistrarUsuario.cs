using Microsoft.Extensions.Configuration;
using System;

namespace Usuarios.Bussiness.Consult
{
    public class RegistrarUsuario
    {
        private readonly IConfiguration configuration;
        public RegistrarUsuario(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Answer.Response Usu(Entities.Body.RegistrarUsuario Usuario)
        {
            try
            {
                DataAccess.Consult.RegistrarUsuario _db = new DataAccess.Consult.RegistrarUsuario(configuration);
                if (Usuario.TipoIdentificacion != "Seleccione")
                {
                    return _db.Usu(Usuario);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
