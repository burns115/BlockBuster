using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
        }

        public static List<Movie> GetAllMoviesOfGenre()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Genres,
                    m => m.GenreId,
                    g => g.GenreId,
                    (m, g) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        GenreDescr = g.GenreDescr
                    }).Where(w => w.GenreDescr == "Sci-Fi")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId
                    }).ToList();
            }
        }

        public static List<Movie> GetAllMoviesByDirLastName()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Directors,
                    m => m.DirectorId,
                    d => d.DirectorId,
                    (m, d) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        LastName = d.LastName
                    }).Where(w => w.LastName == "Ford")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId
                    }).ToList();
            }
        }

        public static List<Movie> GetMovieByTitle()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Where(w => w.Title == "Raging Bull")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId
                    }).ToList();
            }
        }
    }

}
