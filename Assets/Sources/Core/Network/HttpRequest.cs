using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.Network
{
    public class HttpRequest
    {
        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public string Parameters { get; set; }
    }
}
