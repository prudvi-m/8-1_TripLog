using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TripLog.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }

        // public HomeController(TripLogContext ctx) => context = ctx;

        public ViewResult Index()
        {
            var trips = new List<Trip>();
            try {
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Destination")))
                {
                    if (!string.IsNullOrEmpty(HttpContext.Session.GetString("data")))
                        trips = JsonConvert.DeserializeObject<List<Trip>>(HttpContext.Session.GetString("data"));
                    trips.Add(
                        new Trip()
                        {
                            Destination = HttpContext.Session.GetString("Destination"),
                            Accommodation = HttpContext.Session.GetString("Accommodation"),
                            AccommodationPhone = HttpContext.Session.GetString("AccommodationPhone"),
                            AccommodationEmail = HttpContext.Session.GetString("AccommodationEmail"),
                            StartDate = DateTime.Parse(HttpContext.Session.GetString("StartDate")),
                            EndDate = DateTime.Parse(HttpContext.Session.GetString("EndDate")),
                            ThingToDo1 = HttpContext.Session.GetString("ThingToDo1"),
                            ThingToDo2 = HttpContext.Session.GetString("ThingToDo2"),
                            ThingToDo3 = HttpContext.Session.GetString("ThingToDo3"),
                        }
                    );
                }
                HttpContext.Session.SetString("data", JsonConvert.SerializeObject(trips).ToString());
            }
            catch(Exception e) {

            }
            return View(trips);
        }
    }
}
