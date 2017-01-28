using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileResults.Web.Models;
using AgileResults.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgileResults.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public HomeController(IRepository repository, ILoggerFactory loggerFactory)
        {
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger(typeof(HomeController));
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello from Home controller!");
            _logger.LogWarning("Will this work!!!!!");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FakeContact(Person person)
        {
            var personId = await _repository.AddPerson(person);
            ModelState.Clear();
            ViewData["Message"] = $"Person {personId} was added.";
            return View("About");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
