using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Usuarios.DataAccess
{
    public class DataAccess
    {
        private readonly string _connectionString;
        SqlConnection connection;
        public DataAccess(IConfiguration _configuration)
        {
            connection = new SqlConnection();
            _connectionString = _configuration.GetConnectionString("Connection");
            connection.ConnectionString = _connectionString;
        }

        public DataTable ProcedureTable(string procedure, bool parametersHave, SqlParameter[] parameters = null)
        {
            SqlCommand storedProcCommand = new SqlCommand(procedure, connection);
            SqlDataAdapter sda = new SqlDataAdapter(storedProcCommand);
            DataTable dt = new DataTable();
            storedProcCommand.CommandType = CommandType.StoredProcedure;

            if (parametersHave == true)
            {
                storedProcCommand.Parameters.AddRange(parameters);
            }
            storedProcCommand.CommandTimeout = 300;
            connection.Open();
            sda.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}

