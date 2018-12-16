using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

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
        public ActionResult Details(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View(model);
        }

        [HttpGet("clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client foundClient = Client.Find(id);
            foundClient.DeleteClient();
            return RedirectToAction("Delete");
        }

        [HttpGet("/clients/delete/all")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return RedirectToAction("Index");
        }

        [HttpPost("clients/{id}/edit")]
        public ActionResult Edit(int id, string newName)
        {
            Client foundClient = Client.Find(id);
            foundClient.EditClient(newName);
            Client updatedClient = Client.Find(id);
            return View("Details", updatedClient);
        }
    }
}
