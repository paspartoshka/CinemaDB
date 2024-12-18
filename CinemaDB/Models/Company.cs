using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaDB.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public Company()
        {
            Movies = new List<Movie>();
        }
    }
}
