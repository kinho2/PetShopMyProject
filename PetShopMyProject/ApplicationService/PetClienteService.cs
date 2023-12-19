using PetShopMyProject.Interfaces.Repositories;
using PetShopMyProject.Interfaces.Services;
using PetShopMyProject.Models;
using System.Collections.Generic;

namespace PetShopMyProject.ApplicationService
{
    public class PetClienteService : IPetClienteService
    {
        private readonly IPetClienteRepository _petClienteRepository;
        private readonly IRepositoryBase<PetCliente> _petClienteRepositoryBase;

        public PetClienteService(IPetClienteRepository petClienteRepository, IRepositoryBase<PetCliente> petClienteRepositoryBase)
        {
            _petClienteRepository = petClienteRepository;
            _petClienteRepositoryBase = petClienteRepositoryBase;

        }

        public void AddPetCliente(PetCliente petCliente)
        {
            _petClienteRepositoryBase.Add(petCliente);
            _petClienteRepositoryBase.UnitOfWork().Commit();
        }
        public void EditPetCliente(PetCliente petCliente)
        {
            var petClienteExiste = _petClienteRepositoryBase.GetById(petCliente.PetId);
            petClienteExiste.PetName = petCliente.PetName;
            petClienteExiste.TypePet = petCliente.TypePet;
            _petClienteRepositoryBase.UnitOfWork().Commit();
        }
        public List<PetCliente> GetPetClientes()
        {
            return _petClienteRepositoryBase.GetAll();
        }
        public PetCliente ObterClientePorId(int id)
        {
            return _petClienteRepositoryBase.GetById(id);
        }
        public void RemovePetCliente(int id)
        {
            var petClienteExiste = _petClienteRepositoryBase.GetById(id);
            _petClienteRepositoryBase.Remove(petClienteExiste);
            _petClienteRepositoryBase.UnitOfWork().Commit();
        }
    }
}
