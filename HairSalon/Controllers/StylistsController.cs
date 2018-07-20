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
        public ActionResult SaveStylist(string stylistName)
        {
            Stylist newStylist = new Stylist(stylistName);
            newStylist.Save();
            return RedirectToAction("Details", new { id = newStylist.StylistId });
        }

        [HttpGet("/stylists/new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist currentStylist = Stylist.Find(id);
            List<Specialty> specialtyList = Stylist.GetSpecialtiesByStylist(currentStylist.StylistId);
            model.Add("stylist", currentStylist);
            model.Add("specialties", specialtyList);
            return View(model);
        }

        [HttpGet("/stylists/{id}/clients")]
        public ActionResult Clients(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            List<Client> stylistClients = new List<Client> { };
            stylistClients = Stylist.GetClientsByStylist(currentStylist.StylistId);
            return View(stylistClients);
        }

        [HttpGet("/stylists/delete")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{id}/delete")]
        public IActionResult Delete(int id)
        {
            Stylist newStylist = Stylist.Find(id);
            newStylist.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/update")]
        public IActionResult Update(int id)
        {
            Stylist newStylist = Stylist.Find(id);
            return View(newStylist);
        }

        [HttpPost("/stylists/{id}/update")]
        public IActionResult UpdateStylist(string newName, int id)
        {
            Stylist newStylist = Stylist.Find(id);
            newStylist.Update(newName);
            return RedirectToAction("Details");
        }

        [HttpGet("/stylists/{id}/add-specialty")]
        public IActionResult NewSpecialty(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist currentStylist = Stylist.Find(id);
            List<Specialty> specialtyList = Specialty.GetAll();
            model.Add("stylist", currentStylist);
            model.Add("specialties", specialtyList);
            return View(model);
        }

        [HttpPost("/stylists/{id}/add-specialty/confirm")]
        public IActionResult AddNewSpecialty(int specialty, int id)
        {
            Stylist newStylist = Stylist.Find(id);
            Specialty newSpecialty = Specialty.Find(specialty);
            newSpecialty.AssignStylist(newStylist);
            return RedirectToAction("Details");
        }
    }
}
