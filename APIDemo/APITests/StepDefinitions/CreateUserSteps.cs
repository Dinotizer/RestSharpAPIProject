using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITests
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserRequest createUserReq;
        private RestResponse response;

        public CreateUserSteps(CreateUserRequest createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.name = name;
        }

        [Given(@"I input job ""([^""]*)""")]
        public void GivenIInputJob(string job)
        {
            createUserReq.job = job;
        }

        [When(@"I send request to create user")]
        public async Task WhenISendRequestToCreateUser()
        {
            var api = new Demo();
            response = await api.CreateNewUser(BASE_URL, createUserReq);
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUserResponse>(response);
            Assert.AreEqual(createUserReq.name, content.name);
            Assert.AreEqual(createUserReq.job, content.job);
        }
    }
}
