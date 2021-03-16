using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class Movie : StreamingContent
    {
        //we get all of the properties from streaming content b/c movie inherits the properties from the StreamingContent class
        public double RunTime { get; set; }

        public Movie(){}

        public Movie(string title, string description, double starRating, MaturityRating maturityRating, GenreType genreType, double runTime)
                    :base(title, description, starRating, maturityRating, genreType)
        {
            RunTime = runTime;
        }
    }
}
