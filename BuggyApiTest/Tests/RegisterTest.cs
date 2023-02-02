using BuggyApiTest.Support;
using BuggyApiTest.Drivers;
using BuggyApiTest.TestData;
using NUnit.Framework;
using RestSharp;

namespace BuggyApiTest.Tests
{
    [TestFixture]
    public class RegisterTests
    {

        private ConfigurationDriver configurationDriver;
        private string registerUrl;
        private const string DataFile = "user.json";

        [SetUp]
        public void Setup()
        {
            configurationDriver = new ConfigurationDriver();
            registerUrl = configurationDriver.BaseUrl + configurationDriver.RegisterPath;
        }

        [Test]
        [TestCaseSource(typeof(RegisterTestData), nameof(RegisterTestData.RegisterData))]
        public void TestRegisterSuccess(string userName, string firstName,
            string lastName, string password,
            System.Net.HttpStatusCode statusCode, string message)
        {

            RestResponse response = RequestCommon.Post(registerUrl,
                RegisterTestData.setUserData(DataFile, userName, firstName, lastName, password));

            Assert.AreEqual(response.StatusCode, statusCode);
            Assert.AreEqual(JsonCommon.getString(response.Content.ToString(), "message"), message);

        }

        
    }
}
