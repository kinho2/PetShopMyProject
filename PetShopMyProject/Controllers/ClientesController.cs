﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopMyProject.Data;
using PetShopMyProject.Models;
using System.Linq;

namespace PetShopMyProject.Controllers
{
    public class ClientesController : Controller
    {
        // GET: ClientesController
        private readonly PetShopContext _db;
        public ClientesController(PetShopContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Clientes.ToList());
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {

            var cliente = _db.Clientes.Find(id);
            return View(cliente);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                _db.Clientes.Add(cliente);
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
            var cliente = _db.Clientes.Find(id);

            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                var clienteExiste = _db.Clientes.Find(id);
                clienteExiste.ClienteName = cliente.ClienteName;
                clienteExiste.ClienteEmail = cliente.ClienteEmail;
                clienteExiste.NumberPhone = cliente.NumberPhone;

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
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                var clienteExiste = _db.Clientes.Find(id);
                _db.Remove(clienteExiste);
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
