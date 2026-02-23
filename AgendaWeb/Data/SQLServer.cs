using Microsoft.Data.SqlClient;

namespace AgendaWeb.Data
{
    public class SQLServer
    {
        private readonly string _connectionString;

        public SQLServer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int NonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public T? Scalar <T>(string query, SqlParameter[] ? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    object respuesta = command.ExecuteScalar();

                  return respuesta is T  value ? value: default;


                }
            }
        }
    }
}