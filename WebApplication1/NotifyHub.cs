using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CoffeeShops
{
    [HubName("NotifyHub")]
    public class NotifyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
        public void invoiceCome(int id)
        {
            Clients.All.addTask(id);
        }
        public void test()
        {
            Clients.All.receive();
        }
    }
}