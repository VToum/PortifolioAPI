using System.Net;
using static Portifilio_Utility.SD;

namespace PortifolioWeb.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.Post;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
