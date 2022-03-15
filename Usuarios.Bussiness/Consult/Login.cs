using Microsoft.Extensions.Configuration;
using System;

namespace Usuarios.Bussiness.Consult
{
    public class Login
    {
        private readonly IConfiguration configuration;
        public Login(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Answer.Login Auth(Entities.Body.Login login)
        {
            try
            {
                DataAccess.Consult.Login _db = new DataAccess.Consult.Login(configuration);
                return _db.Auth(login);
            }
            catch (Exception ex)
            {
                return new Entities.Answer.Login { Codigo = 0, Message = ex.Message };
            }
        }
    }
}
