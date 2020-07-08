using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using WebServiceHomewok.Common;
using WebServiceHomewok.Models;

namespace WebServiceHomewok
{
    [TestFixture]
    public class PostTests
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
        public void CreateBook()
        {
            var book = new Book() { Title = "Hello",
                Author = "hellios", 
                CreatedAt = DateTimeOffset.Now,
                Isbn = "dsasasd", 
                PublicationDate = DateTimeOffset.Now 
            };
            var request = new RestRequest("/books", Method.POST);
            request.AddParameter("application/json", book.ToJson(), ParameterType.RequestBody);

            IRestResponse response = _restClient.Post(request);

            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(book.Title, "Hello");
        }

        [Test]
        public void CreateUser()
        {
            var user = new User()
            {
                Email = "email@gmail.com",
                FirstName = "Ivan",
                LastName = "Ivanov",
                HouseholdId = 1,
                CreatedAt = DateTimeOffset.Now
            };
            var request = new RestRequest("/users", Method.POST);
            request.AddParameter("application/json", user.ToJson(), ParameterType.RequestBody);

            IRestResponse response = _restClient.Post(request);

            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(user.FirstName, "Ivan");
        }

        [Test]
        public void CreateHousehold()
        {
            var household = new Household()
            {
                Name = "new Household",
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
            var request = new RestRequest("/households", Method.POST);
            request.AddParameter("application/json", household.ToJson(), ParameterType.RequestBody);

            IRestResponse response = _restClient.Post(request);

            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(household.Name, "new Household");
        }
        
        [Test]
        public void AddBooksToWishlist()
        {
            var request = new RestRequest("/wishlists/6/books/5", Method.POST);

            IRestResponse response = _restClient.Post(request);

            Assert.IsTrue(response.IsSuccessful);
        }
    }
}
