using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterConsole
{
    class OutputHelper
    {
        public void WriteToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies");
            foreach(var m in movies)
            {
                Console.WriteLine($"MovieID: {m.MovieId}    Title: {m.Title}    Release Year: {m.ReleaseYear}");
            }
        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }
    }
}
