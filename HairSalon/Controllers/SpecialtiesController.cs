﻿using System;
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
    }
}