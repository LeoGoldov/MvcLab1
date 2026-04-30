using MvcLab1.Data;
using MvcLab1.Models;

namespace MvcLab1.Repositories;

public class EfMovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public EfMovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies.ToList();
    }

    public Movie? GetById(int id)
    {
        return _context.Movies.Find(id);
    }

    public void Add(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void Update(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var movie = GetById(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Movie> GetByGenre(string genre)
    {
        return _context.Movies
            .Where(m => m.Genre == genre)
            .ToList();
    }

    public IEnumerable<Movie> GetByYearRange(int startYear, int endYear)
    {
        return _context.Movies
            .Where(m => m.Year >= startYear && m.Year <= endYear)
            .ToList();
    }

    public IEnumerable<Movie> GetHighRated(decimal minRating)
    {
        
        return _context.Movies.ToList();
    }
}