using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class StreamingContentRepository
    {
        protected readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        //Create
        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<StreamingContent> GetContent()
        {
            return _contentDirectory;
        }

        //Get Content by other properties
        //Read -> helper method b/c used throughout this repo
        public StreamingContent GetContentByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public StreamingContent GetContentByDescription(string description)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.Description.ToLower() == description.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public List<StreamingContent> GetContentByStarRating(double starRating)
        {
            List<StreamingContent> _contentByStarRating = new List<StreamingContent>();

            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.StarRating == starRating)
                {
                    _contentByStarRating.Add(content);
                }
            }
            return _contentByStarRating;
        }

        public List<StreamingContent> GetContentByMaturityRating(MaturityRating maturityRating)
        {
            List<StreamingContent> _contentByMaturity = new List<StreamingContent>();

            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.MaturityRating == maturityRating)
                {
                    _contentByMaturity.Add(content);
                }
            }
            return _contentByMaturity;
        }

        public List<StreamingContent> GetContentByGenreType(GenreType genreType)
        {
            List<StreamingContent> _contentByGenre = new List<StreamingContent>();

            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.GenreType == genreType)
                {
                    _contentByGenre.Add(content);
                }
            }
            return _contentByGenre;
        }

        public List<StreamingContent> GetContentByIsFamilyFriendly(bool isFamilyFriendly)
        {
            List<StreamingContent> _contentByFamilyFriendly = new List<StreamingContent>();

            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.IsFamilyFriendly == isFamilyFriendly)
                {
                    _contentByFamilyFriendly.Add(content);
                }
            }
            return _contentByFamilyFriendly;
        }

        //Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);

            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.StarRating = newContent.StarRating;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.GenreType = newContent.GenreType;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
