using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using _8_1_TripLog.Models;
using Newtonsoft.Json;

namespace _8_1_TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }
        public HomeController(TripLogContext ctx) => context = ctx;

        public ViewResult Index() 
        {
            var trips = new List<Trip>();
            if(TempData.ContainsKey("Destination") && TempData.ContainsKey("data") && TempData["data"] != null) {
                trips = JsonConvert.DeserializeObject<List<Trip>>(TempData["data"].ToString());
                trips.Add(new Trip() {
                        Destination = (string) TempData["Destination"],
                        Accommodation = (string) TempData["Accommodation"],
                        StartDate = (DateTime) TempData["StartDate"],
                        EndDate = (DateTime)  TempData["EndDate"],
                        ThingToDo1 = (string)  TempData["ThingToDo1"],
                        ThingToDo2 = (string)  TempData["ThingToDo2"],
                        ThingToDo3 = (string)  TempData["ThingToDo3"]
                    });
            }
            else {
                trips.Add(
                    new Trip()
                    {
                        Destination = "New York",
                        Accommodation = "The ritz",
                        AccommodationPhone = "555-123-4567",
                        AccommodationEmail = "contact@theritz.com",
                        ThingToDo1 = "Go to a show",
                        ThingToDo2 = "Ride the subway",
                    }
                );
            }
            TempData["data"] = JsonConvert.SerializeObject(trips).ToString();
            TempData.Peek("data");
            return View(trips);
        }
    }
}

