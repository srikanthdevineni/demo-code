using Common.Contracts;
using Common.Models;
using Common.Persistence;
using NUnit.Framework;
using Records.API.Controllers;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace Records.API.Tests.Controllers
{
    [TestFixture]
    public class RecordsControllerTests
    {
        private HttpRequestMessage _request;
        private RecordsController _controller;
        private IDataStore _mockDataStore;

        [OneTimeSetUp]
        public void init()
        {
            _request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };
            _controller = new RecordsController
            {
                Request = _request
            };
            MockRepository repo = new MockRepository();
            _mockDataStore = repo.Stub<IDataStore>();
            SetupResult.For(_mockDataStore.GetRecords()).Return(
                new List<RecordDetail>{
                    new RecordDetail
            {
                DateOfBirth = new DateTime(2000, 1, 1),
                FavColor = "Black",
                Gender = "Male",
                FirstName = "test",
                LastName = "testL"
            },new RecordDetail
            {
                DateOfBirth = new DateTime(2001, 1, 1),
                FavColor = "Blue",
                Gender = "Female",
                FirstName = "test",
                LastName = "lasttest"
            }
                }
                );
        }

        [Test]
        public void CheckNullPost()
        {


            var message = _controller.Post(null);
            Assert.AreEqual(HttpStatusCode.BadRequest, message.StatusCode);
        }

        [Test]
        public void CheckEmptyPost()
        {
            var message = _controller.Post(new InputRequest { inputLine = string.Empty });
            Assert.AreEqual(HttpStatusCode.BadRequest, message.StatusCode);
        }

        [Test]
        public void ValidPost()
        {
            var message = _controller.Post(new InputRequest { inputLine = "test" });
            Assert.AreEqual("test", message.Content.ReadAsAsync<RecordDetail>().Result.LastName);
        }

        [Test]
        public void GetByGenderSort()
        {

            var data = _controller.GetSortedByGender().Select(r => r.Gender);
            CollectionAssert.IsOrdered(data);
        }

        [Test]
        public void GetByBirthdaySort()
        {

            var data = _controller.GetSortedByBirthDate().Select(r => r.DateOfBirth);
            CollectionAssert.IsOrdered(data);
        }


        [Test]
        public void GetByLastNameSort()
        {

            var data = _controller.GetSortedByLastName().Select(r => r.LastName);
            CollectionAssert.IsOrdered(data);
        }


    }
}
