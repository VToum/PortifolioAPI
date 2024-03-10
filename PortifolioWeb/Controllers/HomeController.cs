using Microsoft.AspNetCore.Mvc;
using PortifolioWeb.Helper;
using PortifolioWeb.Models;
using PortifolioWeb.Models.Dto;
using PortifolioWeb.Service;
using System.Diagnostics;
using System.Reflection;

namespace PortifolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortifolioService _portifolioService;
        private readonly IEmail _email;
        protected APIResponse _response;

        public HomeController(ILogger<HomeController> logger, IPortifolioService portifolioService, IEmail email)
        {
            _logger = logger;
            _portifolioService = portifolioService;
            _email = email;
        }

        public async Task<IActionResult> Index()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexCreate(ContactDto model)
        {

            var response = await _portifolioService.CreateAsync<APIResponse>(model);

            if (response != null && response.IsSuccess)
            {
                //bool success = _email.SendEmail(model.Email, model.Nome, model.Message);
                //TempData["AlertMessageSuccess"] = "Sucesso ao Enviar Email!";
                //ViewBag.AlertMessage = TempData["AlertMessageSuccess"];

                return View(nameof(Index));
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
