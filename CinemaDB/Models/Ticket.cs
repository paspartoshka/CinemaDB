using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public decimal Price { get; set; }
        public int RowNumb {  get; set; }
        public int SeatNumb { get; set; }
        public bool isSold { get; set; }


        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
