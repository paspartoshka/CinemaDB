using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Cache;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CinemaDB.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Название фильма обязательно")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Длительность фильма обязательна")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Цена лицензии обязательна")]
        public int LicPrice { get; set; }
        [Required(ErrorMessage = "Количество дней в прокате обязательно")]
        public int DaysIn { get; set; }
        [Required(ErrorMessage = "Возрастное ограничение обязательно")]
        [Range(0, 18, ErrorMessage = "Возрастное ограничение должно быть от 0 до 18")]
        public int AgeLimit { get; set; }
        [Required(ErrorMessage = "Рейтинг обязателен")]
        [Range(0,10, ErrorMessage = "Рейтинг должен быть от 0 до 10")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Год выпуска обзателен")]
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
