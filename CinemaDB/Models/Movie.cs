using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Cache;
using System.Reflection;

namespace CinemaDB.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int LicPrice { get; set; }
        public int DaysIn { get; set; }
        public int AgeLimit { get; set; }
        public int Rating { get; set; }
        public int ReleaseYear { get; set; }


        public int CompanyId { get; set; }
        public Company Company { get; set; }


        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Country> Countries { get; set; }

        public string PosterFileName { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
            Genres = new List<Genre>();
            Countries = new List<Country>();
        }
    }
}
