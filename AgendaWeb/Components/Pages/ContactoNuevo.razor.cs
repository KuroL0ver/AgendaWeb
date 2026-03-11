using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class ContactoNuevo
    {
        protected ContactoNuevoDto Contacto { get; set; } = new();

        protected bool MensajeExito { get; set; } = false;

        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected ContactoServices ContactoServices { get; set; }

        protected async Task GuardarContacto()
        {
            ContactoServices.Insertar(Contacto);

            await Task.CompletedTask;
        }
        protected void Cancelar()
        {
            Navigation.NavigateTo("/contactos");
        }
    }
}
