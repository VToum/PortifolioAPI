using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortifolioWeb.Helper;
using PortifolioWeb.Models;
using PortifolioWeb.Models.Dto;
using PortifolioWeb.Service;

namespace PortifolioWeb.Controllers
{
    public class PortifolioController : Controller
    {
        private readonly IPortifolioService _portfolioService;
        private readonly IEmail _email;
        protected APIResponse _response;
        public PortifolioController(IPortifolioService portifolioService, IEmail email)
        {
            _portfolioService = portifolioService;
            _email = email;
        }

        public async Task<IActionResult> IndexPortifolio() 
        {
        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPortifolio(ContactDto model)
        {

            var response = await _portfolioService.CreateAsync<APIResponse>(model);

            if (response != null && response.IsSuccess)
            {
                return View(nameof(IndexPortifolio));
            }
            else
            {
                TempData["AlertMessageFailed"] = "Erro ao enviar email!";
                ViewBag.AlertMessage = TempData["AlertMessageFailed"];

                return View(nameof(Index));
            }
        }
    }
}
