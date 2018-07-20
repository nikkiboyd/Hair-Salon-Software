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

        [HttpGet("/clients/new")]
        public ActionResult Create()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/clients")]
        public ActionResult SaveClient(int stylistId, string clientName, string clientPhone, string clientEmail)
        {
            Client newClient = new Client(stylistId, clientName, clientPhone, clientEmail);
            newClient.Save();
            return RedirectToAction("Details", new { id = newClient.Id });
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client currentClient = Client.Find(id);
            return View(currentClient);
        }

        [HttpGet("/clients/delete")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client currentClient = Client.Find(id);
            currentClient.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/update")]
        public IActionResult Update(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client currentClient = Client.Find(id);
            List<Stylist> stylistList = Stylist.GetAll();
            model.Add("client", currentClient);
            model.Add("stylists", stylistList);
            return View(model);
        }

        [HttpPost("/clients/{id}/update")]
        public IActionResult UpdateClient(int newStylist, string newName, string newPhone, string newEmail, int id)
        {
            Client currentClient = Client.Find(id);
            currentClient.Update(newStylist, newName, newPhone, newEmail, id);
            return RedirectToAction("Details");
        }
    }
}
