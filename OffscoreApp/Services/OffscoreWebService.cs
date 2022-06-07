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

        public async Task<Account> UpdateAsync(string name, DateTime birthday, string password, string id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/Update?name={name}&birthday={birthday}&pass={password}&id={id}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    Account b = JsonSerializer.Deserialize<Account>(content, options);
                    return b;
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
        public async Task<List<GameGuesses>> GetGuesses(List<Game> games, int userId)
        {
            try
            {
                List<string> idsList = new List<string>();
                string ids = "";
                foreach (Game game in games)
                {
                    idsList.Add(game.GameId.ToString());
                }
                ids = String.Join("_", idsList);

                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetGuesses?ids={ids}&UserId={userId}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<GameGuesses> b = JsonSerializer.Deserialize<List<GameGuesses>>(content, options);
                    return b;
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

        public async Task<List<Game>> GetActiveGames()
        {
            try
            {
               
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetActiveGames");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Game> b = JsonSerializer.Deserialize<List<Game>>(content, options);
                    return b;
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
        public async void Logout()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/Logout");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task<List<League>> GetLeagues()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetLeagues");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<League> b = JsonSerializer.Deserialize<List<League>>(content, options);
                    return b;
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
        public async Task<List<Guess>> GetPreviousDays(int numberOfDays, int accountId)
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetPreviousDays?NumberOfDays={numberOfDays}&Id={accountId}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Guess> b = JsonSerializer.Deserialize<List<Guess>>(content, options);
                    return b;
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

        public async Task<List<Team>> GetTeams()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetTeams");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Team> b = JsonSerializer.Deserialize<List<Team>>(content, options);
                    return b;
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
        public async Task<List<Game>> GetGamesByIds(List<int> ids)
        {
            try
            {
                string list = JsonSerializer.Serialize(ids);
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetGamesByIds?ids={list}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Game> b = JsonSerializer.Deserialize<List<Game>>(content, options);
                    return b;
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
        public async Task<Game> GetGamesById(int id)
        {
            try
            {
                
                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetGameById?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    Game b = JsonSerializer.Deserialize<Game>(content, options);
                    return b;
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

        public async Task<List<Account>> GetLeaderboard()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{BASE_URI}/api/GetLeaderboard");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Account> b = JsonSerializer.Deserialize<List<Account>>(content, options);
                    return b;
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

        public async Task<bool> AddGuess(Guess g)
        {
            try
            {
                string json = JsonSerializer.Serialize(g);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.client.PostAsync($"{BASE_URI}/api/AddGuess", content);

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
