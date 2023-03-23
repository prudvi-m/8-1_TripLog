using System;
using System.ComponentModel.DataAnnotations;

namespace TripLog.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required(ErrorMessage = "Please enter a Destination")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", 
        ErrorMessage = "Special characters & numbers are not allowed & only 30 characters length were accepted.")]
        public string Destination { get; set; }

        // [Required(ErrorMessage = "Please ÷enter the date your trip starts.")]
        public DateTime? StartDate { get; set; }

        // [Required(ErrorMessage = "Please enter the date your trip ends.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter a Accommodation")]
        [RegularExpression(@"^[a-zA-Z1-9''-'\s]{1,50}$", 
        ErrorMessage = "Special characters are not allowed & only 50 characters length were accepted.")]
        public string Accommodation { get; set; }

        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }

        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
