using System.Threading.Tasks;

namespace InvertersChatApp.BrokerBot
{
    public interface IBrokerDataSource
    {
        public Task<string> GetCsvStockValues(string stockName);
    }
}
