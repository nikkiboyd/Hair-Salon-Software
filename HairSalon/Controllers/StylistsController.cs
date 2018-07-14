﻿using System;
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
        public ActionResult SaveStylist(string stylistName, int stylistId)
        {
            Stylist newStylist = new Stylist(stylistName, stylistId);
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
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
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
        public ActionResult DeleteStylist(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            currentStylist.Delete();
            return RedirectToAction("Index");
        }
    }
}
