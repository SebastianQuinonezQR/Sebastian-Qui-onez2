using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Usuarios.DataAccess.Consult
{
    public class ConsultaPersonas
    {
        private readonly IConfiguration configuration;
        public ConsultaPersonas(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public Entities.Answer.ConsultaUsuario Usu(string Identifcacion)
        {
            SqlParameter[] param = new SqlParameter[]
               {
                new SqlParameter
                {
                    DbType = DbType.String,
                    Size = 20,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NUMIDENTIFICACION",
                    Value = Identifcacion
                }
               };
            DataAccess db = new DataAccess(configuration);
            DataTable dt = db.ProcedureTable("SP_CONSULTA_PERSONAS", true, param);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 2)
            {
                Entities.Answer.ConsultaUsuario resultado = new Entities.Answer.ConsultaUsuario
                {
                    Id = Convert.ToInt32(dt.Rows[0][0].ToString()),
                    Nombres = dt.Rows[0][1].ToString(),
                    Apellidos = dt.Rows[0][2].ToString(),
                    NumeroIdentificacion = dt.Rows[0][3].ToString(),
                    Email = dt.Rows[0][3].ToString(),
                    TipoIdentificacion = dt.Rows[0][5].ToString(),
                    FechaCreacion = Convert.ToDateTime(dt.Rows[0][6].ToString()),
                    NombreConctenados = dt.Rows[0][7].ToString(),
                    IdentificacionConcatenada = dt.Rows[0][8].ToString()
                };
                return resultado;
            }
            else
            {
                return null;
            }
        }
    }
}
