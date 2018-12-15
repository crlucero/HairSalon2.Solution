using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        //SHOWS LIST OF STYLISTS CURRENTLY IN SALON
        [HttpPost("/stylists")]
        public ActionResult Create(string stylistName)
        {
            Stylist newStylist = new Stylist(stylistName);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        // SHOWS STYLIST DETAILS
        // [HttpGet("/stylists/{id}")]
        // public ActionResult Show(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Stylist selectedStylist = Stylist.Find(id);
        //     List<Client> stylistClients = selectedStylist.GetClients();
        //     model.Add("stylist", selectedStylist);
        //     model.Add("clients", stylistClients);
        //     return View(model);
        // }

        [HttpGet("/stylists/{stylistId}")]
        public ActionResult Show(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = Client.GetAll();
            List<Specialty> specialties = selectedStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            model.Add("specialties", specialties);
            model.Add("allspecialties", allSpecialties);
            return View(model);
        }




        [HttpPost("/stylists/{id}")]
        public ActionResult Create(int stylistId, string clientName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            List<Client> stylistClients = foundStylist.GetClients();
            List<Specialty> specialties = foundStylist.GetSpecialties();
            List<Specialty> allspecialties = Specialty.GetAll();
            model.Add("clients", stylistClients);
            model.Add("stylist", foundStylist);
            model.Add("specialties", specialties);
            model.Add("allSpecialties", allspecialties);
            return View("Show", model);
        }

        [HttpPost("/stylists/{id}/specialty/new")]
        public ActionResult AddSpecialty(int id, int specialtyId)
        {
            Stylist foundStylist = Stylist.Find(id);
            Specialty foundSpecialty = Specialty.Find(specialtyId);
            foundStylist.AddSpecialty(foundSpecialty);
            Dictionary<string, object> model = new Dictionary<string, object>();
            List<Client> stylistClients = Client.GetAll();
            List<Specialty> specialties = foundStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            model.Add("stylist", foundStylist);
            model.Add("clients", stylistClients);
            model.Add("specialties", specialties);
            model.Add("allspecialties", allSpecialties);
            return View("Show", model);
        }



        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult DeleteStylist(int id)
        {
            Stylist.DeleteStylist(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Stylist stylist = Stylist.Find(id);
            return View("Edit", stylist);
        }

        [HttpPost("/stylists/{id}/update")]
        public ActionResult Update(int id, string stylistName)
        {
            Stylist.Edit(id, stylistName);
            return RedirectToAction("Show", id);
        }

        
    }
}
