using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;

namespace Tests
{
    public class AccountTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Test_ConnectSuccess()
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            Assert.Pass();
        }


        /// <summary>
        /// {
        ///    "username": "string",
        ///    "password": "string",
        ///    "email": "string",
        ///    "firstName": "string",
        ///    "lastName": "string",
        ///    "roles": [],
        ///    "claims": []
        ///    }
        /// </summary>
        [Test]
        public void Test_CreateAccountSuccess()
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var newAccount = new
            {
                username = "TanNguyen89",
                password = "@Tinhanh89",
                email = "tinhanh89@gmail.com"
            };

            var content = new StringContent(JsonConvert.SerializeObject(newAccount), Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:5000/Users", content).Result;
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.Content.ToString());
            Assert.Pass();
        }


        [Test]
        public void Test_LoginSuccess()
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;

            // request token
            var tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "bankingapiclient",
                UserName = "TanNguyen89",
                Password = "@Tinhanh89",
                Scope = "bankingapi"
            }).Result;


            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                Assert.Fail();
            }

            Console.WriteLine(tokenResponse.AccessToken.ToString());
            Assert.Pass();
        }


        [Test]
        public void Test_AccessAPI()
        {
            Assert.Pass();
        }
 
        [Test]
        public void Test_Logout()
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;

            // request token
            var tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "bankingapiclient",
                UserName = "TanNguyen89",
                Password = "@Tinhanh89",
                Scope = "bankingapi"
            }).Result;

            var logoutResponse = client.GetAsync($"{disco.EndSessionEndpoint}?id_token_hint={tokenResponse.AccessToken}").Result;
            logoutResponse.EnsureSuccessStatusCode();

            Assert.Pass();

        }


    }
}