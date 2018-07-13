using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpPost("/stylists")]
        public ActionResult SaveStylist(int id, string name)
        {
            Stylist newStylist = new Stylist(id, name);
            newStylist.Save();
            return RedirectToAction("Details", new { id = newStylist.StylistId });
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            //List<Client> allStylistClients = new List<Client> { };
            //allStylistClients = Stylist.GetClientsByStylist(id);
            return View(currentStylist);
        }

        [HttpPost("/stylists/{id}")]
        public ActionResult GetClients(int id)
        {
            List<Client> allStylistClients = new List<Client> { };
            allStylistClients = Stylist.GetClientsByStylist(id);
            return View("Details", allStylistClients)
        }
    }
}
