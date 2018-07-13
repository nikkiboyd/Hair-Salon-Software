using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = new List<Client> { };
            allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpPost("/clients")]
        public ActionResult SaveClient(int stylistId, string name, string phone, string email)
        {
            Client newClient = new Client(stylistId, name, phone, email);
            newClient.Save();
            return RedirectToAction("Details", new { id = newClient.Id });
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client currentClient = Client.Find(id);
            return View(currentClient);
        }
    }
}
