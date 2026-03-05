
using System.ComponentModel.DataAnnotations;
namespace st10471235_EventEaseBookingApp.Models

{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(1, 100000)]
        public int Capacity { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<CustomerRequest>? CustomerRequests { get; set; }
    }
}