using CinemaDB.Data;
using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Numerics;

namespace CinemaDB
{
    internal class Program
    {

        static void Main(string[] args)
        {

            using (var context = new CinemaDBContext())
            {
                while (true)
                {
                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("1. Добавить фильм");
                    Console.WriteLine("2. Показать все фильмы");
                    Console.WriteLine("3. Обновить фильм");
                    Console.WriteLine("4. Удалить фильм");
                    Console.WriteLine("5. Выйти");
                    Console.Write("Введите номер операции: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddMovie(context);
                            break;
                        case "2":
                            ShowAllMovies(context);
                            break;
                        case "3":
                            UpdateMovie(context);
                            break;
                        case "4":
                            DeleteMovie(context);
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
        }

        static void AddMovie(CinemaDBContext context)
        {
            Console.Write("Введите название компании: ");
            var companyName = Console.ReadLine();


            var company = context.Companies.FirstOrDefault(c => c.Name == companyName);

            while (company == null)
            {
                Console.WriteLine("Компания не найдена, повторить ввод Y, дополнить информацию N: ");
                var choiceCompany = Console.ReadLine();
                if (choiceCompany == "Y")
                {
                    Console.Write("Введите название компании: ");
                    companyName = Console.ReadLine();
                    company = context.Companies.FirstOrDefault(c => c.Name == companyName);
                }
                else if (choiceCompany == "N")
                {
                    Console.WriteLine("Введите год основания компании: ");
                    int companyyear = int.Parse(Console.ReadLine());
                    company = new Company { Name = companyName, Year = companyyear };
                    context.Companies.Add(company);
                    context.SaveChanges();
                    Console.WriteLine("Компания добавлена.");
                }
            }

            Console.Write("Введите фамилию режиссёра: ");
            var directorSurname = Console.ReadLine();

            var director = context.Directors.FirstOrDefault(d => d.Person.Surname == directorSurname);


            while (director == null)
            {
                Console.WriteLine("Режиссёр не найден, повторить ввод Y, дополнить информацию N: ");
                var choiceDirector = Console.ReadLine();
                if (choiceDirector == "Y")
                {
                    Console.Write("Введите фамилию режиссёра: ");
                    directorSurname = Console.ReadLine();
                    director = context.Directors.FirstOrDefault(d => d.Person.Surname == directorSurname);
                }
                else if (choiceDirector == "N")
                {
                    Console.WriteLine("Введите имя режиссёра: ");
                    var directorname = Console.ReadLine();
                    var person = new Person { Name = directorname, Surname = directorSurname, Job = "Director" };
                    context.Persons.Add(person);
                    context.SaveChanges();
                    director = new Director { PersonId = person.PersonId };
                    context.Directors.Add(director);
                    context.SaveChanges();
                    Console.WriteLine("Режиссёр добавлен.");
                }
            }

            Console.Write("Введите название фильма: ");
            var title = Console.ReadLine();
            Console.Write("Введите длительность фильма (в минутах): ");
            var length = int.Parse(Console.ReadLine());
            Console.Write("Введите год выпуска: ");
            var year = int.Parse(Console.ReadLine());

            var movie = new Movie
            {
                Title = title,
                Length = length,
                ReleaseYear = year,
                CompanyId = company.CompanyId,
                DirectorId = director.DirectorId
            };
            while (true)
            {
                Console.Write("Введите страну для фильма (или 'exit' для завершения): ");
                var countryName = Console.ReadLine();
                if (countryName.ToLower() == "exit")
                {
                    break;
                }

                var country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                if (country == null)
                {
                    Console.WriteLine("Страна не найдена. Добавить новую страну? (Y/N)");
                    var addCountryChoice = Console.ReadLine();
                    if (addCountryChoice.ToUpper() == "Y")
                    {
                        Console.Write("Введите название страны: ");
                        countryName = Console.ReadLine();
                        country = new Country { Name = countryName };
                        context.Countries.Add(country);
                        context.SaveChanges();
                    }
                }

                if (country != null)
                {
                    movie.Countries.Add(country);
                }
            }

            context.Movies.Add(movie);
            context.SaveChanges();
            Console.WriteLine("Фильм добавлен.");
        }

        static void ShowAllMovies(CinemaDBContext context)
        {
            var movies = context.Movies.ToList();
            Console.WriteLine("Список всех фильмов:");
            foreach (var movie in movies)
            {
                var countryNames = movie.Countries != null ? string.Join(", ", movie.Countries.Select(c => c.Name)) : "Нет стран";
                Console.WriteLine($"ID: {movie.MovieId}, Название: {movie.Title}, Длительность: {movie.Length} минут, Режиссёр: {movie.Director.Person.Surname}, Страны: {countryNames}");
            }
        }

        static void UpdateMovie(CinemaDBContext context)
        {
            Console.Write("Введите ID фильма для обновления: ");
            var movieId = int.Parse(Console.ReadLine());

            var movie = context.Movies.Find(movieId);
            if (movie != null)
            {
                Console.Write("Введите новое название фильма: ");
                movie.Title = Console.ReadLine();
                Console.Write("Введите новую длительность фильма: ");
                movie.Length = int.Parse(Console.ReadLine());
                movie.Countries.Clear(); 

                while (true)
                {
                    Console.Write("Введите страну для фильма (или 'exit' для завершения): ");
                    var countryName = Console.ReadLine();
                    if (countryName.ToLower() == "exit")
                    {
                        break;
                    }

                    var country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                    if (country == null)
                    {
                        Console.WriteLine("Страна не найдена. Добавить новую страну? (Y/N)");
                        var addCountryChoice = Console.ReadLine();
                        if (addCountryChoice.ToUpper() == "Y")
                        {
                            Console.Write("Введите название страны: ");
                            countryName = Console.ReadLine();
                            country = new Country { Name = countryName };
                            context.Countries.Add(country);
                            context.SaveChanges();
                        }
                    }

                    if (country != null)
                    {
                        movie.Countries.Add(country);
                    }
                }

                context.SaveChanges();
                Console.WriteLine("Фильм обновлен.");
            }
            else
            {
                Console.WriteLine("Фильм не найден.");
            }
        }

        static void DeleteMovie(CinemaDBContext context)
        {
            Console.Write("Введите ID фильма для удаления: ");
            var movieId = int.Parse(Console.ReadLine());

            var movie = context.Movies.Include(m => m.Countries).FirstOrDefault(m => m.MovieId == movieId);
            if (movie != null)
            {
                movie.Countries.Clear();
                context.Movies.Remove(movie);
                context.SaveChanges();
                Console.WriteLine("Фильм удален.");
            }
            else
            {
                Console.WriteLine("Фильм не найден.");
            }
        }
    }
}
