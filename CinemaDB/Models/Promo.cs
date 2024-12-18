using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Promo
    {
        public int PromoId { get; set; }
        public int Length { get; set; }
        public string Type {  get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Session> Sessions {  get; set; }

        public Promo()
        {
            Sessions = new List<Session>();
        }
    }
}
