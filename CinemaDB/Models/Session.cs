using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CinemaDB.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public decimal BasePrice { get; set; }

        public int MovieId { get; set; }
        public Movie Movie  { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Promo> Promos { get; set; }

        public Session()
        {
            Tickets = new List<Ticket>();
            Promos = new List<Promo>();
        }
    }
}
