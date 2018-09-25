using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultyProjectPoc.Models;
using System.Diagnostics;

namespace MultyProjectPoc.Controllers
{
    public class HomeController : ProjectController
    {
        public HomeController(IHttpContextAccessor httpContextAncestor) 
            : base(httpContextAncestor)
        {
        }

        public IActionResult Index()
        {
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
