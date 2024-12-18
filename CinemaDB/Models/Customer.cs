using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public int Phone {  get; set; }
        public string Email { get; set; }
        public int INN { get; set; }
        public int OGRNIP { get; set; }
        public int KPP {  get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public ICollection<Promo> Promos {  get; set; }

        public Customer()
        {
            Promos = new List<Promo>();
        }
    }
}
