using PetShopMyProject.Connection;
using PetShopMyProject.Interfaces.Repositories;
using PetShopMyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShopMyProject.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PetShopContext _db;

        public ClienteRepository(PetShopContext db)
        {
            _db = db;
        }

        public IUnitOfWork UnitOfWork()
        {
            return _db;
        }

        public void AddCliente(Cliente cliente)
        {
            _db.Add(cliente);
        }

        public Cliente GetClienteBy(int id)
        {
            return _db.Cliente.Find(id);
        }

        public List<Cliente> GetClientes()
        {
            return _db.Cliente.ToList();
        }

        public void RemoveCliente(Cliente cliente)
        {
            _db.Remove(cliente);
        }
    }
}
