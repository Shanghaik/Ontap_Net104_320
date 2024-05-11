using Microsoft.AspNetCore.Mvc;
using Ontap_Net104_320.Models;
using System.Diagnostics;

namespace Ontap_Net104_320.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var sessiondata = HttpContext.Session.GetString("account"); // Lấy dữ liệu từ session
            if (sessiondata == null) // Nếu chưa đăng nhập hoặc data ko có
            {
                ViewData["login"] = "Bạn chưa đăng nhập!";
            }
            else ViewData["login"] = "Xin chào " + sessiondata;
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
    }
}