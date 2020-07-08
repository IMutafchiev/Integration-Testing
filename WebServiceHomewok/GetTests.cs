using NUnit.Framework;
using RestSharp;
using System;
using WebServiceHomewok.Common;
using WebServiceHomewok.Models;

namespace WebServiceHomewok
{
    public class Tests
    {
        private RestClient _restClient;
        private Commons _commons;

        [SetUp]
        public void Setup()
        {

            _commons = new Commons();
            _restClient = new RestClient();
            _restClient.BaseUrl = new Uri("http://localhost:3000");
            _restClient.AddDefaultHeaders(_commons.Headers);
        }

        [Test]
        public void GetAllBooks()
        {
            var request = new RestRequest("/books");

            IRestResponse response = _restClient.Get(request);
            var books = Book.FromJson(response.Content);

            Assert.IsTrue(books.Count > 0);
        }

        [Test]
        public void GetBookById()
        {
            var request = new RestRequest("/books/2");

            IRestResponse response = _restClient.Get(request);
            Book book = Book.FromJsonBook(response.Content);

            Assert.AreEqual("Van Til's Apologetic", book.Title);
        }

        [Test]
        public void GetSearchedBook()
        {
            var request = new RestRequest("/books/search");

            _restClient.AddDefaultQueryParameter("author", "John");
            IRestResponse response = _restClient.Get(request);
            var books = Book.FromJson(response.Content);

            Assert.AreEqual("John Piper", books[0].Author);
        }

        [Test]
        public void GetAllUsers()
        {
            var request = new RestRequest("/users");

            IRestResponse response = _restClient.Get(request);
            var users = User.FromJson(response.Content);

            Assert.IsTrue(users.Count > 0);
        }

        [Test]
        public void GetUserById()
        {
            var request = new RestRequest("/users/2");

            IRestResponse response = _restClient.Get(request);
            var user = User.FromJsonUser(response.Content);

            Assert.AreEqual("Gosho", user.FirstName);
        }

        [Test]
        public void GetWishListBooks()
        {
            var request = new RestRequest("households/1/wishlistBooks");

            IRestResponse response = _restClient.Get(request);
            var wishListBooks = wishListBook.FromJson(response.Content);

            Assert.IsTrue(wishListBooks.Count > 0);
        }

    }
}