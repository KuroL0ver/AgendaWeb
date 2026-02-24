using AgendaWeb.Data.Commands;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;

namespace AgendaWeb.Services
{
    public class ContactosServices
    {
        private readonly ContactoCommand _contactoCommand;

        public ContactosServices(ContactoCommand contactoCommand)
        {
            _contactoCommand = contactoCommand;
        }

        public void Insertar(ContactoNuevoDTO contactoNuevoDTO)
        {
            Contactos contacto = new Contactos();


                contacto.Nombre = contactoNuevoDTO.Nombre;
            contacto.Telefono = contactoNuevoDTO.Telefono;
            contacto.Email = contactoNuevoDTO.Email;
                  _contactoCommand.InsertarContacto();

            int registrosAfectados = _contactoCommand.InsertarContacto(contacto);
            if (registrosAfectados == 0)
            { 
             throw new Exception("No se pudo insertar el contacto.");
            }


        }
    }
}
