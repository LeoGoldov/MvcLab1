using System.Collections.Generic;
using MvcLab1.Models;

namespace MvcLab1.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetByGenre(string genre);
        IEnumerable<Movie> GetByYearRange(int startYear, int endYear);
        IEnumerable<Movie> GetHighRated(decimal minRating);
    }
}