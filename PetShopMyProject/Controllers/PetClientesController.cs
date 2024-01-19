using Microsoft.AspNetCore.Mvc;
using PetShopMyProject.Data;
using PetShopMyProject.Models;
using System.Linq;

namespace PetShopMyProject.Controllers
{
    public class PetClientesController : Controller
    {
        // GET: ClientesController
        private readonly PetShopContext _db;
        public PetClientesController(PetShopContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.PetCliente.ToList());
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {

            var petClientes = _db.PetCliente.Find(id);
            return View(petClientes);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCliente petClientes)
        {
            try
            {
                _db.PetCliente.Add(petClientes);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var petClientes = _db.PetCliente.Find(id);

            return View(petClientes);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetCliente petClientes)
        {
            try
            {
                var petClientesExiste = _db.PetCliente.Find(id);
                petClientesExiste.PetName = petClientes.PetName;
                petClientesExiste.TypePet = petClientes.TypePet;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PetCliente petClientes)
        {
            try
            {
                var petClientesExiste = _db.PetCliente.Find(id);
                _db.Remove(petClientesExiste);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
