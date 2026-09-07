namespace Project.Server.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class EntregaHub : Hub
    {
        public Task Ping()
        {
            return Task.CompletedTask;
        }
    }
}
