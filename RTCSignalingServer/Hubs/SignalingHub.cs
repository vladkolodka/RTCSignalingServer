using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RTCSignalingServer.Hubs
{
    /// <summary>
    /// Signaling hub (url: /signaling)
    /// </summary>
    public class SignalingHub : Hub
    {
        public async Task Test()
        {
            await Clients.All.InvokeAsync("FromServerTest", "Data from server");
        }

        /// <summary>
        /// Joins user to group by name.
        /// </summary>
        /// <param name="groupName">Name of user group (self)</param>
        /// <returns></returns>
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddAsync(Context.ConnectionId, groupName);

            Console.WriteLine($"{Context.ConnectionId} joined to group \"{groupName}\"");
        }

        /// <summary>
        /// Sends offer to user in specified group
        /// </summary>
        /// <param name="groupName">Interlocurtor group name</param>
        /// <param name="myGroupName">User group name (own)</param>
        /// <param name="sdp">SDP pocket for interlocutor</param>
        /// <returns></returns>
        public async Task SendOffer(string groupName, string myGroupName, string sdp)
        {
            await Clients.Group(groupName).InvokeAsync("NewOffer", myGroupName, sdp);

            Console.WriteLine($"Offer from {myGroupName} to {groupName}");
        }

        /// <summary>
        /// Sends answer to user in specified group (by name)
        /// </summary>
        /// <param name="recipientGroup">Initiator group name</param>
        /// <param name="sdp">SDP pocket for call initiator</param>
        /// <returns></returns>
        public async Task SendAnswer(string recipientGroup, string sdp)
        {
            await Clients.Group(recipientGroup).InvokeAsync("NewAnswer", sdp);

            Console.WriteLine($"Answer to {recipientGroup}");
        }

        /// <summary>
        /// Sends candidate pocket to user in specified group (by name)
        /// </summary>
        /// <param name="recipientGroup">Interlocutor group name</param>
        /// <param name="ice">ICE pocket</param>
        /// <returns></returns>
        public async Task SendCandidate(string recipientGroup, string ice)
        {
            await Clients.Group(recipientGroup).InvokeAsync("NewCandidate", ice);

            Console.WriteLine($"Candidate for {recipientGroup}");
        }
    }
}