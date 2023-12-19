using PetShopMyProject.Interfaces.Repositories;
using PetShopMyProject.Interfaces.Services;
using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.ApplicationService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepositoryBase<Cliente> _clienteRepositoryBase;
        public ClienteService(IClienteRepository clienteRepository, IRepositoryBase<Cliente> clienteRepositoryBase)
        {
            _clienteRepository = clienteRepository;
            _clienteRepositoryBase = clienteRepositoryBase;
        }

        public void AddCliente(Cliente cliente)
        {
            _clienteRepositoryBase.Add(cliente);
            _clienteRepositoryBase.UnitOfWork().Commit();
        }

        public void EditCliente(Cliente cliente)
        {
            var clienteExiste = _clienteRepositoryBase.GetById(cliente.ClienteId);
            clienteExiste.ClienteName = cliente.ClienteName;
            clienteExiste.ClienteEmail = cliente.ClienteEmail;
            clienteExiste.NumberPhone = cliente.NumberPhone;

            _clienteRepositoryBase.UnitOfWork().Commit();
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepositoryBase.GetAll();
        }

        public Cliente ObterClientePorId(int id)
        {
            return _clienteRepositoryBase.GetById(id);
        }

        public void RemoveCliente(int id)
        {
            var clienteExiste = _clienteRepositoryBase.GetById(id);
            _clienteRepositoryBase.Remove(clienteExiste);
            _clienteRepositoryBase.UnitOfWork().Commit();
        }
    }
}
