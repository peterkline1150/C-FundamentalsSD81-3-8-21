using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPattern;
using System;
using System.Collections.Generic;

namespace StreamingContentRepositoryTest
{
    [TestClass]
    public class UnitTest1
    {
        //so we want to test The Add Method in the repo
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //AAA -> Arrange, Act, Assert

            //Arrange -> Overall setup
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();

            //Act -> Get/run the code to test
            bool addResult = repository.AddContentToDirectory(content);

            //Assert -> Used to get the expected outcome of a test
            Assert.IsTrue(addResult);
        }

        //Testing the Read Method
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //AAA RULES APPLY...

            //Arrange -> initial setup
            //Creating the content
            StreamingContent content = new StreamingContent();
            //Creating the repo
            StreamingContentRepository repo = new StreamingContentRepository();

            //Adding to the repo
            repo.AddContentToDirectory(content);

            //Act
            //Our plan is to store the list of streaming content in a variable
            List<StreamingContent> listOfMovies = repo.GetContent();

            bool directoryHasContent = listOfMovies.Contains(content);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        //we will start with private fields
        private StreamingContentRepository _repo;
        private StreamingContent _content;
        private StreamingContent _content2;

        //THIS IS THE ARRANGE PART...
        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();

            _content = new StreamingContent("Rubber", "A car tire comes to life with the power to make people explode", 
                                            5.8d, MaturityRating.R, GenreType.Drama);
            _content2 = new StreamingContent("Rubber-Duck", "A car tire comes to life with the power to make people explode",
                                            5.8d, MaturityRating.R, GenreType.Drama);

            //Now the movie is in our 'database' (list)
            _repo.AddContentToDirectory(_content);
            _repo.AddContentToDirectory(_content2);
        }

        //retrieve content by title
        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange... Already done above

            StreamingContent searchResult = _repo.GetContentByTitle("Rubber");
            StreamingContent theFailure = _repo.GetContentByTitle("Rubber-Duck");

            //Assertion
            Assert.AreEqual(_content, searchResult);
            Assert.AreEqual(_content2, theFailure);
        }

        //Test the update method
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange -> Updated version of our movie
            StreamingContent newContent = new StreamingContent("Rubber part 2", "A car tire comes to life with the power to make people explode",
                                                               9.8d, MaturityRating.R, GenreType.Drama);

            bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

            //Assert
            Assert.IsTrue(updateResult);
            //Console.WriteLine(GiveMeInfo(_content));
        }

        //    public string GiveMeInfo(StreamingContent content)
        //    {
        //        var result = $"{content.Title}\n" +
        //                        $"{content.StarRating}";
        //        return result;
        //    }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            StreamingContent content = _repo.GetContentByTitle("Rubber");

            bool removeResult = _repo.DeleteExistingContent(content);

            Assert.IsTrue(removeResult);
        }
    }
}
