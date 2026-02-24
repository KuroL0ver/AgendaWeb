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

        public int InsertarContacto(Contactos contacto)
        {
            string query = "INSERT INTO Contactos " +
                "(Nombre, Telefono, Email) " +
                "VALUES " +
                "(@Nombre, @Telefono, @Email)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono",contacto.Telefono),
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

        public int ActualizarContacto(int id,Contactos contacto)
        {
            string query = "UPDATE Contactos " +
                "SET " +
                "Nombre = @Nombre, " +
                "Telefono = @Telefono, " +
                "Email = @Email " +
                "WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono", contacto.Telefono),
                new SqlParameter("@Email", contacto.Email)
            };
            return _sqlServer.NonQuery(query, parameters);
        }

        internal void InsertarContacto()
        {
            throw new NotImplementedException();
        }
    }
}
