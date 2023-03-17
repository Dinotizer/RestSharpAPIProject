using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpDemo;
using RestSharpDemo.Models;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITests.StepDefinitions
{
    [Binding]
    public class GetUserListSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly Users users;
        private RestResponse response;

        public GetUserListSteps(Users users)
        {
            this.users = users;
        }

        [Given(@"I send a Get request to the List Users API")]
        public async Task GivenISendAGetRequestToTheListUsersAPI()
        {
            var api = new Demo();
            response = await api.GetUsers(BASE_URL, users);
        }

        [Then(@"the API returns requested user details")]
        public void ThenTheAPIReturnsRequestedUserDetails()
        {
            var content = HandleContent.GetContent<Users>(response);
            Assert.AreEqual(2, content.page);
        }
    }
}
