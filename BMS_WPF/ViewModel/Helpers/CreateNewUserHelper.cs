using BMS_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BMS_WPF.ViewModel.Helpers
{
    class CreateNewUserHelper
    {
        public const string BASE_URL = "http://localhost:7001/api/";
        public const string POST_URL = "User";

        public static async Task<string> CreateAccount(UserDetail userDetail)
        {
            string agent;
            string URL = BASE_URL + POST_URL;

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, userDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

    }
}
