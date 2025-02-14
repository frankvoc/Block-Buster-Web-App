using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;
        private readonly string[] _myHobbies;
        private readonly string[] _myCities;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = [ "red", "green", "blue" ];
            _myCities = ["Westerly", "Cocoa Beach", "South Kingstown"];
            _myHobbies = ["Gaming", "Coding", "Movies"];

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Colors()
        {
            ViewBag.MyColors = _myColors;
            return View();
        }
        public IActionResult Hobbies()
        {
            ViewBag.MyHobbies = _myHobbies;
            return View();
        }
        public IActionResult Cities()
        {
            ViewBag.MyCities = _myCities;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
