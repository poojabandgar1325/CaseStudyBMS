using BMS_WPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BMS_WPF.ViewModel.Helpers
{
    class ViewLoanHelper
    {
        public const string BASE_URL = "http://localhost:7001/api/";
        public const string GET_URL = "Loan/all/{0}";

        public static async Task<IEnumerable<LoanDetail>> GetUserDetail(string userName)
        {
            List<LoanDetail> loanDetail;
            string URL = BASE_URL + string.Format(GET_URL, userName);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                loanDetail = JsonConvert.DeserializeObject<List<LoanDetail>>(json);
            };

            return loanDetail;
        }
    }
}
