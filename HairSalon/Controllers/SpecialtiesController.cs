using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpPost("/specialties")]
        public ActionResult SaveSpecialty(string specialtyType)
        {
            Specialty newSpecialty = new Specialty(specialtyType);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/specialties/{id}")]
        public IActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty currentSpecialty = Specialty.Find(id);
            List<Stylist> stylistList = currentSpecialty.GetStylists();
            model.Add("specialty", currentSpecialty);
            model.Add("stylists", stylistList);
            return View(model);
        }

        [HttpGet("/specialties/{id}/assign")]
        public IActionResult Assign(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty currentSpecialty = Specialty.Find(id);
            List<Stylist> stylistList = Stylist.GetAll();
            model.Add("specialty", currentSpecialty);
            model.Add("stylists", stylistList);
            return View(model);
        }

        [HttpPost("/specialties/{id}/assign-stylist")]
        public IActionResult AssignSpecialty(int stylistId, int id)
        {
            Stylist newStylist = Stylist.Find(stylistId);
            Specialty newSpecialty = Specialty.Find(id);
            newSpecialty.AssignStylist(newStylist);
            return RedirectToAction("Details");
        }
    }
}
