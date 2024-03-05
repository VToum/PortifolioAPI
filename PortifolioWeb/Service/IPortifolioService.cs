using PortifolioWeb.Models.Dto;

namespace PortifolioWeb.Service
{
    public interface IPortifolioService
    {
        Task<T> CreateAsync<T>(ContactDto dto);
        Task<T> GetAllAsync<T>();
        Task<T> GetIdAsync<T>(int id);

    }
}
