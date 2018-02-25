using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients/new")]
        public ActionResult CreateForm()
        {
            int id = Stylist.GetCurrentStylistId();
            Stylist thisStylist = Stylist.Find(id);
            return View("CreateForm", thisStylist);
        }

        [HttpPost("/clients")]
        public ActionResult Create()
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            int id = Int32.Parse(Request.Form["stylistId"]);
            Stylist thisStylist = Stylist.Find(id);
            Client newClient = new Client(Request.Form["clientName"], id);
            newClient.Save();
            model.Add("stylist", thisStylist);
            model.Add("client", newClient);
            return View("Index", model);
        }
    }
}
