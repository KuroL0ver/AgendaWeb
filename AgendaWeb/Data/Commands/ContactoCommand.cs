using AgendaWeb.Data.Entities;
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

        public List<Contacto> ObtenerContactos()
        {
            string query = "SELECT Id, Nombre, Telefono, Email FROM Contactos ORDER BY Nombre ASC";
            string[] columns = new[] { "Id", "Nombre", "Telefono", "Email" };

            return _sqlServer.Query<Contacto>(query, reader  =>
            {
                int ordId = reader.GetOrdinal("Id");
                int ordNombre = reader.GetOrdinal("Nombre");
                int ordTelefono = reader.GetOrdinal("Telefono");
                int ordEmail = reader.GetOrdinal("Email");

                return new Contacto
                {
                    Id = reader.GetInt32(ordId),
                    Nombre = reader.IsDBNull(ordNombre) ? string.Empty : reader.GetString(ordNombre),
                    Telefono = reader.IsDBNull(ordTelefono) ? string.Empty : reader.GetString(ordTelefono),
                    Email = reader.IsDBNull(ordEmail) ? string.Empty : reader.GetString(ordEmail)
                };
            });
        }

        public int InsertarContacto(Contacto contacto)
        {
            string query = "INSERT INTO Contactos" +
                " (Nombre, Telefono, Email) " +
                "VALUES " +
                "(@Nombre, @Telefono, @Email)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono", contacto.Telefono),
                new SqlParameter("@Email", contacto.Email)
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

        public int ActualizarContacto(int id, Contacto contacto)
        {
            string query = "UPDATE Contactos " +
                "SET" +
                " Nombre = @Nombre, " +
                "Telefono = @Telefono, " +
                "Email = @Email " +
                "WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono", contacto.Telefono),
                new SqlParameter("@Email", contacto.Email)
            };
            return _sqlServer.NonQuery(query, parameters);
        }
    }
}
