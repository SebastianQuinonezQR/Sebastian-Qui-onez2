using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Usuarios.DataAccess.Consult
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
            SqlParameter[] param = new SqlParameter[]
               {
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@USUARIO",
                    Value = login.Usuario
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@PASS",
                    Value = login.Pass
                }

               };
            DataAccess db = new DataAccess(configuration);
            DataTable dt = db.ProcedureTable("SP_LOGIN", true, param);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 2)
            {
                Entities.Answer.Login resultado = new Entities.Answer.Login
                {
                    Usuario = dt.Rows[0][0].ToString(),
                    Nombres = dt.Rows[0][1].ToString(),
                    Apellidos = dt.Rows[0][2].ToString(),
                    Email = dt.Rows[0][3].ToString(),
                    FechaCreacion = Convert.ToDateTime(dt.Rows[0][4].ToString()),
                    NumeroIdentificacion = dt.Rows[0][5].ToString(),
                    TipoIdentificacion = dt.Rows[0][6].ToString(),
                    IdentificacionConcatenada = dt.Rows[0][7].ToString(),
                    nombresConcatenados = dt.Rows[0][8].ToString()
                };
                resultado.Codigo = 1;
                resultado.Message = "OK";
                return resultado;
            }
            else
            {
                return new Entities.Answer.Login
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0]),
                    Message = dt.Rows[0][1].ToString()
                };
            }
        }
    }
}
