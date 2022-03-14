using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvertersChatApp.Models
{
    public class ChatSession
    {
        public int RoomSession { get; set; }

        public string UserEmail { get; set; }

        public int NumberOfMessagesInRoom { get; set; }
    }
}
