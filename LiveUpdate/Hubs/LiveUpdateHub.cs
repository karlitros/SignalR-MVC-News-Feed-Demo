using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace LiveUpdate.Hubs
{
    /// <summary>
    /// Skeleton hub class used to establish connections.
    /// We could pop methods in here that could be called directly by the client.
    /// </summary>
    [HubName("updateFeed")]
    public class LiveUpdateHub : Hub
    {
    }
}