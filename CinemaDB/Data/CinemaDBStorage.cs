using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public class CinemaDBStorage
    {
        private readonly CinemaDBContext _context;

        public CinemaDBStorage(CinemaDBContext cinemaContext)
        {
            _context = cinemaContext;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            Console.WriteLine("Movie added");
        }
        public Movie? GetMovie(int id)
        {
            Movie? movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            return movie;
        }
        public List<Movie> GetMovies(string Name)
        {
            var movie = _context.Movies.Where(x => x.Title == Name).ToList();
            return movie;
        }
        public void RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        public void RemoveMovie(string movieTitle)
        {

            _context.Movies.RemoveRange(GetMovies(movieTitle));
            _context.SaveChanges();
        }

    }
}
