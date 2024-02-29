using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebChatServer.Hubs
{
    public class ChatHub:Hub

    {
        public async Task TextShare(string user, string message)
        {
            await Clients.All.SendAsync("msgRcv", user, message);
            //await Clients.Caller.SendAsync("selfMsg", message);
            //await Clients.Others.SendAsync("msgRcv", user, message);

        }

        public async Task ImageShare(string user, string imageData)
        {
            await Clients.All.SendAsync("imgRcv", user, imageData);
            //await Clients.Caller.SendAsync("imgRcv", user, imageData);
            //await Clients.Others.SendAsync("imgRcv", user, imageData);

        }
    }
}
