using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new List<Movie>();
        }

    }
}
