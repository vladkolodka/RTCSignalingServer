using Microsoft.AspNetCore.Mvc;

namespace RTCSignalingServer.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "RTC Signaling Server";
        }
    }
}