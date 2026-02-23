using Microsoft.Data.SqlClient;

namespace AgendaWeb.Data.Commands
{
    public class ContactoCommand
    {
        private readonly SQLServer _sqlServer;

        public ContactoCommand(SQLServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public int InsertarContacto(string nombre, string telefono, string email)
        {
            string query = "INSERT INTO Contactos " +
                "(Nombre, Telefono, Email) " +
                "VALUES " +
                "(@Nombre, @Telefono, @Email)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Telefono", telefono),
                new SqlParameter("@Email", email)
            };
            return _sqlServer.NonQuery(query, parameters);
        }

        public int EliminarContacto(int id)
        {
            string query = "DELETE FROM Contactos WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            return _sqlServer.NonQuery(query, parameters);
        }

        public int ActualizarContacto(int id, string nombre, string telefono, string email)
        {
            string query = "UPDATE Contactos " +
                "SET " +
                "Nombre = @Nombre, " +
                "Telefono = @Telefono, " +
                "Email = @Email " +
                "WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Telefono", telefono),
                new SqlParameter("@Email", email)
            };
            return _sqlServer.NonQuery(query, parameters);
        }
    }
}
