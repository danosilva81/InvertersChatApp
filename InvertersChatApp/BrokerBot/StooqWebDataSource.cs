using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvertersChatApp.BrokerBot
{
    public class StooqWebDataSource : IBrokerDataSource
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl = "https://stooq.com/q/l/";

        public StooqWebDataSource()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiBaseUrl);

        }

        public async Task<string> GetCsvStockValues(string stockName)
        {
            string uriResult = $"?s={stockName}&f=sd2t2ohlcv&h&e=csv";
            return await _httpClient.GetStringAsync(uriResult);
        }
    }
}
