using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvertersChatApp.BrokerBot
{
    public class StooqBrokerBot : IBrokerQueryBot
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl = "https://stooq.com/q/l/";

        public StooqBrokerBot() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiBaseUrl);

        }

        public async Task<string> GetQuoteValue(string stockName)
        { 
            string uriResult = $"?s={stockName}&f=sd2t2ohlcv&h&e=csv";
            string result = "";

            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uriResult);

            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string line;
                    streamReader.ReadLine();
                    line = streamReader.ReadLine();

                    if (line != null)
                    {
                        var quoteValue = line.Split(",")[6];
                        if (quoteValue != null && quoteValue.Trim() != "N/D")
                            result = $"{stockName} quote is ${quoteValue} per share”";
                        else
                            result = $"The stock {stockName} is not in our database."; ;
                    }
                    else 
                    {
                        result = "We had an error. Please, contact admins";
                        
                    }
                }
            }

            return result;
        }
    }
}
