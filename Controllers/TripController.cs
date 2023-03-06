using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TripLog.Models;


namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        // private TripLogContext context { get; set; }

        // public TripController(TripLogContext ctx) => context = ctx;

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add(string id = "")
        {
            var vm = new TripViewModel();

            // HttpContext.Session.SetString(nameof(Trip.Destination), JsonConvert.SerializeObject(trips).ToString());
            if (id.ToLower() == "page2")
            {
                var accommodation = HttpContext.Session.GetString("Accommodation");

                if (string.IsNullOrEmpty(accommodation))
                {
                    vm.PageNumber = 3;
                    // var destination = TempData.Peek(nameof(Trip.Destination)).ToString();
                    
                    vm.Trip = new Trip { Destination = HttpContext.Session.GetString("Destination") };
                    return View("Add3", vm);
                }
                else
                {
                    vm.PageNumber = 2;
                    vm.Trip = new Trip { Accommodation = accommodation };
                    // TempData.Keep(nameof(Trip.Accommodation));
                    HttpContext.Session.SetString("Accommodation", accommodation);
                    return View("Add2", vm);
                }
            }
            else if (id.ToLower() == "page3")
            {
                vm.PageNumber = 3;
                vm.Trip = new Trip
                {
                    Destination = HttpContext.Session.GetString("Destination")
                };
                return View("Add3", vm);
            }
            else
            {
                vm.PageNumber = 1;
                return View("Add1", vm);
            }
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (ModelState.IsValid)
                {
                    // TempData[nameof(Trip.Destination)] = vm.Trip.Destination;
                    // TempData[nameof(Trip.Accommodation)] = vm.Trip.Accommodation;
                    // TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    // TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    HttpContext.Session.SetString("Destination", vm.Trip.Destination);
                    HttpContext.Session.SetString("Accommodation", vm.Trip.Accommodation);
                    HttpContext.Session.SetString("StartDate", vm.Trip.StartDate.ToString());
                    HttpContext.Session.SetString("EndDate", vm.Trip.EndDate.ToString());

                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                    return View("Add1", vm);
            }
            else if (vm.PageNumber == 2)
            {
                // TempData[nameof(Trip.AccommodationPhone)] = vm.Trip.AccommodationPhone;
                // TempData[nameof(Trip.AccommodationEmail)] = vm.Trip.AccommodationEmail;
                HttpContext.Session.SetString("AccommodationPhone", vm.Trip.AccommodationPhone);
                HttpContext.Session.SetString("AccommodationEmail", vm.Trip.AccommodationEmail);
                return RedirectToAction("Add", new { id = "Page3" });
            }
            else if (vm.PageNumber == 3)
            {
                // vm.Trip.Destination = TempData[nameof(Trip.Destination)].ToString();
                // vm.Trip.Accommodation = TempData[nameof(Trip.Accommodation)]?.ToString();
                // // vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)];
                // // vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)];
                // vm.Trip.AccommodationPhone = TempData[nameof(Trip.AccommodationPhone)]?.ToString();
                // vm.Trip.AccommodationEmail = TempData[nameof(Trip.AccommodationEmail)]?.ToString();


                // HttpContext.Session.GetString(
                vm.Trip.Destination = HttpContext.Session.GetString("Destination");
                vm.Trip.Accommodation = HttpContext.Session.GetString("Accommodation");
                vm.Trip.AccommodationPhone = HttpContext.Session.GetString("AccommodationPhone");
                vm.Trip.AccommodationEmail = HttpContext.Session.GetString("AccommodationEmail");

                // TempData["ThingToDo1"] = vm.Trip.ThingToDo1;
                // TempData["ThingToDo2"] = vm.Trip.ThingToDo2;
                // TempData["ThingToDo3"] = vm.Trip.ThingToDo3;
                HttpContext.Session.SetString("ThingToDo1", vm.Trip.ThingToDo1);
                HttpContext.Session.SetString("ThingToDo2", vm.Trip.ThingToDo2);
                HttpContext.Session.SetString("ThingToDo3", vm.Trip.ThingToDo3);

                TempData["message"] = $"Trip to {vm.Trip.Destination} added.";
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
