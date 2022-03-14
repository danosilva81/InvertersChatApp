using InvertersChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvertersChatApp.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        public static Dictionary<int, string> Rooms = new Dictionary<int, string>() {
            { 1, "Beginners Investors" },
            { 2, "Medium" },
            { 3, "Experts" }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Room(int room)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Name);
    
            return View("Room", new ChatSession() { RoomSession = room, UserEmail = userEmail, NumberOfMessagesInRoom = 50});
        }
    }
}
