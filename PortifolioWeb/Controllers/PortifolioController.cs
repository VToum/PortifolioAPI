using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortifolioWeb.Service;

namespace PortifolioWeb.Controllers
{
    public class PortifolioController : Controller
    {
        private readonly IPortifolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortifolioController(IPortifolioService portfolioService)
        {
            _portfolioService = portfolioService;
         
        }

        public async Task<IActionResult> IndexPortifolio() 
        {
        
            return View();
        }
    }
}
