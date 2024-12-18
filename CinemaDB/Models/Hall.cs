using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaDB.Models
{
    public class Hall
    {
        public int HallId { get; set; }

        public int HallNumber { get; set; }
        public string HallType { get; set; }
        public int RowCount { get; set; }
        public int SeatCount { get; set; }
        public string ProjType { get; set; }
        public decimal PriceMult { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public Hall()
        {
            Sessions = new List<Session>();
        }
    }
}
