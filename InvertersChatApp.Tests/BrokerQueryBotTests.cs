using InvertersChatApp.BrokerBot;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace InvertersChatApp.Tests
{
    public class BrokerQueryBotTests
    {
        private BrokerQueryBot _brokerQueryBot;
        private Mock<IBrokerDataSource> _mockedDataSource;

        public BrokerQueryBotTests() 
        {
            _mockedDataSource = new Mock<IBrokerDataSource>();
            _brokerQueryBot = new BrokerQueryBot(_mockedDataSource.Object);
        }

        [Fact]
        public async Task GetQuoteValue_EmptyResult_ShouldReturnErrorMessageAsync()
        {
            _mockedDataSource.Setup(x => x.GetCsvStockValues(It.IsAny<string>())).Returns(Task.FromResult(""));
            var quoteValueResult = await _brokerQueryBot.GetQuoteValue("aapl.us");
            Assert.Equal("We had an error. Please, contact admins.", quoteValueResult);
        }

        [Fact]
        public async Task GetQuoteValue_EmptyValue_ShouldReturnNoQuoteMessageAsync()
        {
            var csvResult = "Symbol,Date,Time,Open,High,Low,Close,Volume\r\nFAKE.US,N/D,N/D,N/D,N/D,N/D,N/D,N/D\r\n";
            _mockedDataSource.Setup(x => x.GetCsvStockValues(It.IsAny<string>())).Returns(Task.FromResult(csvResult));
            
            var quoteValueResult = await _brokerQueryBot.GetQuoteValue("FAKE.US");
            
            Assert.Equal("The stock quote of 'FAKE.US' is not in our database.", quoteValueResult);
        }

        [Fact]
        public async Task GetQuoteValue_QuoteResult_ShouldReturnQuoteValueMessageAsync()
        {
            var csvResult = "Symbol,Date,Time,Open,High,Low,Close,Volume\r\nAAPL.US,2022-03-14,16:33:35,151.45,154.12,151.3,153,26250098\r\n";
            _mockedDataSource.Setup(x => x.GetCsvStockValues(It.IsAny<string>())).Returns(Task.FromResult(csvResult));

            var quoteValueResult = await _brokerQueryBot.GetQuoteValue("aapl.us");

            Assert.Equal("aapl.us quote is $153 per share.", quoteValueResult);
        }
    }
}
