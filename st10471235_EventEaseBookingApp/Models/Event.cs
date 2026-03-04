using System.ComponentModel.DataAnnotations;

namespace st10471235_EventEaseBookingApp.Models

{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}