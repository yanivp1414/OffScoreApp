using System;
using System.Collections.Generic;
using System.Text;
using OffscoreApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace OffscoreApp.Services
{
    class OffscoreWebService
    {
        private HttpClient client;
        private static OffscoreWebService proxy = null;
        private const string BASE_URI = "http://10.0.2.2:28964";

        public static OffscoreWebService CreateProxy()
        {
            if (proxy == null)
                return new OffscoreWebService();
            return proxy;
        }
        public OffscoreWebService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            this.client = new HttpClient(handler, true);
        }

        public async Task<Account> LoginAsync(string email, string password)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/Login?email={email}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    Account c = JsonSerializer.Deserialize<Account>(content, options);
                    return c;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> SignupAsync(Account c)
        {
            try
            {
                string json = JsonSerializer.Serialize(c);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.client.PostAsync($"{BASE_URI}/api/SignUp", content);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string result = await response.Content.ReadAsStringAsync();
                    bool b = JsonSerializer.Deserialize<bool>(result);
                    return b;

                }
                else
                {
                    return false;
                }
             
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
