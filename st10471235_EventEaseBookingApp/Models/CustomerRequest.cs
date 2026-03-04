
using System.ComponentModel.DataAnnotations;

namespace st10471235_EventEaseBookingApp.Models
{
    public class CustomerRequest
    {
        public int CustomerRequestId { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        public string? CustomerEmail { get; set; }

        public string? CustomerPhone { get; set; }

        public int? VenueId { get; set; }
        public Venue? Venue { get; set; }

        public DateTime RequestedStart { get; set; }

        public DateTime RequestedEnd { get; set; }

        [Required]
        public string RequestedEventName { get; set; } = string.Empty;

        public string Status { get; set; } = "New";

        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}