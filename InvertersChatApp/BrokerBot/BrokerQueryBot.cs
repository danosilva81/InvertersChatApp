using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvertersChatApp.BrokerBot
{
    public class BrokerQueryBot : IBrokerQueryBot
    {
        private readonly IBrokerDataSource _brokerDataSource;

        public BrokerQueryBot(IBrokerDataSource brokerDataSource) 
        {
            _brokerDataSource = brokerDataSource;
        }

        public async Task<string> GetQuoteValue(string stockName)
        {
            string result = "";

            string csvResult = await _brokerDataSource.GetCsvStockValues(stockName);
            var lines = csvResult.Split("\r\n");
            if (lines != null && lines.Length > 1 && lines[1].Split(",").Length > 6 )
            {
                var quoteValue = lines[1].Split(",")[6];
                if (quoteValue != null && quoteValue.Trim() != "N/D")
                    result = $"{stockName} quote is ${quoteValue} per share”";
                else
                    result = $"The stock quote of '{stockName}' is not in our database."; ;
            }
            else
            {
                result = "We had an error. Please, contact admins";

            }

            return result;
        }
    }
}
