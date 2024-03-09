using System;
using System.ComponentModel.DataAnnotations;
using BlockBuster;

namespace BlockBusterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = BlockBusterBasicFunctions.GetAllMoviesOfGenre();
            var oh = new OutputHelper();
            oh.WriteToConsole(b);
        }
    }
}