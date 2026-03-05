using AgendaWeb.Data.DTOS.Contactos;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class ContactoNuevo
    {
        protected ContactoNuevoDTO Contacto { get; set; } = new();

        protected bool MensajeExito { get; set; } = false;

        [Inject]
        protected NavigationManager Navigation { get; set; }

        protected async Task GuardarContacto()
        {
            // Aquí iría la llamada a tu servicio o repositorio
            // Ejemplo:
            // await _contactoService.CrearAsync(Contacto);

            MensajeExito = true;

            // Opcional: limpiar formulario
            Contacto = new ContactoNuevoDTO();

            await Task.CompletedTask;
        }
        protected void Cancelar()
        {
            Navigation.NavigateTo("/contactos");
        }
    }
}

