using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using WebServiceHomewok.Common;
using WebServiceHomewok.Models;

namespace WebServiceHomewok
{
    [TestFixture]
    public class CollectionTests
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
        [Order(1)]
        public void CreateHousehold()
        {
            var household = new Household()
            {
                Name = $"base household",
                CreatedAt = DateTimeOffset.Now,
                Id = 10
            };
            var request = new RestRequest("/households", Method.POST);
            request.AddParameter("application/json", household.ToJson(), ParameterType.RequestBody);

            IRestResponse response = _restClient.Post(request);


            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(household.Name, $"base household");
        }

        [Test]
        [Order(2)]
        public void AddTwoDifferentUsers()
        {

            for (int i = 0; i < 2; i++)
            {
                var user = new User()
                {
                    Email = $"someoneemail{i}@gmail.com",
                    FirstName = $"Genadi{i}",
                    LastName = $"Stamatov{i}",
                    HouseholdId = 10,
                    CreatedAt = DateTimeOffset.Now,
                    WishlistId = 18 + i
                };
                var request = new RestRequest("/users", Method.POST);
                request.AddParameter("application/json", user.ToJson(), ParameterType.RequestBody);

                IRestResponse response = _restClient.Post(request);
                

                Assert.IsTrue(response.IsSuccessful);
                Assert.AreEqual(user.FirstName, $"Genadi{i}");
            }

        }

        [Test]
        [Order(3)]
        public void AddTwoBooksToEachUser()
        {
            for (int userId = 0; userId < 2; userId++)
            {

                    for (int i = 1; i < 3; i++)
                    {

                        var request = new RestRequest($"/wishlists/{18 + userId}/books/{userId + i}", Method.POST);


                        IRestResponse response = _restClient.Post(request);

                        Assert.IsTrue(response.IsSuccessful);
                    }

            }
        }

        [Test]
        [Order(4)]
        public void GetAWishListForCreatedHousehold()
        {
            var request = new RestRequest($"households/{10}/wishlistBooks");

            IRestResponse response = _restClient.Get(request);
            var wishListBooks = wishListBook.FromJson(response.Content);

            Assert.IsTrue(wishListBooks.Count > 0);
        }
    }
}
