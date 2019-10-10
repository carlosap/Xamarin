using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NewsApp.Models;
using NewsApp.ViewModels;

namespace UnitTest.NewsApp
{
    [TestClass]
    public class HeadLinesTests
    {
        public HeadLinesTests()
        {
            // Xamarin Init() Mock and Dependency Inject
            MockForms.Init();
        }

        [TestMethod]
        public void TestArticlesByNetwork()
        {
            //Init 
            var _cnnHeadLines = new HeadLine {Title = "CNN"};
            var _cnbcHeadLines = new HeadLine { Title = "CNBC" };


            //Arrange
            var _cnnviewModel = new HeadlinesViewModel(_cnnHeadLines);
            var _cnbcviewModel = new HeadlinesViewModel(_cnbcHeadLines);


            //Act
            _cnnviewModel.LoadArticlesCommand.Execute(null);
            _cnbcviewModel.LoadArticlesCommand.Execute(null);


            //Assert
            _cnnviewModel.Title.Should().Be("CNN News", "Because Title is being concatenated with News string");
            _cnnviewModel.Articles.Count.Should().Be(5, "CNN Network has a collection of 5 Articles");

            _cnbcviewModel.Title.Should().Be("CNBC News", "Because Title is being concatenated with News string");
            _cnbcviewModel.Articles.Count.Should().Be(4, "CNN Network has a collection of 4 Articles");
        }
    }
}
