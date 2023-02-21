using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace APIAutomation.RestSharpBase
{
    class RestMethods
    {
        string baseURL = Constants.BASE_URL;

        public static RestResponse response;

        public async Task getApiUsers()
        {
            string url = baseURL + "/api/users?page=2";
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };

            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Get);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 200);
            Console.WriteLine(response.Content);
            var isValid = validateResponse(response);
            Assert.AreEqual(isValid, true);

        }

        public async Task getSingleUser()
        {
            string url = baseURL + "/api/users/" + Constants.USER_ID;

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Get);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 200);
            Console.WriteLine(response.Content);
        }

        public async Task createApiUser()
        {
            string url = baseURL + "/api/users";
            string username = Constants.USERNAME_CREATE;
            string jobtitle = Constants.JOBTITLE_CREATE;

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + @"""name"": " + '"' + username + '"'
                  + @", ""job"": " + '"' + jobtitle + '"' +
            "}";
            request.AddStringBody(body, DataFormat.Json);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 201);
            Console.WriteLine(response.Content);
        }

        public async Task updateUser()
        {
            string url = baseURL + "/api/users/2";
            string username = Constants.USERNAME_UPDATE;
            string jobtitle = Constants.JOBTITLE_UPDATE;

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + @"""name"": " + '"' + username + '"'
                  + @", ""job"": " + '"' + jobtitle + '"' +
            "}";
            request.AddStringBody(body, DataFormat.Json);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 201);
            Console.WriteLine(response.Content);
        }

        public async Task patchUser()
        {
            string url = baseURL + "/api/users/2";
            string username = Constants.USERNAME_PATCH;
            string jobtitle = Constants.JOBTITLE_PATCH;

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Patch);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + @"""name"": " + '"' + username + '"'
                  + @", ""job"": " + '"' + jobtitle + '"' +
            "}";
            request.AddStringBody(body, DataFormat.Json);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 200);
            Console.WriteLine(response.Content);
        }

        public async Task requestNotFound()
        {
            string url = baseURL + "/api/unknown/23";

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Get);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 404);
            Console.WriteLine("Expected = 404 || actual = " + numericStatusCode);
        }

            public async Task createInvalidUser()
        {
            string url = baseURL + "/api/users";
            string username = Constants.USERNAME_CREATE;
            string jobtitle = null;

            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + @"""name"": " + '"' + username + '"'
                  + @", ""job"": " + '"' + jobtitle + '"' +
            "}";
            request.AddStringBody(body, DataFormat.Json);
            response = await client.ExecuteAsync(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(numericStatusCode, 201);
            Console.WriteLine(response.Content);
        }

        public static Boolean validateResponse(RestResponse res){
            string fname = Constants.FIRSTNAME;
            string lname = Constants.LASTNAME;
            string content = res.Content.ToString();
            string text = "\"first_name\"" + ":" + "\""+fname+"\"" + "," + "\"last_name\"" + ":" + "\""+lname+"\"";
            Console.WriteLine(text);
            return content.Contains(text);
        }
    }
}
