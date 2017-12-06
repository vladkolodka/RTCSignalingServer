using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RTCSignalingServer.Hubs
{
    public class SignalingHub : Hub
    {
        public async Task Test()
        {
            await Clients.All.InvokeAsync("FromServerTest", "Data from server");
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddAsync(Context.ConnectionId, groupName);

            Console.WriteLine($"{Context.ConnectionId} joined to group \"{groupName}\"");
        }

        public async Task SendOffer(string groupName, string myGroupName, string sdp)
        {
            await Clients.Group(groupName).InvokeAsync("NewOffer", myGroupName, sdp);

            Console.WriteLine($"Offer from {myGroupName} to {groupName}");
        }

        public async Task SendAnswer(string recipientGroup, string sdp)
        {
            await Clients.Group(recipientGroup).InvokeAsync("NewAnswer", sdp);

            Console.WriteLine($"Answer to {recipientGroup}");
        }

        public async Task SendCandidate(string recipientGroup, string ice)
        {
            await Clients.Group(recipientGroup).InvokeAsync("NewCandidate", ice);

            Console.WriteLine($"Candidate for {recipientGroup}");
        }
    }
}