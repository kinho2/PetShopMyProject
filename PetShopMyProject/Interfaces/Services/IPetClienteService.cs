using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Services
{
    public interface IPetClienteService
    {
        List<PetCliente> GetPetClientes();
        void EditPetCliente(PetCliente petcliente);
        void AddPetCliente(PetCliente petclientee);
        void RemovePetCliente(int petId);
        PetCliente ObterClientePorId(int id);
    }
}
