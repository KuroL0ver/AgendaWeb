using AgendaWeb.Data.Commands;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;

namespace AgendaWeb.Services
{
    public class ContactoServices
    {
        private readonly ContactoCommand _contactoCommand;

        public ContactoServices(ContactoCommand contactoCommand)
        {
            _contactoCommand = contactoCommand;
        }

        public void Insertar(ContactoNuevoDto contactoNuevoDto)
        {
            Contacto contacto = new Contacto();
            contacto.Nombre = contactoNuevoDto.Nombre;
            contacto.Telefono = contactoNuevoDto.Telefono;
            contacto.Email = contactoNuevoDto.Email;

            int registrosAfectados = _contactoCommand.InsertarContacto(contacto);

            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo insertar el contacto.");
            }
        }
        public int EliminarContacto(int id)
        {
            return _contactoCommand.EliminarContacto(id);
        }

        public int ActualizarContacto(int id, ContactoActualizarDto contactoActualizarDto)
        {
            Contacto contacto = new Contacto
            {
                Nombre = contactoActualizarDto.Nombre,
                Telefono = contactoActualizarDto.Telefono,
                Email = contactoActualizarDto.Email
            };
            return _contactoCommand.ActualizarContacto(id, contacto);
        }
    }
}
