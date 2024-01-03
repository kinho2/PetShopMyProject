using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShopMyProject.Data;
using PetShopMyProject.Models;
using System.Diagnostics;

namespace PetShopMyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PetShopContext _db;

        public HomeController (ILogger<HomeController> logger, PetShopContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
