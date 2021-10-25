using lab1.Models;
using lab1.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.EmailSender;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, 
                              IEmailSender emailSender,
                              IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            //var currentUrl = HttpContext.Request.GetEncodedUrl();
            var currentUrl = _httpContextAccessor.HttpContext.Request.GetEncodedUrl();
            _logger.LogInformation(currentUrl);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SendEmail([FromForm] EmailMessageVM vm)
        {
            await _emailSender.SendMessage(vm.EmailTo, vm.MessageBody, vm.Subject);
            return Json(new { success = true });
        }
    }
}
