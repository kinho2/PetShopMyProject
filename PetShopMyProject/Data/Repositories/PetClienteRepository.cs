using PetShopMyProject.Connection;
using PetShopMyProject.Interfaces.Repositories;
using PetShopMyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShopMyProject.Data.Repositories
{
    public class PetClienteRepository : IPetClienteRepository
    {
        private readonly PetShopContext _db;

        public PetClienteRepository(PetShopContext db)
        {
            _db = db;
        }

        public IUnitOfWork UnitOfWork()
        {
            return _db;
        }

        public void AddPetCliente(PetCliente petCliente)
        {
            _db.Add(petCliente);
        }

        public PetCliente GetPetClienteBy(int id)
        {
            return _db.PetClientes.Find(id);
        }

        public List<PetCliente> GetPetClientes()
        {
            return _db.PetClientes.ToList();
        }

        public void RemoveCliente(PetCliente petCliente)
        {
            _db.Remove(petCliente);
        }
    }
}
