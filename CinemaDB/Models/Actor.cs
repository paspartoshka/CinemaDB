using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace CinemaDB.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public Actor()
        {
            Movies = new List<Movie>();
        }
    }
}
