using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreOnK8S.Helper;
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

        public IActionResult Index(string name = "admin")
        {
            var model = new HomeViewModel()
            {
                BuildVersion = _buildVersion,
                Name = name
            };
            var message = $"{name} is online";
            Console.WriteLine(message);
            LogWriter.Write(message);
            SetEnv(model);
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel()
            {
                BuildVersion = _buildVersion
            };
            SetEnv(model);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, BuildVersion = _buildVersion });
        }

        private void SetEnv(BaseViewModel model)
        {
            model.NodeName = Environment.GetEnvironmentVariable("NODE_NAME");
            model.PodName = Environment.GetEnvironmentVariable("POD_NAME");
            model.PodNameSpace = Environment.GetEnvironmentVariable("POD_NAMESPACE");
            model.PodIp = Environment.GetEnvironmentVariable("POD_IP");
        }
    }
}
