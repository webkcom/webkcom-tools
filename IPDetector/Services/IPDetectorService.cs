using System.Text.Json;
using IPDetector.Models;
using System.Net;
using System.Web;


namespace IPDetector.Service
{
    public class IPDetectorService
    {
        public string IP = "";

        public string getResult()
        {
            // IPDetectorModel ipDetector = new IPDetectorModel();
            // HttpListener listener = new HttpListener();
            // listener.Prefixes.Add("http://localhost:7709/");
            // listener.Start();
            // HttpListenerContext context = listener.GetContext();
            // HttpListenerRequest request = context.Request;
            // IP = "";
            // getRemoteEndPoint(request);
            // listener.Stop();
            
            return IP;
        }
        public void getRemoteEndPoint(HttpListenerRequest request)
        {
            // IP = request.RemoteEndPoint.ToString();
            
        }

    }
}