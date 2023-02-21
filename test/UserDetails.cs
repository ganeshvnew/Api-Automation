using NUnit.Framework;
using System.Threading.Tasks;
using APIAutomation.RestSharpBase;
using ApiAutomation.Test;

namespace APIAutomation.Test
{
    [TestFixture]
    class UserDetails : BaseTest
    {
        RestMethods rest = new RestMethods();

        [Test]
        [Description("Get all user details")]
        [Author("Ganesh")]
        [Category("GET")]

        public async Task GetAllUsers()
        {
            await rest.getApiUsers();
        }

        [Test]
        [Description("Get one specific user details")]
        [Author("Ganesh")]
        [Category("GET")]
        public async Task GetUser()
        {
             await rest.getSingleUser();
        }

        [Test]
        [Description("Create a new user")]
        [Author("Ganesh")]
        [Category("POST")]
        public async Task CreateUser()
        {
            await rest.createApiUser();

        }
        [Test]
        [Description("Update an existing user")]
        [Author("Ganesh")]
        [Category("PUT")]
        public async Task UpdateUser()
        {
            await rest.updateUser();
        }

        [Test]
        [Description("Patch an existing user")]
        [Author("Ganesh")]
        [Category("PATCH")]
        public async Task UpdatePatchUser()
        {
            await rest.patchUser();
        }

        [Test]
        [Description("Negative scenario - 404")]
        [Author("Ganesh")]
        [Category("GET")]
        public async Task NegativeScenario()
        {
            await rest.requestNotFound();
        }
    }
}