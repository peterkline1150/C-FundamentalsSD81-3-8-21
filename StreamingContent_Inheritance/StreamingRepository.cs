using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class StreamingRepository : StreamingContentRepository
    {
        //Read
        public Show GetShowByTitle(string title)
        {
            //To find a specific show
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.Title.ToLower()==title.ToLower() && content.GetType()==typeof(Show))
                {
                    return (Show)content;
                }
            }
            return null;
        }

        //Read
        public Movie GetMovieByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.Title.ToLower()==title.ToLower() && content.GetType()==typeof(Movie))
                {
                    return (Movie)content;
                }
            }
            return null;
        }

        //Read
        public List<Show> GetAllShows()
        {
            //Use this to add our shows
            List<Show> allShows = new List<Show>();

            foreach(StreamingContent content in _contentDirectory)
            {
                //if the content that we find is of type Show...
                if(content.GetType()==typeof(Show))  //Can also say if(content is Show)
                {
                    //add the show to the list of all shows
                    allShows.Add((Show)content);
                }
            }
            return allShows;
        }

        //Read
        public List<Movie> GetAllMovies()
        {
            List<Movie> allMovies = new List<Movie>();

            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Movie)
                {
                    allMovies.Add(content as Movie);
                }
            }
            return allMovies;
        }

        //Get by RunTime/AveragRunTime
        //Get Shows with over x episodes
        //Get Shows/Movie By Rating

        public List<Movie> GetMoviesByRunTime(double runTime)
        {
            List<Movie> moviesByRunTime = new List<Movie>();
            List<Movie> allMovies = GetAllMovies();

            foreach (Movie content in allMovies)
            {
                if (content.RunTime == runTime)
                {
                    moviesByRunTime.Add(content);
                }
            }
            return moviesByRunTime;
        }

        public List<Show> GetShowsByAverageRunTime(double averageRunTime)
        {
            List<Show> showsByAverageRunTime = new List<Movie>();
            List<Show> allShows = GetAllShows();

            foreach (Show content in allShows)
            {
                if (content.AverageRunTime == averageRunTime)
                {
                    showsByAverageRunTime.Add(content);
                }
            }
            return showsByAverageRunTime;
        }
    }
}
