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
    class UpdateUserHelper
    {

        public const string BASE_URL = "http://localhost:7001/api/";
        public const string PUT_URL = "User/UpdateUser/{0}";
        public const string LOANSTATUS_PUT_URL = "Loan/statusUpdate/{0}";
       
        //public static async Task<string> UpdateUserAsync(string userName, UserDetail userDetail)
        //{
        //    string agent;
        //    string URL = BASE_URL +  string.Format(PUT_URL, userName);

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        HttpResponseMessage response = await httpClient.PutAsJsonAsync(URL, userDetail, default);
        //        var json = await response.Content.ReadAsStringAsync();
        //        agent = json.ToString();
        //    }
        //     return agent;
            
        //}
        public static async Task<string> UpdateUserAsync(string username, UserDetail userDetail)
        {
            string agent;
            string URL = BASE_URL + string.Format(PUT_URL, username);

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, userDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

        //public async Task<string> UpdateLoanStatus(int loanId, string statusvalue)
        //{
        //    string agent;
        //    string URL = BASE_URL + string.Format(LOANSTATUS_PUT_URL, loanId);

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        HttpResponseMessage response = await httpClient.PutAsJsonAsync(URL, statusvalue, default);
        //        var json = await response.Content.ReadAsStringAsync();
        //        agent = json.ToString();
        //    }
        //    return agent;

        //}

        public  async Task<string> UpdateLoanStatus(int loanId, string statusValue)
        {
            string agent;
            string URL = BASE_URL + string.Format(LOANSTATUS_PUT_URL, loanId);

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, statusValue, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

       


    }
}
