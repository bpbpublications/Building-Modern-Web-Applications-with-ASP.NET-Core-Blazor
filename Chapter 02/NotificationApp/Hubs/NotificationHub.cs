using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;

public class NotificationHub : Hub
{
    private static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

    public async Task Notify(string notification)
    {
        var caller = Clients.Caller;

        await Clients.All.SendAsync("onReceived", $"{DateTime.Now.ToShortTimeString()}: {Connections[Context.ConnectionId]} notifies: {notification}");
    }

    public override async Task OnConnectedAsync()
    {
        var feature = Context.Features.Get<IHttpConnectionFeature>();
        Connections[Context.ConnectionId] = $"{feature.RemoteIpAddress}: {feature.RemotePort}";

        await base.OnConnectedAsync();

        await Clients.All.SendAsync("onReceived", $"{DateTime.Now.ToShortTimeString()}: {Connections[Context.ConnectionId]} joins.");
    }
}