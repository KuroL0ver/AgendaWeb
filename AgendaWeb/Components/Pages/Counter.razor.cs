using Microsoft.Data.SqlClient;
using System.Data;

namespace AgendaWeb.Components.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;

            string connectionString = "Server=localhost;Database=AgendaDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT into Contactos (Nombre, Telefono, Email) values ('Desde VS', '6623789065', 'esme2@gmail.com')"; 

            SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = CommandType.Text;


            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }
    }
}
