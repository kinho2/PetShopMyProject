using PetShopMyProject.Connection;
using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente>GetClientes();
        Cliente GetClienteBy(int id);
        void AddCliente(Cliente cliente);
        void RemoveCliente(Cliente cliente);
        IUnitOfWork UnitOfWork();
    }
}
