namespace RTCSignalingServer.Hubs
{
    public interface IClientHandlers
    {
        /// <summary>
        /// New call offer
        /// </summary>
        /// <param name="groupName">Interlocutor group name</param>
        /// <param name="sdp">SDP pocket</param>
        void NewOffer(string groupName, string sdp);
        /// <summary>
        /// Call answer received
        /// </summary>
        /// <param name="sdp">SDP pocket</param>
        void NewAnswer(string sdp);
        /// <summary>
        /// On new candidate received
        /// </summary>
        /// <param name="ice">ICE candidate</param>
        void NewCandidate(string ice);
    }
}