using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;
using System.Net;
using System.Threading.Tasks;

namespace APITests
{
    [TestClass]
    public class SmokeTests
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://reqres.in/";

        [ClassInitialize]
        public static void SetUpReport(TestContext testcontext)
        {
            var dir = testcontext.TestRunDirectory;
            Reporter.SetUpReport(dir, "SmokeTest", "Smoke test result");
        }

        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlusReport();
        }

        [TestMethod]
        public async Task GetListOfUsers()
        {
            var api = new Demo();
            var response = await api.GetUsers(BASE_URL);
            //Assert.AreEqual(2, response.page);
        }

        [DeploymentItem("TestData")]

        [TestMethod]
        public async Task CreatenewUserTest()
        {
            var payload = HandleContent.ParseJson<CreateUserRequest>("CreateUser.json");

            var api = new Demo();
            var response = await api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(201, code);
            Reporter.LogToReport(Status.Pass, "201 response code is received");

            var userContent = HandleContent.GetContent<CreateUserResponse>(response);
            Assert.AreEqual(payload.name, userContent.name);
        }
    }
}
