using Portifilio_Utility;
using PortifolioWeb.Models;
using PortifolioWeb.Models.Dto;

namespace PortifolioWeb.Service
{
    public class PortifolioService : BaseService, IPortifolioService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string PortifolioUrl;

        public PortifolioService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            PortifolioUrl = configuration.GetValue<string>("ServiceUrls:PortifolioAPI");
        }

        public Task<T> CreateAsync<T>(ContactDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Post,
                Data = dto,
                Url = PortifolioUrl + "api/ContactMe/"
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Post,
                Url = PortifolioUrl + "api/ContactMe/"
            });
        }

        public Task<T> GetIdAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Post,
                Url = PortifolioUrl + "api/ContactMe/" + id
            });
        }
    }
}
