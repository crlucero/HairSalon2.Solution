using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            Client foundClient = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", foundClient);
            model.Add("stylist", stylist);
            return View("Details", model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Details(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View("Details", model);
        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client foundClient = Client.Find(id);
            foundClient.DeleteClient();
            return View("Delete");
        }

        [HttpGet("/clients/delete/all")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return RedirectToAction("Index");
        }

      
        [HttpPost("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int clientId, int stylistId, string newName)
        {
            Client foundClient = Client.Find(clientId);
            foundClient.EditClient(newName);
            Client updatedClient = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>{};
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", updatedClient);
            model.Add("stylist", stylistId);
            return View("Details", model);
        }
    }
}
