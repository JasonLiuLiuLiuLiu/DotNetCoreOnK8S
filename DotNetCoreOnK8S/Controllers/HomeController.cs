using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreOnK8S.Models;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreOnK8S.Controllers
{
    public class HomeController : Controller
    {   
        private readonly int _buildVersion;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _buildVersion = configuration.GetValue<int>("BuildVersion");
        }

        public IActionResult Index()
        {
            var model = new BaseViewModel()
            {
                BuildVersion = _buildVersion
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel()
            {
                BuildVersion = _buildVersion
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, BuildVersion = _buildVersion });
        }
    }
}
