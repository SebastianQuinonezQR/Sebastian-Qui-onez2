using Microsoft.Extensions.Configuration;
using System;

namespace Usuarios.Bussiness.Consult
{
    public class ConsultaPersonas
    {
        private readonly IConfiguration configuration;
        public ConsultaPersonas(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Answer.ConsultaUsuario Usu(string Identificacion)
        {
            try
            {
                DataAccess.Consult.ConsultaPersonas _db = new DataAccess.Consult.ConsultaPersonas(configuration);
                return _db.Usu(Identificacion);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
