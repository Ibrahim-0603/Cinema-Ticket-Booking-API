using System.Collections.Generic;

namespace CinemaTicketBookingApi.Api.Models
{
    public class Auditorium
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
        public virtual IEnumerable<Show> Shows { get; set; } = new List<Show>();
    }
}
