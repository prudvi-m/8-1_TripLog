using _8_1_TripLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using _8_1_TripLog.Models;
using System;
namespace _8_1_TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }
        public HomeController(TripLogContext ctx) => context = ctx;

        public ViewResult Index() 
        {
            // var trips = context.Trips.OrderBy(t => t.StartDate).ToList();

            var trips = new List<Trip>();
        };



        if(TempData.ContainsKey("Destination")) {
            trips.Add(new Trip() {
                Destination = (string) TempData["Destination"],
                Accommodation = (string) TempData["Accommodation"],
                StartDate = (DateTime) TempData["StartDate"],
                EndDate = (DateTime)  TempData["EndDate"]
            });
        }
        else {
            trip.Add(new Trip(

                new Trip() {
                    Destination = "New York",
                    Accommodation = "The ritz",
                    AccommodationPhone = "555-123-4567",
                    AccommodationEmail = "contact@theritz.com",
                    ThingToDo1 = "Go to a show",
                    ThingToDo2 = "Ride the subway",
                }

            ))
        }

            return View(trips);
        }
    }
}
