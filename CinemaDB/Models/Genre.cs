using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new List<Movie>();
        }
    }
}
