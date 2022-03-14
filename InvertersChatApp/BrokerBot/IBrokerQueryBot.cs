using System.Threading.Tasks;

namespace InvertersChatApp.BrokerBot
{
    public interface IBrokerQueryBot
    {
        public Task<string> GetQuoteValue(string stockName);
    }
}