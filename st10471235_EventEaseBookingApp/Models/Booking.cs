
using System.ComponentModel.DataAnnotations;
namespace st10471235_EventEaseBookingApp.Models

{
    public class Booking
    {
        public int BookingId { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}