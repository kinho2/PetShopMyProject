using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Services
{
    public interface IClienteService
    {
        List<Cliente> GetClientes();
        void EditCliente(Cliente cliente);
        void AddCliente(Cliente cliente);
        void RemoveCliente(int clienteId);
        Cliente ObterClientePorId(int id);
    }
}
