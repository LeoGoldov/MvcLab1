using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab1.Models;

namespace MvcLab1.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;
        private int _nextId = 1;

        public InMemoryMovieRepository()
        {
            _movies = new List<Movie>();
            SeedData();
        }

        private void SeedData()
        {
            // Добавляем тестовые данные (минимум 3 записи)
            Add(new Movie
            {
                Title = "Побег из Шоушенка",
                Director = "Фрэнк Дарабонт",
                Year = 1994,
                Genre = "Драма",
                Duration = 142,
                Rating = 9.3m,
                IsAvailable = true
            });

            Add(new Movie
            {
                Title = "Крестный отец",
                Director = "Фрэнсис Форд Коппола",
                Year = 1972,
                Genre = "Криминал",
                Duration = 175,
                Rating = 9.2m,
                IsAvailable = true
            });

            Add(new Movie
            {
                Title = "Темный рыцарь",
                Director = "Кристофер Нолан",
                Year = 2008,
                Genre = "Боевик",
                Duration = 152,
                Rating = 9.0m,
                IsAvailable = true
            });

            Add(new Movie
            {
                Title = "Криминальное чтиво",
                Director = "Квентин Тарантино",
                Year = 1994,
                Genre = "Криминал",
                Duration = 154,
                Rating = 8.9m,
                IsAvailable = true
            });

            Add(new Movie
            {
                Title = "Властелин колец: Возвращение короля",
                Director = "Питер Джексон",
                Year = 2003,
                Genre = "Фэнтези",
                Duration = 201,
                Rating = 9.0m,
                IsAvailable = true
            });
        }

        public IEnumerable<Movie> GetAll() => _movies.ToList();

        public Movie? GetById(int id) => _movies.FirstOrDefault(m => m.Id == id);

        public void Add(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            movie.Id = _nextId++;
            _movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var existing = GetById(movie.Id);
            if (existing != null)
            {
                existing.Title = movie.Title;
                existing.Director = movie.Director;
                existing.Year = movie.Year;
                existing.Genre = movie.Genre;
                existing.Duration = movie.Duration;
                existing.Rating = movie.Rating;
                existing.IsAvailable = movie.IsAvailable;
            }
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
                _movies.Remove(movie);
        }

        public IEnumerable<Movie> GetByGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre))
                return Enumerable.Empty<Movie>();

            return _movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Movie> GetByYearRange(int startYear, int endYear)
        {
            return _movies.Where(m => m.Year >= startYear && m.Year <= endYear);
        }

        public IEnumerable<Movie> GetHighRated(decimal minRating)
        {
            return _movies.Where(m => m.Rating >= minRating).OrderByDescending(m => m.Rating);
        }
    }
}