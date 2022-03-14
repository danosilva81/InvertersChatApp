using InvertersChatApp.BrokerBot;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvertersChatApp.ChatRoom
{
    public class ChatHub : Hub
    {
        private IBrokerQueryBot _brokerBot;

        public ChatHub(IBrokerQueryBot brokerQueryBot) 
        {
            _brokerBot = brokerQueryBot;
        }

         public async Task SendMessage(string room, string user, string message) 
         {
            await Clients.Group(room).SendAsync("ReceiveMessage", user, message);

            if (message.Trim().StartsWith("/stock=")) 
            {
                var stockName = message.Split("/stock=")[1];
                await SendBotMessage(room, stockName);
            }                
         }

        public async Task SendBotMessage(string room, string stockName) 
        {
            string botMessage = await _brokerBot.GetQuoteValue(stockName);
            await Clients.Group(room).SendAsync("ReceiveMessage", "Broker Bot", botMessage);
        }

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }
    }
}
 