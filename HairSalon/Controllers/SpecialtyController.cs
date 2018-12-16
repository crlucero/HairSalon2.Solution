using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string SpecialtyName)
        {
            Specialty newSpecialty = new Specialty(SpecialtyName);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("specialties/{id}")]
        public ActionResult Show(int id)
        {
            Specialty foundSpecialty = Specialty.Find(id);
            List<Stylist> stylists = foundSpecialty.GetStylists();
            Dictionary<string, object> model = new Dictionary<string, object>();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("specialty", foundSpecialty);
            model.Add("stylists", stylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }

        [HttpPost("/specialties{id}/specialty/new")]
        public ActionResult AddStylist(int id, int stylistId)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            Specialty foundSpecialty = Specialty.Find(id);
            foundStylist.AddSpecialty(foundSpecialty);
            List<Stylist> stylists = foundSpecialty.GetStylists();
            Dictionary<string, object> model = new Dictionary<string, object>();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("specialty", foundSpecialty);
            model.Add("stylists", stylists);
            model.Add("allStylists", allStylists);
            return View("Show", model);
        }

    }
}