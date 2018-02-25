using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
            return View("CreateForm");
        }

        [HttpPost("/stylists")]
        public ActionResult Create()
        {
            Stylist newStylist = new Stylist(Request.Form["stylistName"]);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist.SetCurrentStylistId(id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist thisStylist = Stylist.Find(id);
            List<Client> specificClients = Client.GetSpecificClients(id);
            model.Add("stylist", thisStylist);
            model.Add("clients", specificClients);
            return View("Details", model);
        }
    }
}
