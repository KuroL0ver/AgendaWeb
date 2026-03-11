using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AgendaWeb.Components.Pages
{
    public partial class Counter
    {
        //Solo en componentes Razor, se puede usar [Inject] para inyectar servicios, en este caso el ContactoServices
        [Inject] private ContactoServices ContactoServices { get; set; } = default!;
        private int currentCount = 0;

        //private void IncrementCount()
        //{
        //    currentCount++;

        //    string connectionString = "Server=localhost;Database=AgendaDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    String query = "INSERT INTO Contactos(Nombre, Telefono, Email) VALUES('Desde VS', '6621456823', 'Naura@gmail.com')";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.CommandType = CommandType.Text;

        //    connection.Open();

        //    command.ExecuteNonQuery();

        //    connection.Dispose();
        //}
        private void IncrementCount()
        {
            ContactoNuevoDto contactoNuevoDto = new ContactoNuevoDto
            {
                Nombre = "Utilizando services",
                Telefono = "6621456823",
                Email = "cosoloco13@gmail.com"
            };

            ContactoServices.Insertar(contactoNuevoDto);
        }
    }
}