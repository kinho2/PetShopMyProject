using PetShopMyProject.Connection;
using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Repositories
{
    public interface IPetClienteRepository
    {
        List<PetCliente> GetPetClientes();
        PetCliente GetPetClienteBy(int id);
        void AddPetCliente(PetCliente petCliente);
        void RemoveCliente(PetCliente petCliente);
        IUnitOfWork UnitOfWork();
    }
}