using PetShopMyProject.Connection;
using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Repositories
{
    public interface IPetClienteRepository
    {
        List<PetCliente> GetPetClientes();
        PetCliente GetPetCliente(int id);
        void AddPetCliente(PetCliente petCliente);
        void RemoveCliente(PetCliente petCliente);
        IUnitOfWork UnitOfWork();
    }
}