using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Usuarios.DataAccess.Consult
{
    public class RegistrarUsuario
    {
        private readonly IConfiguration configuration;
        public RegistrarUsuario(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public Entities.Answer.Response Usu(Entities.Body.RegistrarUsuario registrar)
        {
            SqlParameter[] param = new SqlParameter[]
               {
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NOMBRES",
                    Value = registrar.Nombres
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@APELLIDOS",
                    Value = registrar.Apellidos
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NUMIDENTIFICACION",
                    Value = registrar.NumeroIdentificacion
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@EMAIL",
                    Value = registrar.Email
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@TIPOIDENTIFICACION",
                    Value = registrar.TipoIdentificacion
                },
                new SqlParameter
                {
                    DbType = DbType.DateTime,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@FECHACREACION",
                    Value = DateTime.Now
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@USUARIO",
                    Value = registrar.Usuario
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@PASS",
                    Value = registrar.Pass
                }
               };
            DataAccess db = new DataAccess(configuration);
            DataTable dt = db.ProcedureTable("[dbo].[SP_INSERTAR_USUARIOS]", true, param);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 2)
            {
                Entities.Answer.Response resultado = new Entities.Answer.Response
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0].ToString()),
                    Message = dt.Rows[0][1].ToString(),
                };
                return resultado;
            }
            else
            {
                return new Entities.Answer.Response
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0]),
                    Message = dt.Rows[0][1].ToString()
                };
            }
        }
    }
}
