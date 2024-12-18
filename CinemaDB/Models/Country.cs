using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaDB.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public Country()
        {
            Movies = new List<Movie>();
        }
    }
}
