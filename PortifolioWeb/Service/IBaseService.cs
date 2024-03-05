using PortifolioWeb.Models;

namespace PortifolioWeb.Service
{
    public interface IBaseService
    {
        APIRequest responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
