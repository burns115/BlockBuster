using System;
using BlockBuster;
using BlockBuster.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterTest
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieById(11);
            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }

        [Fact]
        public void GetAllMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 52);
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetMovieByGenreTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesOfGenre();
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void GetMoviesByDirLastName()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesByDirLastName();
            Assert.True(result.Count == 1);
        }

        [Fact]
        public void GetMovieByTitleTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieByTitle();
            Assert.True(result.Count == 1);
        }
    }

    
}
